const fs = require("fs");
async function svhelper(songsfolder, folderpath, filename, startpoint, endpoint, startSV, endSV, startvolume, endvolume, snap, kiaibool, grbool, SVOffset, writemode) {
    return new Promise((resolve, reject) => {
        try {
            fs.writeFileSync(`./Backups/${filename.replace(/.osu/g, "")}.backup`, "")
            fs.writeFileSync("./status.txt", "true");
            if (grbool === "1") {
                let calculatetimingpointsflag = false;
                let timing = [];
                let offset = [];
                let beforesvlocation = [];
                let aftersvlocation = [];
                let beforesvmultiplier = []
                let mapstring = "";
                let timingpointsflag = false;
                let hitobjectflag = false;

                const ReadStream = fs.createReadStream(`${songsfolder}/${folderpath}/${filename}`, 'utf-8');
                const lineReader = require('readline').createInterface({
                    input: ReadStream,
                });

                lineReader.on('line', (line) => {
                    let writestring = line.replace("\r", "");

                    if (writestring === "") {
                        fs.appendFileSync(`./Backups/${filename.replace(/.osu/g, "")}.backup`, `\n`)
                        return;
                    }

                    if (timingpointsflag) {
                        if (parseFloat(writestring.split(",")[1]) < 0) {
                            beforesvlocation.push(parseInt(writestring.split(",")[0]));
                            if (writemode == "3") beforesvmultiplier.push(-100 / parseFloat(writestring.split(",")[1]));
                        }
                    }

                    // ヒットオブジェクトフェーズの処理
                    if (hitobjectflag) {
                        if (parseInt(writestring.split(",")[2]) >= startpoint && parseInt(writestring.split(",")[2]) <= endpoint) {
                            timing.push(parseInt(writestring.split(",")[2]));
                        }
                    }

                    // タイミングポイントフェーズの処理
                    if (writestring === "[TimingPoints]" && (writemode == "2" || writemode == "3")) {
                        timingpointsflag = true;
                    }

                    // ヒットオブジェクトフェーズの処理
                    if (writestring === "[HitObjects]") {
                        timingpointsflag = false;
                        hitobjectflag = true;
                    }

                    fs.appendFileSync(`./Backups/${filename.replace(/.osu/g, "")}.backup`, `${writestring}\n`);
                });

                lineReader.on('close', () => {
                    hitobjectflag = false;
                    for (const element of timing) {
                        offset.push(element - timing[0])
                    }

                    const tempReadStream = fs.createReadStream(`./Backups/${filename.replace(/.osu/g, "")}.backup`, 'utf-8');
                    const tempReader = require('readline').createInterface({
                        input: tempReadStream,
                    });

                    fs.writeFileSync(`${songsfolder}/${folderpath}/${filename}`, "")

                    tempReader.on('line', (line) => {
                        let writestring = line.replace("\r", "");

                        if (hitobjectflag) {
                            fs.appendFileSync(`${songsfolder}/${folderpath}/${filename}`, `${writestring}\n`)
                            return;
                        }

                        if (writestring === "" && timingpointsflag) {
                            const lines = mapstring.split("\n").filter(line => line !== "");
                            lines.sort((a, b) => {
                                return parseInt(a.split(",")[0]) - parseInt(b.split(",")[0]);
                            });
                            const sortedString = lines.join("\n");
                            fs.appendFileSync(`${songsfolder}/${folderpath}/${filename}`, `${sortedString}\n\n`)
                            timingpointsflag = false;
                            return;
                        }

                        if (writestring === "") {
                            fs.appendFileSync(`${songsfolder}/${folderpath}/${filename}`, `\n`)
                            return;
                        }

                        if (timingpointsflag) {
                            if ((writemode == "0" || writemode == "3") && aftersvlocation.includes(parseInt(writestring.split(",")[0]))) {
                                mapstring += "\n";
                                return;
                            } else {
                                mapstring += writestring + "\n";
                                return;
                            }
                        }

                        //タイミングポイントフェーズの処理
                        if (calculatetimingpointsflag) {
                            const firstbpm = parseInt(writestring.split(",")[0])

                            // マップの文字列を作成
                            for (let i = 0; i < timing.length; i++) {

                                // SVを置く位置
                                const currentpoint = timing[i];

                                // SVの計算
                                const currentsv = -100 / (100 / (((100 / endSV) - (100 / startSV)) / Math.max(...offset) * (offset[i] - offset[0]) + (100 / startSV)))

                                // 音量の計算
                                const currentvolume = Math.round(startvolume + (endvolume - startvolume) * (offset[i] - offset[0]) / Math.max(...offset))

                                // 上はkiaiモードでのラストの処理
                                // その他は通常での処理
                                if (i == timing.length - 1 && kiaibool == "1") {
                                    if (writemode == "2" && beforesvlocation.includes(currentpoint + SVOffset)) continue;
                                    if (writemode == "3" && beforesvlocation.includes(currentpoint + SVOffset)) {
                                        const sv = -100 / (100 / (((100 / endSV) - (100 / startSV)) / Math.max(...offset) * (offset[i] - offset[0]) + (100 / startSV)) * beforesvmultiplier[beforesvlocation.indexOf(currentpoint + SVOffset)])
                                        mapstring += `${currentpoint + SVOffset},${sv},${writestring.split(",")[2]},${writestring.split(",")[3]},${writestring.split(",")[4]},${currentvolume},0,0\n`
                                    } else {
                                        mapstring += `${currentpoint + SVOffset},${currentsv},${writestring.split(",")[2]},${writestring.split(",")[3]},${writestring.split(",")[4]},${currentvolume},0,0\n`
                                    }
                                    if (writemode == "0" || writemode == "3") aftersvlocation.push(currentpoint + SVOffset);
                                } else if (currentpoint + SVOffset <= firstbpm) {
                                    if (currentpoint <= firstbpm) {
                                        if (writemode == "2" && beforesvlocation.includes(firstbpm)) continue;
                                        if (writemode == "3" && beforesvlocation.includes(firstbpm)) {
                                            const sv = -100 / (100 / (((100 / endSV) - (100 / startSV)) / Math.max(...offset) * (offset[i] - offset[0]) + (100 / startSV)) * beforesvmultiplier[beforesvlocation.indexOf(firstbpm)])
                                            mapstring += `${firstbpm},${sv},${writestring.split(",")[2]},${writestring.split(",")[3]},${writestring.split(",")[4]},${currentvolume},0,${kiaibool}\n`
                                        } else {
                                            mapstring += `${firstbpm},${currentsv},${writestring.split(",")[2]},${writestring.split(",")[3]},${writestring.split(",")[4]},${currentvolume},0,${kiaibool}\n`
                                        }
                                        if (writemode == "0" || writemode == "3") aftersvlocation.push(firstbpm);
                                    } else {
                                        if (writemode == "2" && beforesvlocation.includes(currentpoint)) continue;
                                        if (writemode == "3" && beforesvlocation.includes(currentpoint)) {
                                            const sv = -100 / (100 / (((100 / endSV) - (100 / startSV)) / Math.max(...offset) * (offset[i] - offset[0]) + (100 / startSV)) * beforesvmultiplier[beforesvlocation.indexOf(currentpoint)])
                                            mapstring += `${currentpoint},${sv},${writestring.split(",")[2]},${writestring.split(",")[3]},${writestring.split(",")[4]},${currentvolume},0,${kiaibool}\n`
                                        } else {
                                            mapstring += `${currentpoint},${currentsv},${writestring.split(",")[2]},${writestring.split(",")[3]},${writestring.split(",")[4]},${currentvolume},0,${kiaibool}\n`
                                        }
                                        if (writemode == "0" || writemode == "3") aftersvlocation.push(currentpoint);
                                    }
                                } else {
                                    if (writemode == "2" && beforesvlocation.includes(currentpoint + SVOffset)) continue;
                                    if (writemode == "3" && beforesvlocation.includes(currentpoint + SVOffset)) {
                                        const sv = -100 / (100 / (((100 / endSV) - (100 / startSV)) / Math.max(...offset) * (offset[i] - offset[0]) + (100 / startSV)) * beforesvmultiplier[beforesvlocation.indexOf(currentpoint + SVOffset)])
                                        mapstring += `${currentpoint + SVOffset},${sv},${writestring.split(",")[2]},${writestring.split(",")[3]},${writestring.split(",")[4]},${currentvolume},0,${kiaibool}\n`
                                    } else {
                                        mapstring += `${currentpoint + SVOffset},${currentsv},${writestring.split(",")[2]},${writestring.split(",")[3]},${writestring.split(",")[4]},${currentvolume},0,${kiaibool}\n`
                                    }
                                    if (writemode == "0" || writemode == "3") aftersvlocation.push(currentpoint + SVOffset);
                                }
                            }
                            timingpointsflag = true;
                            calculatetimingpointsflag = false;
                        }

                        if (writestring === "[TimingPoints]") {
                            calculatetimingpointsflag = true;
                        }

                        if (writestring === "[HitObjects]") {
                            hitobjectflag = true;
                        }

                        fs.appendFileSync(`${songsfolder}/${folderpath}/${filename}`, `${writestring}\n`)
                    });

                    tempReader.on('close', async () => {
                        resolve("success")
                    });
                })
            } else {
                let timingpointsflag = false;
                let calculatetimingpointsflag = false;
                let hitobjectflag = false;
                let BPMvalue = [];
                let beforesvlocation = [];
                let aftersvlocation = [];
                let beforesvmultiplier = []
                let mapstring = "";
        
                const ReadStream = fs.createReadStream(`${songsfolder}/${folderpath}/${filename}`, 'utf-8');
                const lineReader = require('readline').createInterface({
                    input: ReadStream,
                });
        
                lineReader.on('line', (line) => {
                    let writestring = line.replace("\r", "");
        
                    if (writestring === "") {
                        fs.appendFileSync(`./Backups/${filename.replace(/.osu/g, "")}.backup`, `\n`)
                        return;
                    }
        
                    if (writestring === "[HitObjects]") {
                        timingpointsflag = false;
                    }
        
                    //タイミングポイントフェーズの処理
                    if (timingpointsflag) {
                        if (parseFloat(writestring.split(",")[1]) >= 0) {
                            const Songsbpm = 1 / parseFloat(line.split(",")[1]) * 60000;
                            BPMvalue.push(Songsbpm, parseFloat(line.split(",")[0]));
                        }

                        if (writemode == "2" && parseFloat(writestring.split(",")[1]) < 0) {
                            beforesvlocation.push(parseInt(writestring.split(",")[0]));
                        }

                        if (writemode == "3" && parseFloat(writestring.split(",")[1]) < 0) {
                            beforesvlocation.push(parseInt(writestring.split(",")[0]));
                            beforesvmultiplier.push(-100 / parseFloat(writestring.split(",")[1]));
                        }
                    }
        
                    //タイミングポイントフェーズフラグの処理
                    if (writestring === "[TimingPoints]") {
                        timingpointsflag = true;
                    }
        
                    fs.appendFileSync(`./Backups/${filename.replace(/.osu/g, "")}.backup`, `${writestring}\n`)
                });
        
                lineReader.on('close', () => {
                    let count = 0;
                    hitobjectflag = false;
                    const tempReadStream = fs.createReadStream(`./Backups/${filename.replace(/.osu/g, "")}.backup`, 'utf-8');
                    const tempReader = require('readline').createInterface({
                        input: tempReadStream,
                    });
        
                    fs.writeFileSync(`${songsfolder}/${folderpath}/${filename}`, "")
        
                    tempReader.on('line', (line) => {
                        let writestring = line.replace("\r", "");
        
                        if (hitobjectflag) {
                            fs.appendFileSync(`${songsfolder}/${folderpath}/${filename}`, `${writestring}\n`)
                            return;
                        }

                        if (writestring === "" && timingpointsflag) {
                            const lines = mapstring.split("\n").filter(line => line !== "");
                            lines.sort((a, b) => {
                                return parseInt(a.split(",")[0]) - parseInt(b.split(",")[0]);
                            });
                            const sortedString = lines.join("\n");
                            fs.appendFileSync(`${songsfolder}/${folderpath}/${filename}`, `${sortedString}\n\n`)
                            timingpointsflag = false;
                            return;
                        }
                        
                        if (writestring === "") {
                            fs.appendFileSync(`${songsfolder}/${folderpath}/${filename}`, `\n`)
                            return;
                        }
        
                        if (timingpointsflag) {
                            if ((writemode == "0" || writemode == "3") && aftersvlocation.includes(parseInt(writestring.split(",")[0]))) {
                                mapstring += "\n";
                                return;
                            } else {
                                mapstring += writestring + "\n";
                                return;
                            }
                        }
        
                        //タイミングポイントフェーズの処理
                        if (calculatetimingpointsflag) {
                            const firstbpm = parseInt(writestring.split(",")[0])
        
                            // BPMを取得
                            let BPM = 0;
                            for (let i = 0; i < BPMvalue.length; i += 2) {
                                if (parseFloat(line.split(",")[0]) >= BPMvalue[i + 1]) BPM = BPMvalue[i];
                            }
        
                            // 1 / snapの増加量を計算
                            const step = 60000 / BPM / snap;
        
                            // 1 / snapの増加量でどれほどSVが増えるか計算(1msあたりの増加量 * stepと同じ式)
                            const snapstep = ((endSV - startSV) / ((endpoint - startpoint) / step));
        
                            // 1 / snapの増加量でどれほど音量が増えるか計算
                            const volume = (endvolume - startvolume) / ((endpoint - startpoint) / step);
        
                            // マップの文字列を作成
                            while (count < (endpoint - startpoint) / step) {
        
                                // SVを置く位置の計算(初めの位置 + (1 / snapの増加量 * count)
                                const currentpoint = Math.round(startpoint + (step * count));
        
                                // SVの計算(初めのSV + (1 / snapの増加量 * count)
                                const currentsv = -100 / (startSV + (snapstep * count));
        
                                // 音量の計算(初めの音量 + (1 / snapの増加量 * count)
                                const currentvolume = Math.round(startvolume + (volume * count));
        
                                // 上はkiaiモードでのラストの処理
                                // その他は通常での処理
                                if (count + 1 >= (endpoint - startpoint) / step && kiaibool == "1") {
                                    if (writemode == "2" && beforesvlocation.includes(currentpoint + SVOffset)) {
                                        count++;
                                        return;
                                    }
                                    if (writemode == "3" && beforesvlocation.includes(currentpoint + SVOffset)) {
                                        const sv = -100 / ((startSV + (snapstep * count)) * beforesvmultiplier[beforesvlocation.indexOf(currentpoint + SVOffset)])
                                        mapstring += `${currentpoint + SVOffset},${sv},${writestring.split(",")[2]},${writestring.split(",")[3]},${writestring.split(",")[4]},${currentvolume},0,0\n`
                                    } else {
                                        mapstring += `${currentpoint + SVOffset},${currentsv},${writestring.split(",")[2]},${writestring.split(",")[3]},${writestring.split(",")[4]},${currentvolume},0,0\n`
                                    }
                                    if (writemode == "0" || writemode == "3") aftersvlocation.push(currentpoint + SVOffset);
                                    count++;
                                } else if (currentpoint + SVOffset <= firstbpm) {
                                    if (currentpoint <= firstbpm) {
                                        if (writemode == "2" && beforesvlocation.includes(firstbpm)) {
                                            count++;
                                            continue;
                                        }
                                        if (writemode == "3" && beforesvlocation.includes(firstbpm)) {
                                            const sv = -100 / ((startSV + (snapstep * count)) * beforesvmultiplier[beforesvlocation.indexOf(firstbpm)])
                                            mapstring += `${firstbpm},${sv},${writestring.split(",")[2]},${writestring.split(",")[3]},${writestring.split(",")[4]},${currentvolume},0,${kiaibool}\n`
                                        } else {
                                            mapstring += `${firstbpm},${currentsv},${writestring.split(",")[2]},${writestring.split(",")[3]},${writestring.split(",")[4]},${currentvolume},0,${kiaibool}\n`
                                        }
                                        if (writemode == "0" || writemode == "3") aftersvlocation.push(firstbpm);
                                        count++;
                                    } else {
                                        if (writemode == "2" && beforesvlocation.includes(currentpoint)) {
                                            count++;
                                            continue;
                                        }
                                        if (writemode == "3" && beforesvlocation.includes(currentpoint)) {
                                            const sv = -100 / ((startSV + (snapstep * count)) * beforesvmultiplier[beforesvlocation.indexOf(currentpoint)])
                                            mapstring += `${currentpoint},${sv},${writestring.split(",")[2]},${writestring.split(",")[3]},${writestring.split(",")[4]},${currentvolume},0,${kiaibool}\n`
                                        } else {
                                            mapstring += `${currentpoint},${currentsv},${writestring.split(",")[2]},${writestring.split(",")[3]},${writestring.split(",")[4]},${currentvolume},0,${kiaibool}\n`
                                        }
                                        if (writemode == "0" || writemode == "3") aftersvlocation.push(currentpoint);
                                        count++;
                                    }
                                } else {
                                    if (writemode == "2" && beforesvlocation.includes(currentpoint + SVOffset)) {
                                        count++;
                                        continue;
                                    }
                                    if (writemode == "3" && beforesvlocation.includes(currentpoint + SVOffset)) {
                                        const sv = -100 / ((startSV + (snapstep * count)) * beforesvmultiplier[beforesvlocation.indexOf(currentpoint + SVOffset)])
                                        mapstring += `${currentpoint + SVOffset},${sv},${writestring.split(",")[2]},${writestring.split(",")[3]},${writestring.split(",")[4]},${currentvolume},0,${kiaibool}\n`
                                    } else {
                                        mapstring += `${currentpoint + SVOffset},${currentsv},${writestring.split(",")[2]},${writestring.split(",")[3]},${writestring.split(",")[4]},${currentvolume},0,${kiaibool}\n`
                                    }
                                    if (writemode == "0" || writemode == "3") aftersvlocation.push(currentpoint + SVOffset);
                                    count++;
                                }
                            }
                            timingpointsflag = true;
                            calculatetimingpointsflag = false;
                        }
        
                        if (writestring === "[TimingPoints]") {
                            calculatetimingpointsflag = true;
                        }

                        if (writestring === "[HitObjects]") {
                            hitobjectflag = true;
                        }
        
                        fs.appendFileSync(`${songsfolder}/${folderpath}/${filename}`, `${writestring}\n`)
                    });
        
                    tempReader.on('close', async () => {
                        resolve("success")
                    });
                })
            }
        } catch (e) {
            reject(e);
            return;
        }
    })
}
async function main () {
    await svhelper(process.argv[2], process.argv[3], process.argv[4], parseInt(process.argv[5]), parseInt(process.argv[6]), parseFloat(process.argv[7]), parseFloat(process.argv[8]), parseInt(process.argv[9]), parseInt(process.argv[10]), parseInt(process.argv[11]), process.argv[12], process.argv[13], parseFloat(process.argv[14]), process.argv[15])
    .then((result) => {
        if (result == "success") {
            fs.writeFileSync("./status.txt", "SC");
        }
    })
    .catch((err) => {
        try {
            fs.removeSync(`${songsfolder}/${folderpath}/${filename}`)
            fs.copyFileSync(`./Backups/${filename.replace(/.osu/g, "")}.backup`, `${songsfolder}/${folderpath}/${filename}`)
            fs.writeFileSync("./error.txt", err.toString());
            fs.writeFileSync("./status.txt", "sverror");
        } catch (error) {
            fs.writeFileSync("./error.txt", error.toString());
            fs.writeFileSync("./status.txt", "svbackuperror");
        }
    });
}

main();

