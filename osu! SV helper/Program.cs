using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace osu__SV_helper
{
    internal static class Program
    {
        private static Process gosumemory;
        [STAThread]
        static void Main()
        {
            if (Process.GetProcessesByName("gosumemory").Length == 0)
            {
                try
                {
                    if (!System.IO.File.Exists("./src/gosumemory/gosumemory.exe"))
                    {
                        DialogResult result = MessageBox.Show("Gosumemoryがフォルダ内から見つかりませんでした。\nGithubからダウンロードしますか？", "エラー", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                        if (result == DialogResult.Yes)
                        {
                            //webブラウザでダウンロードページを開く
                            MessageBox.Show("ダウンロードページをwebブラウザで開きます。\nインストール方法: ダウンロードしたフォルダを開き、osu!trainer/src/gosumemory/gosumemory.exeとなるように配置する。", "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Process.Start("https://github.com/l3lackShark/gosumemory/releases/");
                            return;
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Gosumemoryの起動に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            System.Globalization.CultureInfo.CurrentCulture = new System.Globalization.CultureInfo("en-us");
            System.Globalization.CultureInfo.CurrentUICulture = new System.Globalization.CultureInfo("en-us");

            //launch gosumemory
            gosumemory = new Process();
            gosumemory.StartInfo.FileName = "./src/gosumemory/gosumemory.exe";
            gosumemory.StartInfo.CreateNoWindow = true;
            gosumemory.StartInfo.UseShellExecute = false;
            gosumemory.Start();

            Application.ApplicationExit += Application_ApplicationExit;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            gosumemory.Kill();
        }
    }
}
