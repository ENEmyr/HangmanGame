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
    public partial class gameForm : Form
    {

        int score = 0;
        int win_point = 0;
        int death_point = 0;
        char[] checkans;
        string[] vocab = new string[100];
        int vocabVal;
        public gameForm()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void click_check(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string btnText = btn.Text;
            if (checkval(btnText)) btn.Enabled = false;
        }
        private void val_init()
        {
            int n = 0;
            string[] textArray = File.ReadAllText(@"VocabData\Data.txt", Encoding.GetEncoding("UTF-8")).Split();
            char[] alphabet_T = new char[26];
            string[] meaning = new string[100];
            for (int i = 0; i < alphabet_T.Length; i++) alphabet_T[i] = (char)(97 + i);

            for (int i = 0; i < textArray.Length - 1; i += 3)
            {
                vocab[n] = textArray[i];
                meaning[n] = textArray[i + 1];
                n++;
            }
            Random _r = new Random();
            int Vocab_randNum = _r.Next(n);
            vocabVal = Vocab_randNum;
            char[] Char_Vocab = vocab[Vocab_randNum].ToCharArray();//แยกศัพท์ที่สุ่มได้เป็น char ใส่ Array
            int space_text_num = _r.Next(1, Char_Vocab.Length - 1); //จำนวนช่องว่างในเกม
            int[] specific_num = new int[Char_Vocab.Length]; // Array เก็บ index ของ char ที่ห้ามใช้ซ้ำ
            for (int i = 0; i < Char_Vocab.Length; i++)
            {
                for (int j = 0; j < alphabet_T.Length; j++)
                {
                    if (Char_Vocab[i] == alphabet_T[j]) specific_num[i] = j; //เปรียบเทียบกับ Array Alphabet ทุกตัวตัวไหนซ้ำ return index ใส่ specific_num
                }
            }
            int[] disap = RandNumButt(specific_num, space_text_num, alphabet_T);
            char[] alp = new char[disap.Length];
            var s = Char_Vocab.Except(alp);
            string show = "";
            for (int i = 0; i < disap.Length; i++)
            {
                alp[i] = alphabet_T[disap[i]];
                win_point++;
            }
            checkans = alp;
            foreach (char sx in s)
            {
                show += sx;
            }
            textBox1.Text = show;
            label2.Text = "คำแปล : " + meaning[Vocab_randNum];

        }

        private void nextS_Click(object sender, EventArgs e)
        {
            label1.Text = "Score : " + score.ToString();
            alphabet_but1.Enabled = true;
            alphabet_but2.Enabled = true;
            alphabet_but3.Enabled = true;
            alphabet_but4.Enabled = true;
            alphabet_but5.Enabled = true;
            alphabet_but6.Enabled = true;
            alphabet_but7.Enabled = true;
            alphabet_but8.Enabled = true;
            alphabet_but9.Enabled = true;
            alphabet_but10.Enabled = true;
            alphabet_but11.Enabled = true;
            alphabet_but12.Enabled = true;
            label7.Visible = false;
            label8.Visible = false;
            textBox1.Text = "Vocabulary";
            label2.Text = "คำแปล : ";
            win_point = 0;
            death_point = 0;
            pictureBox1.Load(@"image\hang" + death_point + ".png");
            if (score != 0)
            {
                nextS.Text = "Next Stage";
            }
            val_init();
            nextS.Visible = false;

        }
        private int[] RandNumButt(int[] param1, int param2, char[] param3)
        {
            int countnotS = 0;
            int count = 0;
            int[] unionArray = new int[12];
            int[] notS = new int[param2];
            Random _r = new Random();
            HashSet<int> hash = new HashSet<int>();
            while (hash.Count() < param2)
            {
                hash.Add(_r.Next(0, param1.Length));
            }
            foreach (int item in hash)
            {
                notS[countnotS] = param1[item]; //index char ของคำตอบ
                countnotS++;
            }
            int[] num_count = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 };
            IEnumerable<int> aOnlyNumbers = num_count.Except(notS);
            foreach (var t in aOnlyNumbers)
            {
                count++;
            }
            int[] butt_left_rand = new int[12 - param2];
            count = 0;
            var arg = CreateShuffledDeck(aOnlyNumbers, 12 - param2);
            while (arg.Count > 0)
            {
                var number = arg.Pop();
                butt_left_rand[count] = number; //index char ของ button ที่เหลือ
                count++;
            }
            count = 0;
            IEnumerable<int> union = butt_left_rand.Union(notS);
            var arg2 = CreateShuffledDeck(union, 12);
            while (arg2.Count > 0)
            {
                var number = arg2.Pop();
                unionArray[count] = number; //index char ของ button ที่เหลือ
                count++;
            }
            for (int i = 0; i < unionArray.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        alphabet_but1.Text = param3[unionArray[i]].ToString();
                        break;
                    case 1:
                        alphabet_but2.Text = param3[unionArray[i]].ToString();
                        break;
                    case 2:
                        alphabet_but3.Text = param3[unionArray[i]].ToString();
                        break;
                    case 3:
                        alphabet_but4.Text = param3[unionArray[i]].ToString();
                        break;
                    case 4:
                        alphabet_but5.Text = param3[unionArray[i]].ToString();
                        break;
                    case 5:
                        alphabet_but6.Text = param3[unionArray[i]].ToString();
                        break;
                    case 6:
                        alphabet_but7.Text = param3[unionArray[i]].ToString();
                        break;
                    case 7:
                        alphabet_but8.Text = param3[unionArray[i]].ToString();
                        break;
                    case 8:
                        alphabet_but9.Text = param3[unionArray[i]].ToString();
                        break;
                    case 9:
                        alphabet_but10.Text = param3[unionArray[i]].ToString();
                        break;
                    case 10:
                        alphabet_but11.Text = param3[unionArray[i]].ToString();
                        break;
                    case 11:
                        alphabet_but12.Text = param3[unionArray[i]].ToString();
                        break;
                }
            }
            return notS;
        }
        private static Stack<T> CreateShuffledDeck<T>(IEnumerable<T> values, int num)
        {
            var rand = new Random();

            var list = new List<T>(values);
            var stack = new Stack<T>();

            for (int i = 0; i < num; i++)
            {
                // Get the next item at random.
                var index = rand.Next(0, list.Count);
                var item = list[index];

                // Remove the item from the list and push it to the top of the deck.
                list.RemoveAt(index);
                stack.Push(item);
            }
            return stack;
        }
        private bool checkval(string x)
        {
            bool resu = true;
            foreach (char c in checkans)
            {
                if (c.ToString() == x)
                {
                    score++;
                    label1.Text = "Score : "+score.ToString();
                    win_point--;
                    resu = false;
                }
            }
            if (resu)
            {
                if(death_point < 9)
                {
                    death_point++;
                    pictureBox1.Load(@"image\hang" + death_point + ".png");
                }
                else
                {
                    death_point++;
                    pictureBox1.Load(@"image\hang" + death_point + ".png");
                    lose();
                }
            }
            if (win_point == 0) win();
            return true;
        }
        private void lose()
        {
            score = 0;
            label7.Visible = true;
            nextS.Visible = true;
        }
        private void win()
        {
            textBox1.Text = vocab[vocabVal];
            label8.Visible = true;
            nextS.Visible = true;
        }
    }
}
