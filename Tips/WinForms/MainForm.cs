using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            var b = new Button() { Text = "名無し" , Top = _buttonX.Bottom + 10, Left = _buttonX.Left };
            b.Click += delegate { Text = "名無し"; };
            Controls.Add(b);
        }

        private void _buttonX_Click(object sender, EventArgs e)
        {
            Text = "X";
        }

        private void _toolStripMenuItemA_Click(object sender, EventArgs e)
        {
            Text = "A";
        }

        private void _toolStripMenuItemB_Click(object sender, EventArgs e)
        {
            Text = "B";
        }

        private void _toolStripMenuItemC_Click(object sender, EventArgs e)
        {
            Text = "C";
        }

        private void _buttonFile_Click(object sender, EventArgs a)
        {
            var dlg = new OpenFileDialog();
            if (dlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var lines = File.ReadAllLines(dlg.FileName);
            int count = 0;
            foreach (var e in lines)
            {
                if (e == "a")
                {
                    count++;
                }
            }
            Text = count.ToString();
        }
    }
}
