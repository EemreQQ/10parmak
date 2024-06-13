using _10parmak.Properties;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        int lastV = 0;
        int j;
        int counter = 0;
        Dictionary<char,int> istatistik= new Dictionary<char,int>();

        public Form1()
        {
            InitializeComponent();
            LoadCheckBoxValue();
            comboBox1.Items.Add("1.seviye");
            comboBox1.Items.Add("2.seviye");
            comboBox1.Items.Add("3.seviye");
            comboBox1.Items.Add("4.seviye");
            comboBox1.Items.Add("5.seviye");          

            if (!checkBox2.Checked) label1.Visible = false;
            label1.Font = new Font(label1.Font.FontFamily, 9);

            // Combo Box
            listBox1.Font = new Font(listBox1.Font.FontFamily, 14);
            
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

        
        
        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = comboBox1.SelectedIndex;
            lastV = i;
            if (i == 0) button1_Click(sender,e);
            else if (i==1) button2_Click(sender,e);
            else if (i == 2) button3_Click(sender, e);
            else if (i == 3) button4_Click(sender, e);
            else if (i == 4) button5_Click(sender, e);
        }

        

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string s = listBox1.SelectedItem.ToString();
            if (e.KeyChar != s[j])
            {
                if (checkBox2.Checked)
                {
                    if (istatistik.ContainsKey(s[j])) istatistik[s[j]]++;
                    else istatistik.Add(s[j], 1);
                    counter++; // hata sayacı
                    label1_TextChanged(sender, e);
                }
                e.Handled = true;
            }
            else { j++; }
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
            checkBox3.Checked = Properties.Settings.Default.Image;
        }
   
        private void Form1_Load(object sender, EventArgs e)
        {   
            if(checkBox1.Checked) { comboBox1.SelectedIndex = 0; }
            if (checkBox2.Checked) label1.Text = counter.ToString();
            if (!checkBox3.Checked)
            {
                pictureBox1.Hide();
                label2.Hide();
            }
            else
            {
                pictureBox1.Show();
                label2.Show();
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.CheckBoxSayac = checkBox2.Checked;
            Properties.Settings.Default.Save();
            if (!checkBox2.Checked)
            {
                label1.Hide();
            }
            else
            {
                label1.Show();
            }
        }

        private void label1_TextChanged(object sender, EventArgs e)
        {
            label1.Text = counter.ToString();
        }

        private void ayrıntılıHataSayısıToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataTable ist = new DataTable();
            ist.Columns.Add("Bu harfe basmak isterken");
            ist.Columns.Add("yapılan yanlış tuş vuruşu");
            

            foreach (KeyValuePair<char, int> item in istatistik)
            {
                ist.Rows.Add(item.Key, item.Value);
            }
            Form2 form = new Form2();
            MessageBox.Show("Nasıl Çalışır? \nF - 5 yazıyorsa F'basmak isterken 5 kez yanlış tuşa bastığınızı gösterir.");
            form.dataGridView1.DataSource = ist;
            form.ShowDialog();

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Image = checkBox3.Checked;
            Properties.Settings.Default.Save();

            if (!checkBox3.Checked)
            {
                pictureBox1.Hide();
                label2.Hide();
            }
            else
            {
                pictureBox1.Show();
                label2.Show();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.CheckboxValue = checkBox1.Checked;
            Properties.Settings.Default.Save();           
        }
    }
}
