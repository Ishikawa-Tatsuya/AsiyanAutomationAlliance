using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Dynamic;
using System.Diagnostics;
using Codeer.Friendly.Windows.Grasp;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace Tips
{
    [TestClass]
    public class TopLevelWindow
    {
        [TestMethod]
        public void WinForms()
        {
            var app = new WindowsAppFriend(Process.Start("WinForms.exe"));

            //System.Windows.Forms.Application.OpenForms
            var form = app.Type().System.Windows.Forms.Application.OpenForms[0];
            form.Text = "取れたよ";

            //複数個開いている場合
            {
                var form2 = app.Type().System.Windows.Forms.Form();
                form2.Text = "2";
                form2.Show();
            }

            //実はforeachできます。
            //Linqは無理ですけどね。
            foreach (var f in app.Type().System.Windows.Forms.Application.OpenForms)
            {
                string title = f.Text;
                if (title == "2")
                {
                    f.Text = "これも取れた";
                    break;
                }
            }

            //WindowControlの検索関数を使ってみる
            var main = WindowControl.IdentifyFromTypeFullName(app, "WinForms.MainForm");
            main.Dynamic().Text = "ほらね。";

            var second = WindowControl.IdentifyFromWindowText(app, "これも取れた");
            second.Dynamic().Text = "バッチリ。";

            //WaitFor 
            //取れるまで待つ
            Task.Factory.StartNew(() => 
            {
                Thread.Sleep(10000);
                var form3 = app.Type().System.Windows.Forms.Form();
                form3.Text = "3";
                form3.Show();
            });
            var third = WindowControl.WaitForIdentifyFromWindowText(app, "3");

            //Get
            //複数あった場合、複数とれる
            var many = WindowControl.GetFromTypeFullName(app, "System.Windows.Forms.Form");
            Assert.AreEqual(2, many.Length);

            Process.GetProcessById(app.ProcessId).Kill();
        }

        [TestMethod]
        public void WPF()
        {
            //WinFormsと使うAPIは違うけど、考え方は同じ
            var app = new WindowsAppFriend(Process.Start("Wpf.exe"));

            //System.Windows.Application.Current.MainWindow
            var window = app.Type().System.Windows.Application.Current.MainWindow;
            window.Title = "取れたよ";

            //複数個開いている場合
            {
                var window2 = app.Type().System.Windows.Window();
                window2.Title = "2";
                window2.Show();
            }

            //実はforeachできます。
            //Linqは無理ですけどね。
            foreach (var f in app.Type().System.Windows.Application.Current.Windows)
            {
                string title = f.Title;
                if (title == "2")
                {
                    f.Title = "これも取れた";
                    break;
                }
            }

            //WindowControlの検索関数を使ってみる
            var main = WindowControl.IdentifyFromTypeFullName(app, "Wpf.MainWindow");
            main.Dynamic().Title = "ほらね。";

            var second = WindowControl.IdentifyFromWindowText(app, "これも取れた");
            second.Dynamic().Title = "バッチリ。";

            //WaitFor 
            //取れるまで待つ
            Task.Factory.StartNew(() =>
            {
                var window3 = app.Type().System.Windows.Window();
                window3.Title = "3";
                window3.Show();
            });
            var third = WindowControl.WaitForIdentifyFromWindowText(app, "3");

            //Get
            //複数あった場合、複数とれる
            var many = WindowControl.GetFromTypeFullName(app, "System.Windows.Window");
            Assert.AreEqual(2, many.Length);

            Process.GetProcessById(app.ProcessId).Kill();
        }

        [TestMethod]
        public void Win32()
        {
            var app = new WindowsAppFriend(Process.Start(Path.GetFullPath("../../../MFCDlg.exe")));

            //Win32の場合はWindowControlを使うのが現実的
            //もちろん自分でWin32APIを駆使して見つけることも可能
            var w = WindowControl.IdentifyFromWindowText(app, "MFCDlg");
            
            Process.GetProcessById(app.ProcessId).Kill();
        }

        //最終的には、開発チームと連携して、確実な取得方法を決めておけばＯＫ
    }
}
