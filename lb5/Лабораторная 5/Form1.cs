using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace Лабораторная_5
{
    public partial class Form1 : Form
    {
        public double H1 = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
                textBox3.Text = (int.Parse(textBox1.Text) * int.Parse(textBox2.Text)).ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
                textBox3.Text = (int.Parse(textBox1.Text) * int.Parse(textBox2.Text)).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int k = 0;
            char[] name = textBox4.Text.ToCharArray();
            int[] nomera = new int[name.Length];
            char[] alfa = { ' ','а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };
            for(int i=0;i<name.Length;i++)
            {
                for(int j=1;j<alfa.Length;j++)
                    if(name[i]==alfa[j])
                    {
                        nomera[k] = j*2; 
                        k++;
                    }
            }
            int H0 = 0;
            H1 = 0;
            Random rnd = new Random();
            for(int i=0;i<nomera.Length;i++)
            {
                H0 = rnd.Next(11,99);
                H1 = Math.Pow((H0 + nomera[i]), 2) % double.Parse(textBox3.Text);
                listBox1.Items.Add("H" + (i+1) + " = " + H1);
            }
            listBox1.Items.Add("Хеш-образ равен " + H1 + ".");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int s = fun(int.Parse(textBox6.Text),(int)H1, int.Parse(textBox5.Text)) % int.Parse(textBox6.Text);
           // double s = Math.Pow(H1, int.Parse(textBox5.Text)) % double.Parse(textBox6.Text);
           textBox7.Text = s.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BigInteger p=Лабораторная_5.RSAlgorithm.BigMod(int.Parse(textBox7.Text), int.Parse(textBox10.Text), int.Parse(textBox9.Text));
           // int s = fun(int.Parse(textBox3.Text), int.Parse(textBox7.Text), int.Parse(textBox10.Text)) % int.Parse(textBox3.Text);
            //double s=Math.Pow(int.Parse(textBox7.Text),int.Parse(textBox10.Text)) % double.Parse(textBox3.Text);
            textBox8.Text = p.ToString();
            if ((int)p == H1)
                label6.Text = "Подпись подлинная";
            else
                label6.Text = "Подпись не подлинная";
        }

        public int fun(int p, int a, int b)
        {
            int s = 1;
            for (int i = 1; i <= b; i++)
            {

                s = (s * a) % p;
            }
            return s;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
