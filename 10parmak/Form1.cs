using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Channels;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _10parmak
{
    public partial class Form1 : Form
    {
        List<Button> b = new List<Button>();
        
        int j = 0;
        int lastV;
        int counter = 0;

        public Form1()
        {
            InitializeComponent();
            LoadCheckBoxValue();
            if (!checkBox2.Checked) label1.Visible = false;
            label1.Font = new Font(label1.Font.FontFamily, 9);

            // Combo Box
            listBox1.Font = new Font(listBox1.Font.FontFamily, 14);
            foreach (Control item in Controls)
            {
                if (item is Button)
                {
                    Button B = (Button)item;
                    b.Add(B);
                    comboBox1.Items.Add(B.Text);
                }
            }
            comboBox1.Sorted = true;
        }

        public void Shuffle(char[] chars, int start, int end)
        {
            if (listBox1.Items.Count > 1) listBox1.Items.Clear();
            Random r = new Random();
            StringBuilder sb = new StringBuilder();
            int counter = 0;



            for (int i = 0; i < 10; i++) // adet
            {
                for (int j = 0; counter < r.Next(start, end); j++) // rastgele oluşturulsun
                {
                    sb.Append(chars[r.Next(0, chars.Length)]);
                    counter++;
                }
                // 0 100 0-70 
                listBox1.Items.Add(sb.ToString());
                counter = 0;
                sb.Clear();
            }
            listBox1.SelectedIndex = 0;
            textBox1.Clear();
        }

        static void Info(char[] c,int start,int end)
        {
            string cToStr = string.Join(" ", c).ToUpper();
            MessageBox.Show($"{cToStr} harflerinden oluşan ve {start} ile {end-1} uzunluğunda " +
                $"rastgele kelimeler ile karşılacaksınız");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            char[] chars = { 'a', 's', 'd', 'f' };
            int start = 2;
                int end = 6;
            Shuffle(chars, start, end);
            textBox1.Focus();
            Info(chars, start, end);
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            char[] chars = { 'j', 'k', 'l', 'ş' };
            int start = 3;
            int end = 7;
            Info(chars, start, end);

            Shuffle(chars, start, end);
            textBox1.Focus();
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            char[] chars = { 'a', 's', 'd', 'f', 'j', 'k', 'l', 'ş' };
            int start = 3;
            int end = 7;
            Info(chars, start, end);

            Shuffle(chars, start, end);
            textBox1.Focus();
        }

        /*private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // aab 
            int LCount = listBox1.Items.Count;
            int counter = 0;
            TextBox t = (TextBox)sender;
            
            string Truestring = "";
            //textBox1_KeyPress(sender, e);
            //while (counter < listBox1.Items[listBox1.SelectedIndex].ToString().Length)
            //{
            //    if (textBox1.Text.Length > 1 && textBox1.Text[counter].ToString() == listBox1.Items[listBox1.SelectedIndex].ToString()[counter].ToString())
            //    {
            //        Truestring += textBox1.Text[counter];
            //        counter++;
            //        textBox1.Text = t.Text;
            //    }
            //    else textBox1.Text = Truestring;
            //}

            if (counter < LCount)
                t.MaxLength = listBox1.Items[listBox1.SelectedIndex].ToString().Length;
            if (LCount > counter && listBox1.Items[listBox1.SelectedIndex].ToString().Length == t.TextLength)
            {
                if (listBox1.Items[listBox1.SelectedIndex].ToString() == textBox1.Text.ToLower())
                {
                    counter++;
                    // MessageBox.Show("Tebrikler!");
                    if (LCount > listBox1.SelectedIndex + 1)
                        listBox1.SelectedIndex++;
                    else
                    {
                        MessageBox.Show("Tebrikler");
                        listBox1.SelectedIndex = -1;
                        listBox1.Items.Clear();
                        textBox1.Text = null;
                        if (lastV + 1 < comboBox1.Items.Count) 
                        {
                            comboBox1.SelectedIndex = lastV + 1;
                        MessageBox.Show($"{lastV + 1}.seviye");
                    }
                    else MessageBox.Show("Daha fazla seviye yok.");
                    }
                    textBox1.Clear();
                }
            }
        }
        */
        private void button4_Click(object sender, EventArgs e)
        {

            char[] chars = { 'a', 's', 'd', 'f', 'j', 'k', 'l', 'ş','g','h' };
            int start = 3;
            int end = 9;
            Info(chars, start, end);

            Shuffle(chars, start, end);
            textBox1.Focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            char[] chars = { 'a', 's', 'd', 'f', 'j', 'k', 'l', 'ş', 'g', 'h','r','v','u','m' };
            int start = 4;
            int end = 12;
            Info(chars, start, end);

            Shuffle(chars, start, end);
            textBox1.Focus();
        }

        
        //public object SonrakiSeviye(object sender)
        //{
        //    string comboSelected = comboBox1.SelectedItem.ToString();

        //    if (comboBox1.Items.Count < comboBox1.Items.Count + 1)
        //    {
        //        int ButonNumara = comboBox1.Items.IndexOf(comboSelected) + 1;
        //        return comboBox1.Items[ButonNumara];
        //    }
        //    else return MessageBox.Show("Daha fazla seviye yok");
        //}
        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < b.Count; i++)
            {
                if (b[i].Text == comboBox1.SelectedItem.ToString())
                    b[i].PerformClick();
                lastV = comboBox1.SelectedIndex;
            }
        }

        

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string s = listBox1.SelectedItem.ToString();
            if (e.KeyChar != s[j])
            {
                if (checkBox2.Checked)
                {
                    counter++; // hata sayacı
                    label1_TextChanged(sender, e);
                }
                e.Handled = true;
            }
            else j++;
            if (j == s.Length) // J sayacı kelimeye eşit mi?
            {
                if (listBox1.SelectedIndex + 1 >= listBox1.Items.Count)
                {
                    j = 0;
                    e.Handled = true;
                    textBox1.Clear();
                    if (lastV + 1 < comboBox1.Items.Count)
                    {
                        comboBox1.SelectedIndex = lastV + 1;
                        MessageBox.Show($"{lastV + 1}.seviye");
                    }
                    else
                    {
                        MessageBox.Show("Tebrikler..Daha fazla seviye yok.");
                        listBox1.Items.Clear();
                    }
                }
                else
                {
                    listBox1.SelectedIndex++;
                    j = 0;
                    e.Handled = true;
                    textBox1.Clear();
                }
               
            }
        }
        
        private void LoadCheckBoxValue()
        {
            checkBox1.Checked = Properties.Settings.Default.CheckboxValue;
            checkBox2.Checked = Properties.Settings.Default.CheckBoxSayac;

        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.CheckboxValue = checkBox1.Checked;
            Properties.Settings.Default.Save();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (checkBox1.Checked) button1_Click(sender, e);
            if (checkBox2.Checked) label1.Text = counter.ToString();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.CheckBoxSayac = checkBox2.Checked;
            Properties.Settings.Default.Save();
        }

        private void label1_TextChanged(object sender, EventArgs e)
        {
            label1.Text = counter.ToString();
        }
    }
}
