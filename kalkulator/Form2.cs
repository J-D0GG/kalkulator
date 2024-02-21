using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kalkulator
{
    public partial class Form2 : Form
    {
        List<char> BOMBACLAT = new List<char>();
        List<char> ALLAHUAKBAR = new List<char>();

        List<char> OBAMNA = new List<char>();

        int[] addrez = new int[100];

        string rez;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Text = " +";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Text = "  -";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox3.Text = " ×";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox3.Text = " ÷";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox3.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Mashallah! Morate uneti brojeve i operaciju ");
                return;
            }


            for (int i = 0; i<100; i++)
            {
                addrez[i] = 0;
            }

            

            for(int i = 0; i < textBox1.Text.Length; i++)
            {

                BOMBACLAT.Add(textBox1.Text[i]);
            }

            for (int i = 0; i < textBox5.Text.Length; i++)
            {
                ALLAHUAKBAR.Add(textBox5.Text[i]);
            }

            if(textBox3.Text == " +")
            {
                string prvi = textBox1.Text;
                int pp = 0;
                int pn = 0;
                
                string drugi = textBox5.Text;
                int dp = 0;
                int dn = 0;

                int flagic = 0;

                for (int i = 0; i < prvi.Length; i++)
                {
                    if (BOMBACLAT[i] == '.')
                    {
                        flagic = 1;
                    }

                    if(flagic == 0)
                    {
                        pp++;
                    }
                    else
                    {
                        pn++;
                    }
                }

                flagic = 0;

                for (int i = 0; i < drugi.Length; i++)
                {
                    if (ALLAHUAKBAR[i] == '.')
                    {
                        flagic = 1;
                    }

                    if (flagic == 0)
                    {
                        dp++;
                    }
                    else
                    {
                        dn++;
                    }
                }

                if (pp > dp)
                {
                    for(int i = 0; i< pp - dp; i++)
                    {
                        ALLAHUAKBAR.Insert(0, '0');
                    }
                }
                else
                {
                    for (int i = 0; i < dp - pp; i++)
                    {
                        BOMBACLAT.Insert(0, '0');
                    }
                }

                if(pn > dn)
                {
                    for (int i = 0; i < pn - dn; i++)
                    {
                        ALLAHUAKBAR.Add('0');
                    }
                }
                else
                {
                    for (int i = 0; i < dn - pn; i++)
                    {
                        BOMBACLAT.Add('0');
                    }
                }

                for(int i = 0; i<BOMBACLAT.Count; i++)
                {
                        
                }


            }

        }
    }
}
