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

namespace Tips
{
    [TestClass]
    public class 弱いコントロール
    {
        [TestMethod]
        public void WinForms()
        {
            var app = new WindowsAppFriend(Process.Start("WinForms.exe"));
            var form = app.Type().System.Windows.Forms.Application.OpenForms[0];
            WindowsAppExpander.LoadAssembly(app, GetType().Assembly);

            var _grid = form._grid;
            _grid.CurrentCell = _grid[0, 0];
            app.Type(GetType()).Edit(_grid, "abc");

            var wrap = new FormsDataGridView(_grid);
            wrap.EmulateChangeCellText(0, 1, "xyz");

            Process.GetProcessById(app.ProcessId).Kill();
        }

        static void Edit(DataGridView grid, string text)
        {
            grid.BeginEdit(false);
            grid.EditingControl.Text = text;
            grid.EndEdit();
        }
    }
}
