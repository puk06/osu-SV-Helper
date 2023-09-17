using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace osu__SV_helper
{
    public partial class Form1 : Form
    {
        //フォントをローカルファイルから読み込みます。
        public PrivateFontCollection FontCollection;

        // ステータスをチェックするための変数です。
        private string statusCheck = null;

        // エラーフラグとエラー内容を保存するための変数です。
        private bool errorFlag = false;
        private string errorText = null;

        // タイトルが変わったかどうかを判定するために使う変数です。
        private string beforetitle;
        private Process osuhelper;
        private Process undoSoftware;

        public Form1()
        {
            FontCollection = new PrivateFontCollection();
            FontCollection.AddFontFile("./src/Fonts/Aller.ttf");
            FontCollection.AddFontFile("./src/Fonts/Aller Light.ttf");
            FontCollection.AddFontFile("./src/Fonts/SourceHanCodeJP.ttc");
            InitializeComponent();

            // title, artist, versionをpictureBox1を親として追加。
            pictureBox1.Controls.Add(title);
            pictureBox1.Controls.Add(artist);
            pictureBox1.Controls.Add(version);

            // 値を初期化
            textBox3.Text = "100";
            textBox4.Text = "100";
            startSV.Text = "1.0";
            endSV.Text = "1.0";
            snap.Text = "4";
            title.Text = "osu!taiko SV Helper";
            artist.Text = "Unknown";
            version.Text = "Unknown";
            textBox1.Text = "0";
            startpoint.Text = "0";
            endpoint.Text = "0";
            MakeButton.Enabled = false;
            startpoint.Enabled = false;
            endpoint.Enabled = false;
            startButton.Enabled = false;
            endButton.Enabled = false;
            startSV.Enabled = false;
            endSV.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            snap.Enabled = false;
            button1.Enabled = false;
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            checkBox3.Enabled = false;
            textBox1.Enabled = false;
            button2.Enabled = false;
            comboBox1.SelectedIndex = 0;
            comboBox1.Enabled = false;
            int versionWidthfirst = version.Width;
            version.Location = new Point(408 - versionWidthfirst - 19, 2);
            pictureBox1.Image = Image.FromFile("./src/nobg.png");

            // タイマーを使って、0.1秒ごとに処理を実行します。
            // Intervalの中身を変更することで更新間隔を変更できます。Intervalはミリセカンドで指定します。(1000ms = 1s)
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 100;

            // タイマーの処理を記述します。
            timer.Tick += async (sender, e) =>
            {
                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        // gosumemoryからjson情報を取得します。
                        // リンクは"http://127.0.0.1:24050/json"です。
                        // ブラウザからではlocalhost:24050/jsonでもアクセスできます。
                        string url = "http://127.0.0.1:24050/json";
                        HttpResponseMessage response;
                        try
                        {
                            response = await client.GetAsync(url);
                        }
                        catch
                        {
                            title.Text = "osu!taiko SV Helper";
                            artist.Text = "Unknown";
                            version.Text = "Unknown";
                            MakeButton.Enabled = false;
                            startpoint.Enabled = false;
                            endpoint.Enabled = false;
                            startButton.Enabled = false;
                            endButton.Enabled = false;
                            startSV.Enabled = false;
                            endSV.Enabled = false;
                            textBox3.Enabled = false;
                            textBox4.Enabled = false;
                            snap.Enabled = false;
                            button1.Enabled = false;
                            checkBox1.Enabled = false;
                            checkBox2.Enabled = false;
                            checkBox3.Enabled = false;
                            textBox1.Enabled = false;
                            button2.Enabled = false;
                            comboBox1.Enabled = false;
                            int errorversionWidth = version.Width;
                            version.Location = new Point(408 - errorversionWidth - 19, 2);
                            pictureBox1.Image = Image.FromFile("./src/nobg.png");
                            return;
                        }

                        string json = await response.Content.ReadAsStringAsync();

                        // dataにjson情報を格納します。
                        JObject data = JsonConvert.DeserializeObject<JObject>(json);

                        // osu!を起動していない状態でgosumemoryが起動した時に表示されるエラーの処理です。
                        // エラー文はerrorというキーに格納されている""osu! is not fully loaded!"です。
                        if ((string)data["error"] == "osu! is not fully loaded!")
                        {
                            title.Text = "osu!taiko SV Helper";
                            artist.Text = "Unknown";
                            version.Text = "Unknown";
                            MakeButton.Enabled = false;
                            startpoint.Enabled = false;
                            endpoint.Enabled = false;
                            startButton.Enabled = false;
                            endButton.Enabled = false;
                            startSV.Enabled = false;
                            endSV.Enabled = false;
                            textBox3.Enabled = false;
                            textBox4.Enabled = false;
                            snap.Enabled = false;
                            button1.Enabled = false;
                            checkBox1.Enabled = false;
                            checkBox2.Enabled = false;
                            checkBox3.Enabled = false;
                            textBox1.Enabled = false;
                            button2.Enabled = false;
                            comboBox1.Enabled = false;
                            int errorversionWidth = version.Width;
                            version.Location = new Point(408 - errorversionWidth - 19, 2);
                            pictureBox1.Image = Image.FromFile("./src/nobg.png");
                            return;
                        }
                        else
                        {
                            startpoint.Enabled = true;
                            endpoint.Enabled = true;
                            startButton.Enabled = true;
                            endButton.Enabled = true;
                            startSV.Enabled = true;
                            endSV.Enabled = true;
                            textBox3.Enabled = true;
                            textBox4.Enabled = true;
                            snap.Enabled = !checkBox2.Checked;
                            button1.Enabled = true;
                            checkBox1.Enabled = true;
                            checkBox2.Enabled = true;
                            checkBox3.Enabled = true;
                            textBox1.Enabled = true;
                            comboBox1.Enabled = true;
                        }

                        // タイトル、アーティスト、バージョンをjsonから取得します。
                        string Title = (string)data["menu"]["bm"]["metadata"]["title"];
                        string Artist = (string)data["menu"]["bm"]["metadata"]["artist"];
                        string versiontext = (string)data["menu"]["bm"]["metadata"]["difficulty"];

                        // diffかタイトルが変わったら画像や曲情報を更新
                        if ((version.Text != versiontext) || (beforetitle != Title))
                        {
                            // ここでバックグラウンド画像のパスを取得します。
                            string backgroundPath =
                                $"{(string)data["settings"]["folders"]["songs"]}/{(string)data["menu"]["bm"]["path"]["full"]}";

                            // バックグラウンド画像ファイルが存在しない場合はnobg.pngを表示するようにしています。
                            if (!File.Exists(backgroundPath))
                            {
                                backgroundPath = "./src/nobg.png";
                            }

                            // 画像を読み込み、枠に合わせてリサイズします。
                            Bitmap bmp = new Bitmap(backgroundPath);

                            // リサイズする際に使う値です。
                            int resizeWidth = 408;

                            // resizeWidthの値に合わせてリサイズします。
                            // 画像の縦横比を維持したままリサイズするためです。
                            int resizeHeight = (int)(bmp.Height * ((double)resizeWidth / (double)bmp.Width));
                            Bitmap resizeBmp = new Bitmap(resizeWidth, resizeHeight);
                            Graphics g = Graphics.FromImage(resizeBmp);
                            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                            // リサイズされた画像を描画します。画像の中心を表示するために、縦の位置を調整しています。
                            // 102というのはpictureBox1の高さです。
                            g.DrawImage(bmp, 0, -((resizeHeight - 102) / 2), resizeWidth, resizeHeight);

                            // 画像を暗くするための係数
                            // 0.7にすると、画像が30%暗くなります。
                            // 0 ~ 1の間で指定してください。
                            double darknessFactor = 0.7;

                            // 画像を暗くする
                            for (int y = 0; y < resizeHeight; y++)
                            {
                                for (int x = 0; x < resizeWidth; x++)
                                {
                                    Color pixel = resizeBmp.GetPixel(x, y);
                                    int R = (int)(pixel.R * darknessFactor);
                                    int G = (int)(pixel.G * darknessFactor);
                                    int B = (int)(pixel.B * darknessFactor);
                                    Color darkPixel = Color.FromArgb(R, G, B);
                                    resizeBmp.SetPixel(x, y, darkPixel);
                                }
                            }

                            // 画像を表示
                            pictureBox1.Image = resizeBmp;
                            g.Dispose();
                        }

                        // パネルへartistとversionを追加します。
                        // versionとはDifficultyのことです。
                        artist.Text = $"{Artist}";
                        version.Text = $"{data["menu"]["bm"]["metadata"]["difficulty"]}";

                        // versionの位置を調整
                        // versionのテキストの幅を取得し、それに合わせて位置を調整します。
                        int versionWidth = version.Width;
                        version.Location = new Point(408 - versionWidth - 19, 2);

                        // タイトルを保存しておきます。
                        string beforetitleraw = Title;
                        beforetitle = beforetitleraw;

                        // タイトルが長すぎる場合に省略
                        // maxLabelWidthは表示したい最大幅のことです。
                        int maxLabelWidth = 380;
                        title.MaximumSize = new Size(maxLabelWidth, int.MaxValue);

                        // タイトルが最大幅を超える場合、切り詰めて"..."を追加します。
                        // 例えば、タイトルが
                        // "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"
                        // だとすると、"aaaaaaaaaaaaa..."となります。
                        if (TextRenderer.MeasureText(Title, title.Font).Width > maxLabelWidth)
                        {
                            while (TextRenderer.MeasureText(Title + "...", title.Font).Width > maxLabelWidth)
                            {
                                Title = Title.Substring(0, Title.Length - 1);
                            }

                            Title += "...";
                            title.Text = $"{Title}";
                        }
                        else
                        {
                            Title = $"{Title}";
                            title.Text = $"{Title}";
                        }
                    }
                    catch (Exception)
                    {
                        // 例外処理です。
                        title.Text = "osu!taiko SV Helper";
                        artist.Text = "Unknown";
                        version.Text = "Unknown";
                        MakeButton.Enabled = false;
                        startpoint.Enabled = false;
                        endpoint.Enabled = false;
                        startButton.Enabled = false;
                        endButton.Enabled = false;
                        startSV.Enabled = false;
                        endSV.Enabled = false;
                        textBox3.Enabled = false;
                        textBox4.Enabled = false;
                        snap.Enabled = false;
                        button1.Enabled = false;
                        checkBox1.Enabled = false;
                        checkBox2.Enabled = false;
                        checkBox3.Enabled = false;
                        textBox1.Enabled = false;
                        button2.Enabled = false;
                        comboBox1.Enabled = false;
                        int versionWidth = version.Width;
                        version.Location = new Point(408 - versionWidth - 19, 2);
                        pictureBox1.Image = Image.FromFile("./src/nobg.png");
                    }
                }
                StreamReader statusrawstring = new StreamReader("./status.txt", Encoding.GetEncoding("Shift_JIS"));
                String workingStatus = statusrawstring.ReadToEnd();
                statusrawstring.Close();

                if (workingStatus == "false")
                {
                    MakeButton.Enabled = true;
                    button2.Enabled = true;
                }

                if (workingStatus != statusCheck && statusCheck != null)
                {
                    statusCheck = workingStatus;
                    if (workingStatus == "true")
                    {
                        MakeButton.Enabled = false;
                        button2.Enabled = false;
                        MakeButton.Text = "作成中";
                    }
                    else if (workingStatus == "false")
                    {
                        MakeButton.Enabled = true;
                        MakeButton.Text = "作成";
                        button2.Enabled = true;
                        button2.Text = "取り消し";
                        if (errorFlag)
                        {
                            MessageBox.Show($"{errorText}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            errorFlag = false;
                        }
                        else
                        {
                            MessageBox.Show("操作が完了しました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else if (workingStatus == "undo")
                    {
                        MakeButton.Enabled = false;
                        button2.Enabled = false;
                        button2.Text = "取り消し中";
                    }
                    else if (workingStatus == "SC")
                    {
                        MakeButton.Enabled = true;
                        MakeButton.Text = "作成";
                        button2.Enabled = true;
                        button2.Text = "取り消し";
                        StreamWriter status = new StreamWriter("./status.txt", false, Encoding.GetEncoding("Shift_JIS"));
                        status.Write("false");
                        status.Close();
                        statusCheck = workingStatus;
                    }
                    else if (workingStatus == "NF") // ここからエラー関係の処理
                    {
                        MakeButton.Enabled = true;
                        button2.Enabled = true;
                        button2.Text = "取り消し";
                        errorFlag = true;
                        errorText = "バックアップが見つかりませんでした。";
                        StreamWriter status = new StreamWriter("./status.txt", false, Encoding.GetEncoding("Shift_JIS"));
                        status.Write("false");
                        status.Close();
                        statusCheck = workingStatus;
                    }
                    else if (workingStatus == "error")
                    {
                        MakeButton.Enabled = true;
                        button2.Enabled = true;
                        MakeButton.Text = "作成";
                        StreamReader errorrawstring = new StreamReader("./error.txt", Encoding.GetEncoding("Shift_JIS"));
                        string error = errorrawstring.ReadToEnd(); errorrawstring.Close();
                        errorFlag = true;
                        errorText = $"バックアップの復元中に予期せぬエラーが発生しました。\n{error}";
                        StreamWriter status = new StreamWriter("./status.txt", false, Encoding.GetEncoding("Shift_JIS"));
                        status.Write("false");
                        status.Close();
                        statusCheck = workingStatus;
                    }
                    else if (workingStatus == "sverror")
                    {
                        MakeButton.Enabled = true;
                        button2.Enabled = true;
                        MakeButton.Text = "作成";
                        StreamReader errorrawstring = new StreamReader("./error.txt", Encoding.GetEncoding("Shift_JIS"));
                        string error = errorrawstring.ReadToEnd(); errorrawstring.Close();
                        errorFlag = true;
                        errorText = $"SVの作成中に予期せぬエラーが発生したため自動的にバックアップから復元しました。\n{error}";
                        StreamWriter status = new StreamWriter("./status.txt", false, Encoding.GetEncoding("Shift_JIS"));
                        status.Write("false");
                        status.Close();
                        statusCheck = workingStatus;
                    }
                    else if (workingStatus == "svbackuperror")
                    {
                        MakeButton.Enabled = true;
                        button2.Enabled = true;
                        MakeButton.Text = "作成";
                        StreamReader errorrawstring = new StreamReader("./error.txt", Encoding.GetEncoding("Shift_JIS"));
                        string error = errorrawstring.ReadToEnd(); errorrawstring.Close();
                        errorFlag = true;
                        errorText = $"SVの作成中に予期せぬエラーが発生したため、自動的にバックアップから復元しようとしましたが復元できませんでした。\nBackupsフォルダからマップを探して拡張子を.osuに変更して手動で戻してください。\n{error}";
                        StreamWriter status = new StreamWriter("./status.txt", false, Encoding.GetEncoding("Shift_JIS"));
                        status.Write("false");
                        status.Close();
                        statusCheck = workingStatus;
                        string backupPath = AppDomain.CurrentDomain.BaseDirectory;
                        try
                        {
                            Process.Start("EXPLORER.EXE", $"{backupPath}Backups");
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Backupsフォルダを開くことができませんでした。\nフォルダにBackupsフォルダが無い可能性があります。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    statusCheck = workingStatus;
                }
            };
            timer.Start();
        }

        async private void MakeButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (double.Parse(startpoint.Text) <= 0)
                {
                    MessageBox.Show("開始地点の入力形式が間違っています。正の整数のみ入力可能です。", "入力形式エラー", MessageBoxButtons.OK);
                    startpoint.Text = "0";
                    return;
                }
                int.Parse(startpoint.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("開始地点の入力形式が間違っています。正の整数のみ入力可能です。", "入力形式エラー", MessageBoxButtons.OK);
                startpoint.Text = "0";
                return;
            }

            try
            {
                if (double.Parse(endpoint.Text) <= 0)
                {
                    MessageBox.Show("終了地点の入力形式が間違っています。正の整数のみ入力可能です。", "入力形式エラー", MessageBoxButtons.OK);
                    endpoint.Text = "0";
                    return;
                }
                int.Parse(endpoint.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("終了地点の入力形式が間違っています。正の整数のみ入力可能です。", "入力形式エラー", MessageBoxButtons.OK);
                endpoint.Text = "0";
                return;
            }

            try
            {
                if (double.Parse(startSV.Text) <= 0)
                {
                    MessageBox.Show("SV開始地点の入力形式が間違っています。正の整数のみ入力可能です。", "入力形式エラー", MessageBoxButtons.OK);
                    startSV.Text = "1.0";
                    return;
                }
                double.Parse(startSV.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("SV開始地点の入力形式が間違っています。正の整数のみ入力可能です。", "入力形式エラー", MessageBoxButtons.OK);
                startSV.Text = "1.0";
                return;
            }

            try
            {
                if (double.Parse(endSV.Text) <= 0)
                {
                    MessageBox.Show("SV終了地点の入力形式が間違っています。正の整数のみ入力可能です。", "入力形式エラー", MessageBoxButtons.OK);
                    startSV.Text = "1.0";
                    return;
                }
                double.Parse(endSV.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("SV終了地点の入力形式が間違っています。正の整数のみ入力可能です。", "入力形式エラー", MessageBoxButtons.OK);
                endSV.Text = "1.0";
                return;
            }

            try
            {
                Math.Round(double.Parse(textBox1.Text), 0);
                if (Math.Round(double.Parse(textBox1.Text), 0) > 0 && checkBox3.Checked)
                {
                    textBox1.Text = Math.Round(double.Parse("-" + textBox1.Text), 0).ToString();
                }
                else if (Math.Round(double.Parse(textBox1.Text), 0) < 0 && checkBox3.Checked)
                {
                    textBox1.Text = Math.Round(double.Parse(textBox1.Text), 0).ToString();
                }
                else if (Math.Round(double.Parse(textBox1.Text), 0) == 0)
                {
                    textBox1.Text = "0";
                }
                else
                {
                    textBox1.Text = Math.Round(double.Parse(textBox1.Text), 0).ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("オフセットの入力形式が間違っています。整数のみ入力可能です。", "入力形式エラー", MessageBoxButtons.OK);
                textBox1.Text = "0";
                return;
            }

            try
            {
                if (double.Parse(textBox3.Text) <= 0)
                {
                    MessageBox.Show("ボリューム開始地点の入力形式が間違っています。正の整数のみ入力可能です。", "入力形式エラー", MessageBoxButtons.OK);
                    textBox3.Text = "0";
                    return;
                }

                if (int.Parse(textBox3.Text) >= 100) textBox3.Text = "100";

                int.Parse(textBox3.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("ボリューム開始地点の入力形式が間違っています。正の整数のみ入力可能です。", "入力形式エラー", MessageBoxButtons.OK);
                textBox3.Text = "100";
                return;
            }

            try
            {
                if (double.Parse(textBox4.Text) <= 0)
                {
                    MessageBox.Show("ボリューム終了地点の入力形式が間違っています。正の整数のみ入力可能です。", "入力形式エラー", MessageBoxButtons.OK);
                    textBox4.Text = "0";
                    return;
                }

                if (int.Parse(textBox4.Text) >= 100) textBox4.Text = "100";


                int.Parse(textBox4.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("ボリューム終了地点の入力形式が間違っています。正の整数のみ入力可能です。", "入力形式エラー", MessageBoxButtons.OK);
                textBox4.Text = "100";
                return;
            }

            try
            {
                if (double.Parse(snap.Text) <= 0)
                {
                    MessageBox.Show("スナップの入力形式が間違っています。正の整数のみ入力可能です。", "入力形式エラー", MessageBoxButtons.OK);
                    snap.Text = "4";
                    return;
                }

                int.Parse(snap.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("スナップの入力形式が間違っています。正の整数のみ入力可能です。", "入力形式エラー", MessageBoxButtons.OK);
                snap.Text = "4";
                return;
            }

            // 必要なプロセスが起動しているか確認します。
            if (Process.GetProcessesByName("gosumemory").Length == 0)
            {
                MessageBox.Show("Gosumemoryプロセスが見つかりませんでした。再起動してもう一度試してみてください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Process.GetProcessesByName("osu!").Length == 0)
            {
                MessageBox.Show("osu!プロセスが見つかりませんでした。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (startpoint.Text == "" || endpoint.Text == "" || startSV.Text == "" || endSV.Text == "" ||
                textBox3.Text == "" || textBox4.Text == "" || snap.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("入力されていない項目があります。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (double.Parse(startSV.Text) == 0 || double.Parse(endSV.Text) == 0 ||
                     double.Parse(textBox3.Text) == 0 || double.Parse(textBox4.Text) == 0 ||
                     double.Parse(snap.Text) == 0)
            {
                MessageBox.Show("SV, ボリューム, スナップ欄に0を指定することはできません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (int.Parse(endpoint.Text) < int.Parse(startpoint.Text))
            {
                MessageBox.Show("終了時間が開始時間よりも小さいです。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (int.Parse(startpoint.Text) == 0 || int.Parse(endpoint.Text) == 0)
            {
                MessageBox.Show("開始時間と終了時間の両方を0にすることは出来ません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            startSV.Text = startSV.Text.Replace(",", ".");
            endSV.Text = endSV.Text.Replace(",", ".");

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // パスなどを取得し、osu!helper.jsに引数(パスやrate, bpmなど)を渡して起動します。
                    string url = "http://127.0.0.1:24050/json";
                    HttpResponseMessage response = null;
                    try
                    {
                        response = await client.GetAsync(url);
                    }
                    catch (Exception ex)
                    {
                        if (Process.GetProcessesByName("gosumemory").Length == 0)
                        {
                            MessageBox.Show("Gosumemoryプロセスが見つかりませんでした。再起動してもう一度試してみてください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            MessageBox.Show($"データの取得に失敗しました。再起動してもう一度試してみてください。\nエラー内容: {ex}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    string writemode;
                    if (comboBox1.SelectedIndex == 0)
                    {
                        writemode = "0";
                    }
                    else if (comboBox1.SelectedIndex == 1)
                    {
                        writemode = "1";
                    }
                    else　if (comboBox1.SelectedIndex == 2)
                    {
                        writemode = "2";
                    }
                    else
                    {
                        writemode = "3";
                    }

                    string json = await response.Content.ReadAsStringAsync();
                    JObject data = JsonConvert.DeserializeObject<JObject>(json);

                    string songsfolder = (string)data["settings"]["folders"]["songs"];
                    string folderpath = (string)data["menu"]["bm"]["path"]["folder"];
                    string filename = (string)data["menu"]["bm"]["path"]["file"];

                    string kiaibool = checkBox1.Checked ? "1" : "0";
                    string grbool = checkBox2.Checked ? "1" : "0";
                    string SVoffset = textBox1.Text;

                    // osu!helper.jsを起動します。
                    osuhelper = new Process();
                    osuhelper.StartInfo.FileName = "\"./src/nodejs/node.exe\"";
                    osuhelper.StartInfo.Arguments = $"\"./osu!helper.js\" \"{songsfolder}\" \"{folderpath}\" \"{filename}\" \"{startpoint.Text}\" \"{endpoint.Text}\" \"{startSV.Text}\" \"{endSV.Text}\" \"{textBox3.Text}\" \"{textBox4.Text}\" \"{snap.Text}\" \"{kiaibool}\" \"{grbool}\" \"{SVoffset}\" \"{writemode}\"";
                    osuhelper.StartInfo.CreateNoWindow = true;
                    osuhelper.StartInfo.UseShellExecute = false;
                    osuhelper.Start();
                }
                catch (Exception ex)
                {
                    // 作成ボタンを無効にし、エラーを表示します。
                    MakeButton.Enabled = false;
                    MakeButton.Text = "エラー";
                    MessageBox.Show($"osu!helper.jsを起動しようとした際にエラーが発生しました。\nエラー内容 : {ex}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        async private void startButton_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // パスなどを取得し、osu!trainer.jsに引数(パスやrate, bpmなど)を渡して起動します。
                    string url = "http://127.0.0.1:24050/json";
                    HttpResponseMessage response;
                    try
                    {
                        response = await client.GetAsync(url);
                    }
                    catch
                    {
                        MessageBox.Show("データの取得に失敗しました。gosumemoryが起動していなければ、再起動してもう一度試してください。", "エラー",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string json = await response.Content.ReadAsStringAsync();
                    JObject data = JsonConvert.DeserializeObject<JObject>(json);

                    string currenttime = (string)data["menu"]["bm"]["time"]["current"];
                    startpoint.Text = currenttime;
                }
                catch (Exception)
                {
                    return;
                }
            }
        }

        async private void endButton_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // パスなどを取得し、osu!trainer.jsに引数(パスやrate, bpmなど)を渡して起動します。
                    string url = "http://127.0.0.1:24050/json";
                    HttpResponseMessage response;
                    try
                    {
                        response = await client.GetAsync(url);
                    }
                    catch
                    {
                        MessageBox.Show("データの取得に失敗しました。gosumemoryが起動していなければ、再起動してもう一度試してください。", "エラー",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string json = await response.Content.ReadAsStringAsync();
                    JObject data = JsonConvert.DeserializeObject<JObject>(json);

                    string currenttime = (string)data["menu"]["bm"]["time"]["current"];
                    endpoint.Text = currenttime;
                }
                catch (Exception)
                {
                    return;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            startpoint.Text = "0";
            endpoint.Text = "0";
            textBox3.Text = "100";
            textBox4.Text = "100";
            startSV.Text = "1.0";
            endSV.Text = "1.0";
            snap.Text = "4";
            textBox1.Text = "0";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
        }

        async private void button2_Click(object sender, EventArgs e)
        {
            // 必要なプロセスが起動しているか確認します。
            if (Process.GetProcessesByName("gosumemory").Length == 0)
            {
                MessageBox.Show("Gosumemoryプロセスが見つかりませんでした。再起動してもう一度試してみてください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Process.GetProcessesByName("osu!").Length == 0)
            {
                MessageBox.Show("osu!プロセスが見つかりませんでした。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // パスなどを取得し、osu!helper.jsに引数(パスやrate, bpmなど)を渡して起動します。
                    string url = "http://127.0.0.1:24050/json";
                    HttpResponseMessage response = null;
                    try
                    {
                        response = await client.GetAsync(url);
                    }
                    catch (Exception ex)
                    {
                        if (Process.GetProcessesByName("gosumemory").Length == 0)
                        {
                            MessageBox.Show("Gosumemoryプロセスが見つかりませんでした。再起動してもう一度試してみてください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            MessageBox.Show($"データの取得に失敗しました。再起動してもう一度試してみてください。\nエラー内容: {ex}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    string json = await response.Content.ReadAsStringAsync();
                    JObject data = JsonConvert.DeserializeObject<JObject>(json);

                    string songsfolder = (string)data["settings"]["folders"]["songs"];
                    string folderpath = (string)data["menu"]["bm"]["path"]["folder"];
                    string filename = (string)data["menu"]["bm"]["path"]["file"];

                    // undo.jsを起動します。
                    undoSoftware = new Process();
                    undoSoftware.StartInfo.FileName = "\"./src/nodejs/node.exe\"";
                    undoSoftware.StartInfo.Arguments = $"\"./undo.js\" \"{songsfolder}\" \"{folderpath}\" \"{filename}\"";
                    undoSoftware.StartInfo.CreateNoWindow = true;
                    undoSoftware.StartInfo.UseShellExecute = false;
                    undoSoftware.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"osu!helper.jsを起動しようとした際にエラーが発生しました。\nエラー内容 : {ex}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            snap.Enabled = !checkBox2.Checked;
        }
    }
}
