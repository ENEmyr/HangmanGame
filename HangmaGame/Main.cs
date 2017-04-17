using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace HangmaGame
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            gameForm f = new gameForm();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void addvocabButton_Click(object sender, EventArgs e)
        {
            addvoacbForm f = new addvoacbForm();
            f.ShowDialog();
            this.Show();

        }
    }
}
