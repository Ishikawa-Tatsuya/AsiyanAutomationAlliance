using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Dynamic;
using System.Diagnostics;
using Codeer.Friendly.Windows.Grasp;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using Ong.Friendly.FormsStandardControls;
using System.Linq;
using RM.Friendly.WPFStandardControls;
using Codeer.Friendly;
using Codeer.Friendly.Windows.NativeStandardControls;

namespace Tips
{
    [TestClass]
    public class ChildControl
    {
        [TestMethod]
        public void WinForms()
        {
            var app = new WindowsAppFriend(Process.Start("WinForms.exe"));
            var mainForm = app.Type().System.Windows.Forms.Application.OpenForms[0];

            //WinFormsの場合は変数名で取りましょう。
            var _buttonX = new FormsButton(mainForm._buttonX);
            _buttonX.EmulateClick();

            //ポップアップメニューも変数からとる
            var _toolStripMenuItemA = new FormsToolStripItem(mainForm._toolStripMenuItemA);
            _toolStripMenuItemA.EmulateClick();

            //とは言え、取れないときも
            //そんなときは工夫する
            WindowsAppExpander.LoadAssembly(app, GetType().Assembly);
            var button名無し = new FormsButton(app.Type().Tips.ChildControl.Get名無し(mainForm));
            button名無し.EmulateClick();

            //メニューアイテムも上位ライブラリ使えばインデックスとかテキストから取れたり
            var menu = new FormsToolStrip(mainForm._contextMenuStrip);
            var b = menu.FindItem("B");
            b.EmulateClick();

            Process.GetProcessById(app.ProcessId).Kill();
        }

        static System.Windows.Forms.Button Get名無し(System.Windows.Forms.Form form)
        {
            return form.Controls.Cast<System.Windows.Forms.Control>().Where(e => e.Text == "名無し").Single() as System.Windows.Forms.Button;
        }

        [TestMethod]
        public void WPF()
        {
            var app = new WindowsAppFriend(Process.Start("Wpf.exe"));
            var window = app.Type().System.Windows.Application.Current.MainWindow;

            //ガタガタ言わずにx:Name使えばいいじゃん。
            var _textBox = new WPFTextBox(window._textBox);
            _textBox.EmulateChangeText("x:Name最高！");

            //嫌って言う人いるから頑張ったよ。
            AppVar windowAppVar = window;
            var logicalTree = windowAppVar.LogicalTree();
            var textBox = new WPFTextBox(logicalTree.ByBinding("Memo").ByType<System.Windows.Controls.TextBox>().Single());
            var textBlock = new WPFTextBlock(logicalTree.ByBinding("Memo").ByType<System.Windows.Controls.TextBlock>().Single());
            var buttonModal = new WPFButtonBase(logicalTree.ByBinding("CommandModal").Single());
            var buttonModalSequential = new WPFButtonBase(logicalTree.ByBinding("CommandModalSequential").Single());
            var buttonModeless = new WPFButtonBase(logicalTree.ByBinding("CommandModeless").Single());
            var listBox = new WPFListBox(logicalTree.ByBinding("Persons").Single());

            //VisualTreeにしか現れない要素は気を付けて
            var item = listBox.GetItem(20);
            var itemText = new WPFTextBlock(item.VisualTree().ByBinding("Name").Single());

            //これでもダメな場合は工夫してね！

            Process.GetProcessById(app.ProcessId).Kill();
        }

        [TestMethod]
        public void Win32()
        {
            var app = new WindowsAppFriend(Process.Start(Path.GetFullPath("../../../MFCDlg.exe")));
            var dlg = WindowControl.IdentifyFromWindowText(app, "MFCDlg");

            //ダイアログID
            const int IDOK = 1;
            const int IDCANCEL = 2;
            const int IDC_EDIT_SAMPLE = 1000;
            var buttonOK = new NativeButton(dlg.IdentifyFromDialogId(IDOK));
            var buttonCancel = new NativeButton(dlg.IdentifyFromDialogId(IDCANCEL));
            var editSample = new NativeEdit(dlg.IdentifyFromDialogId(IDC_EDIT_SAMPLE));
            editSample.EmulateChangeText("abc");

            //WindowText
            buttonOK = new NativeButton(dlg.IdentifyFromWindowText("OK"));

            //Windowクラス
            editSample = new NativeEdit(dlg.IdentifyFromWindowClass("Edit"));

            Process.GetProcessById(app.ProcessId).Kill();
        }

        //結局開発側と協力して最適な取得方法を確立しておくことが重要
    }
}
