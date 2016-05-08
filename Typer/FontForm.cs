using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Typer
{
    public partial class FontForm : Form
    {
        //string[] fontName;
        
        MainForm mainForm;
        FontStyle style = FontStyle.Regular;
        public FontForm(MainForm mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();
            comboBox2.DrawMode = DrawMode.OwnerDrawFixed;
            comboBox2.DrawItem += comboBox2_DrawItem;
            comboBox4.DrawMode = DrawMode.OwnerDrawFixed;
            comboBox4.DrawItem += comboBox4_DrawItem;
            ///*
            ///set comboBox1 font items
            var fonlist = new InstalledFontCollection();
            var data = new BindingSource { DataSource = fonlist.Families.Select(o => o.Name) };
            comboBox1.DataSource = data;

            ///*
            ///set comBox2 shape items
            var type = new string[] {"常规","倾斜","粗体","粗体倾斜" };
            var data2 = new BindingSource { DataSource = type };
            comboBox2.DataSource = data2;
            ///*
            ///set comboBox3 size items
            int [] size = new int[10]{22,23,24,25,26,27,28,29,30,31};
            var data3 = new BindingSource { DataSource = size };
            comboBox3.DataSource = data3;
            ///*
            ///set comboBox4 color items
            var color = new string[] { "黑", "蓝", "红", "黄" };
            var data4 = new BindingSource { DataSource = color };
            comboBox4.DataSource = data4;
            //String[] a = { "黑", "红", "绿", "黄" };
            //comboBox4.Items.AddRange(a);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FontStyle style = FontStyle.Regular;
            switch (comboBox2.Text)
            {
                case "常规":
                    style = FontStyle.Regular;
                    break;
                case "倾斜":
                    style = FontStyle.Italic;
                    break;
                case "粗体":
                    style = FontStyle.Bold;
                    break;
                case "粗体倾斜":
                    style = FontStyle.Italic | FontStyle.Bold;
                    break;
            }
            switch(comboBox4.Text)
            {
                case "黑":
                    mainForm.textBox2.ForeColor = Color.Black;
                    break;
                case "蓝":
                    mainForm.textBox2.ForeColor = Color.Blue;
                    break;
                case "红":
                    mainForm.textBox2.ForeColor = Color.Red;
                    break;
                case "黄":
                    mainForm.textBox2.ForeColor = Color.Yellow;
                    break;
            }
            if(checkBox1.Checked)
            {
                style = style | FontStyle.Strikeout;
            }
            if(checkBox2.Checked)
            {
                style = style | FontStyle.Underline;
            }
            mainForm.textBox2.Font = new Font(comboBox1.Text, Convert.ToInt32(comboBox3.Text)
                , style);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox2_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index > -1)
            {
                Font f = null;
                switch (e.Index)
                {

                    case 0:
                        f = new Font("宋体", 9, FontStyle.Regular);                       
                        e.Graphics.DrawString(Convert.ToString(comboBox2.Items[e.Index]), f, Brushes.Black, e.Bounds);
                        break;
                    case 1:
                        f = new Font("宋体", 9, FontStyle.Italic);
                        e.Graphics.DrawString(Convert.ToString(comboBox2.Items[e.Index]), f, Brushes.Black, e.Bounds);
                        break;
                    case 2:
                        f = new Font("宋体", 9, FontStyle.Bold);
                        e.Graphics.DrawString(Convert.ToString(comboBox2.Items[e.Index]), f, Brushes.Black, e.Bounds);
                        break;
                    case 3:
                        f = new Font("宋体", 9, FontStyle.Italic | FontStyle.Bold);
                        e.Graphics.DrawString(Convert.ToString(comboBox2.Items[e.Index]), f, Brushes.Black, e.Bounds);
                        break;
                }
            }
        }
        private void comboBox4_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index > -1)
            {
                Font f = null;
                switch (e.Index)
                {

                    case 0:
                        f = new Font("宋体", 9, FontStyle.Bold);
                        //e.Graphics.DrawRectangle(new Pen(Brushes.Black), 0, 0, 10, 10);
                        e.Graphics.FillRectangle(new SolidBrush(Color.Black), e.Bounds.X + 1, e.Bounds.Y + 1, 20, 14);
                        e.Graphics.DrawString(Convert.ToString(comboBox4.Items[e.Index]), f, Brushes.Black, e.Bounds.X + 20, e.Bounds.Y + 1);
                        break;
                    case 1:
                        f = new Font("宋体", 9, FontStyle.Bold);
                        e.Graphics.FillRectangle(new SolidBrush(Color.Blue), e.Bounds.X + 1, e.Bounds.Y + 1, 20, 14);
                        e.Graphics.DrawString(Convert.ToString(comboBox4.Items[e.Index]), f, Brushes.Blue, e.Bounds.X + 20, e.Bounds.Y + 1);
                        break;
                    case 2:
                        f = new Font("宋体", 9, FontStyle.Bold);
                        e.Graphics.FillRectangle(new SolidBrush(Color.Red), e.Bounds.X + 1, e.Bounds.Y + 1, 20, 14);
                        e.Graphics.DrawString(Convert.ToString(comboBox4.Items[e.Index]), f, Brushes.Red, e.Bounds.X + 20, e.Bounds.Y + 1);
                        break;
                    case 3:
                        f = new Font("宋体", 9, FontStyle.Bold);
                        e.Graphics.FillRectangle(new SolidBrush(Color.Yellow), e.Bounds.X + 1, e.Bounds.Y + 1, 20, 14);
                        e.Graphics.DrawString(Convert.ToString(comboBox4.Items[e.Index]), f, Brushes.Yellow, e.Bounds.X + 20, e.Bounds.Y + 1);
                        break;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = comboBox1.Text;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            switch (comboBox2.Text)
            {
                case "常规":
                    style = FontStyle.Regular;
                    break;
                case "倾斜":
                    style = FontStyle.Italic;
                    break;
                case "粗体":
                    style = FontStyle.Bold;
                    break;
                case "粗体倾斜":
                    style = FontStyle.Italic | FontStyle.Bold;
                    break;
            }
            textBox1.Font = new Font(comboBox1.Text, Convert.ToInt32(comboBox3.Text), style);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Font = new Font(comboBox1.Text, Convert.ToInt32(comboBox3.Text), style);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                style = style | FontStyle.Strikeout;
            }
            else
            {
                style -= FontStyle.Strikeout;
            }
            textBox1.Font = new Font(comboBox1.Text, Convert.ToInt32(comboBox3.Text), style);

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox2.Checked)
            {
                style = style | FontStyle.Underline;
            }
            else
            {
                style -= FontStyle.Underline;
            }
            textBox1.Font = new Font(comboBox1.Text, Convert.ToInt32(comboBox3.Text), style);
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.BackColor = textBox1.BackColor;
            switch (comboBox4.Text)
            {
                case "黑":
                    this.textBox1.ForeColor = Color.Black;
                    break;
                case "蓝":
                    this.textBox1.ForeColor = Color.Blue;
                    break;
                case "红":
                    this.textBox1.ForeColor = Color.Red;
                    break;
                case "黄":
                    this.textBox1.ForeColor = Color.Yellow;
                    break;
            }
        }
    }//FontForm
}//namespace
