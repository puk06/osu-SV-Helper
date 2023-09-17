const fs = require("./src/node_modules/fs-extra")

async function undopromise(songsfolder, folderpath, filename) {
    return new Promise((resolve, reject) => {
        try {
            fs.writeFileSync("./status.txt", "undo")
            const exist = fs.existsSync(`./Backups/${filename.replace(/.osu/g, "")}.backup`)
            if (!exist) {
                fs.writeFileSync("./status.txt", "NF")
                resolve("NF")
            } else {
                fs.removeSync(`${songsfolder}/${folderpath}/${filename}`)
                fs.copyFileSync(`./Backups/${filename.replace(/.osu/g, "")}.backup`, `${songsfolder}/${folderpath}/${filename}`)
                resolve("success")
            }
        } catch (err) {
            reject(err)
        }
    })
}

async function main() {
    const songsfolder = process.argv[2]
    const folderpath = process.argv[3]
    const filename = process.argv[4]
    await undopromise(songsfolder, folderpath, filename)
    .then((result) => {
        if (result === "NF") {
            fs.writeFileSync("./status.txt", "NF");
        } else if (result == "success") {
            fs.writeFileSync("./status.txt", "SC");
        }
    })
    .catch((err) => {
        fs.writeFileSync("./error.txt", err.toString());
        fs.writeFileSync("./status.txt", "error");
    })
}

main()
