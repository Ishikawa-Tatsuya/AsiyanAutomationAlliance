using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Dynamic;
using System.Diagnostics;
using Codeer.Friendly.Windows.Grasp;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Ong.Friendly.FormsStandardControls;
using System.Runtime.InteropServices;
using Codeer.Friendly.Windows.NativeStandardControls;
using Codeer.Friendly;

namespace Tips
{
    [TestClass]
    public class 知らない画面は避ける
    {
        [TestMethod]
        public void Friendlyなめんなよ()
        {
            var app = new WindowsAppFriend(Process.Start("WinForms.exe"));
            var form = app.Type().System.Windows.Forms.Application.OpenForms[0];
            WindowsAppExpander.LoadAssembly(app, GetType().Assembly);

            var button = new FormsButton(form._buttonFile);
            var a = new Async();
            button.EmulateClick(a);
            var dlg = new WindowControl(form).WaitForNextModal();

            OpenFile(dlg, @"c:\TestData\data.txt");

            a.WaitForCompletion();
            Process.GetProcessById(app.ProcessId).Kill();
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);

        static void OpenFile(WindowControl fileDialog, string path)
        {
            //ボタン取得
            var buttonOpen = new NativeButton(fileDialog.IdentifyFromWindowText("開く(&O)"));

            //コンボボックスは二つある場合がある。
            //下の方を採用。
            var comboBoxPathSrc = fileDialog.GetFromWindowClass("ComboBoxEx32").OrderBy(e =>
            {
                RECT rc;
                GetWindowRect(e.Handle, out rc);
                return rc.Top;
            }).Last();
            var comboBoxPath = new NativeComboBox(comboBoxPathSrc);

            //パスを設定
            comboBoxPath.EmulateChangeEditText(path);

            //開くボタンを押す
            buttonOpen.EmulateClick();
        }
    }
}
