using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Dynamic;
using System.Diagnostics;
using Codeer.Friendly.Windows.Grasp;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using Ong.Friendly.FormsStandardControls;
using RM.Friendly.WPFStandardControls;
using Codeer.Friendly;

namespace Tips
{
    [TestClass]
    public class 画面遷移
    {
        [TestMethod]
        public void Wpf()
        {
            var app = new WindowsAppFriend(Process.Start("Wpf.exe"));
            AppVar window = app.Type().System.Windows.Application.Current.MainWindow;
            var logicalTree = window.LogicalTree();
            var buttonModal = new WPFButtonBase(logicalTree.ByBinding("CommandModal").Single());
            var buttonModeless = new WPFButtonBase(logicalTree.ByBinding("CommandModeless").Single());

            //モーダレスは通常はそのままでＯＫ
            buttonModeless.EmulateClick();
            var next = app.Type().System.Windows.Application.Current.Windows[1];
            next.Title = "aaa";

            //でもたまに変なことしているやつがいれば注意
            //まあ、こっち使った方が無難
            var nextW = WindowControl.WaitForIdentifyFromWindowText(app, "aaa");
            nextW.Dynamic().Close();

            //モーダルは要注意
            var current = new WindowControl(window);

            {
                var a = new Async();
                buttonModal.EmulateClick(a);
                var modal = current.WaitForNextModal();
                modal.Dynamic().Close();
                a.WaitForCompletion();
            }

            //連続で出るやつはもっと注意
            var buttonModalSequential = new WPFButtonBase(logicalTree.ByBinding("CommandModalSequential").Single());
            {
                var a = new Async();
                buttonModalSequential.EmulateClick(a);

                var modal1 = current.WaitForNextModal();
                modal1.Dynamic().Close();
                modal1.WaitForDestroy();

                var modal2 = current.WaitForNextModal();
                modal2.Dynamic().Close();
                modal2.WaitForDestroy();

                a.WaitForCompletion();
            }

            Process.GetProcessById(app.ProcessId).Kill();
        }
    }
}
