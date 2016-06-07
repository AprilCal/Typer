using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Typer
{
    public partial class MainForm : Form
    {
        private String str="";
        private char[] character;
        private long second = 1;

        public MainForm()
        {
            InitializeComponent();
            character = new char[] {'0','1','2','3','4','5','6','7','8','9','A','B','C','D','E','F'
            ,'G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z','a','b'
            ,'c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x'
            ,'y','z'};
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           // label3.Text = DateTime.Now.ToString("HH:mm:ss");
            second -= 1;
            if(second<=0)
            {
                richTextBox1.ReadOnly = true;
                timer1.Stop();
            }
            label3.Text = new DateTime(second * 10000000).ToLongTimeString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int len=Convert.ToInt32(textBox1.Text);
            Random ran = new Random();
            //int RandKey = ran.Next(0, 61);

            while (str.Length<len)
            {
                str += character[ran.Next(0, 61)];
            }
            textBox2.Text = str;
            str = "";
            richTextBox1.Text = "";
            second = 46;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            int t = richTextBox1.TextLength;
            if(t!=0)
            {
                if(t>textBox2.TextLength)
                {
                    MessageBox.Show("too much");
                    return;
                }
                else if(richTextBox1.Text[t-1]!=textBox2.Text[t-1])
                {
                    richTextBox1.Select(t - 1, t);
                    richTextBox1.SelectionColor = Color.Red;
                    richTextBox1.Select(t, 0);
                }
                else
                {
                    richTextBox1.Select(t - 1, 1);
                    richTextBox1.SelectionColor = Color.Black;
                    richTextBox1.Select(t, 0);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox2.Text=="")
            {
                MessageBox.Show("请先出题再开始");
            }
            second = 46;
            richTextBox1.ReadOnly = false;
            timer1.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new FontForm(this).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            MessageBox.Show("用时"+(45 - second));
        }
    }
}
