using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;

namespace DSLauncherV2
{
    public partial class SortAccounts : MetroFramework.Forms.MetroForm
    {
        private Regex ValueRegex = new Regex(@"[0-9]+");
        public List<DataGridViewRow> rows = new List<DataGridViewRow>();
        private string start = "";

        public SortAccounts()
        {
            InitializeComponent();
        }

        public SortAccounts(string name, string desc, string cat, string code, string sig)
        {
            InitializeComponent();
            this.SortAlphabeticallyButton.Enabled = false;
        }

        private void metroGrid1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (!ValueRegex.Match(metroGrid1.Rows[e.RowIndex].Cells[6].Value.ToString()).Success)
            {
                metroGrid1.Rows[e.RowIndex].Cells[6].Value = start;
                return;
            }

            BeginInvoke(new MethodInvoker(() =>
            {
                rows.Clear();
                foreach (DataGridViewRow i in metroGrid1.Rows)
                {
                    rows.Add(i);
                }

                metroGrid1.Rows.Clear();
                rows = rows.OrderBy(x => x.Cells[6].Value.ToString()).ToList();
                foreach (var i in rows)
                    metroGrid1.Rows.Add(i);
                metroGrid1.Visible = false;
                metroGrid1.Visible = true;
            }));
        }

        private void metroGrid1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            start = metroGrid1.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void SortAlphabeticallyButton_Click(object sender, EventArgs e)
        {
            BeginInvoke(new MethodInvoker(() =>
            {
                rows.Clear();
                int index = 0;
                foreach (DataGridViewRow i in metroGrid1.Rows)
                {
                    rows.Add(i);
                }

                foreach (var i in rows.OrderBy(x => x.Cells[0].Value.ToString()))
                {
                    i.Cells[6].Value = index;
                    index++;
                }

                metroGrid1.Rows.Clear();
                rows = rows.OrderBy(x => int.Parse(x.Cells[6].Value.ToString())).ToList();
                foreach (var i in rows)
                    metroGrid1.Rows.Add(i);
                metroGrid1.Visible = false;
                metroGrid1.Visible = true;
            }));
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SortCategory_Click(object sender, EventArgs e)
        {
            BeginInvoke(new MethodInvoker(() =>
            {
                rows.Clear();
                int index = 0;
                foreach (DataGridViewRow i in metroGrid1.Rows)
                {
                    rows.Add(i);
                }

                foreach (var i in rows.OrderBy(x => x.Cells[2].Value.ToString()).ThenBy(x => x.Cells[0].Value.ToString()))
                {
                    i.Cells[6].Value = index;
                    index++;
                }

                metroGrid1.Rows.Clear();
                rows = rows.OrderBy(x => int.Parse(x.Cells[6].Value.ToString())).ToList();
                foreach (var i in rows)
                    metroGrid1.Rows.Add(i);
                metroGrid1.Visible = false;
                metroGrid1.Visible = true;
            }));
        }
    }

    public static class Prompt
    {
        public static string ShowDialog(string text)
        {
            MetroForm prompt = new MetroForm
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterScreen,
                Theme = MetroThemeStyle.Dark,
                ShowInTaskbar = false,
                MinimizeBox = false,
                MaximizeBox = false
            };
            MetroLabel textLabel = new MetroLabel() { Left = 50, Top = 20, Text = text, Width = 400, Theme = MetroThemeStyle.Dark };
            MetroTextBox textBox = new MetroTextBox() { Left = 50, Top = 50, Width = 400, Theme = MetroThemeStyle.Dark };
            MetroButton confirmation = new MetroButton() { Text = "Confirm", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK, Theme = MetroThemeStyle.Dark };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
}
