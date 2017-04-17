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
    public partial class addvoacbForm : Form
    {
        public addvoacbForm()
        {
            InitializeComponent();
            if (!File.Exists("VocabData"))
            {
                Directory.CreateDirectory(@"VocabData");
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string text = "";

            try
            {
                text = File.ReadAllText(@"VocabData\Data.txt", Encoding.GetEncoding("UTF-8"));
                text += Environment.NewLine + textBox1.Text + " " + textBox2.Text;
                File.WriteAllText(@"VocabData\Data.txt", text, Encoding.GetEncoding("UTF-8"));
            }
            catch
            {
                Directory.CreateDirectory(@"VocabData");
                File.WriteAllText(@"VocabData\Data.txt", "One" + " " + "หนึ่ง", Encoding.GetEncoding("UTF-8"));
                text = File.ReadAllText(@"VocabData\Data.txt", Encoding.GetEncoding("UTF-8"));
                text += Environment.NewLine + textBox1.Text + " " + textBox2.Text;
                File.WriteAllText(@"VocabData\Data.txt", text, Encoding.GetEncoding("UTF-8"));
            }
            finally
            {
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }
    }
}
