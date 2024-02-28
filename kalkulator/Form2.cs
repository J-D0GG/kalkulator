using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace kalkulator
{
    public partial class Form2 : Form
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();

        List<char> BOMBACLAT = new List<char>();
        List<char> ALLAHUAKBAR = new List<char>();

        List<char> OBAMNA = new List<char>();

        List<int> REZ = new List<int>();

        string rez;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            player.URL = "arab.mp3";
            player.controls.play();
            player.settings.setMode("Loop", true);
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
                        if (BOMBACLAT[i]!='.')
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
                        if (ALLAHUAKBAR[i] != '.')
                        {
                            dn++;
                        }
                    }
                }

                if (pp > dp)
                {
                    for (int i = 0; i < pp - dp; i++)
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
                    int flagamasevic = 0;

                    for(int i = 0; i < ALLAHUAKBAR.Count; i++)
                    {
                        if (ALLAHUAKBAR[i] == '.')
                        {
                            flagamasevic = 1;
                        }
                    }

                    if(flagamasevic == 0)
                    {
                        ALLAHUAKBAR.Add('.');
                    }

                    for (int i = 0; i < pn - dn; i++)
                    {
                        ALLAHUAKBAR.Add('0');
                    }
                }
                else
                {
                    if (pn < dn)
                    {
                        int flagamasevic = 0;

                        for (int i = 0; i < BOMBACLAT.Count; i++)
                        {
                            if (BOMBACLAT[i] == '.')
                            {
                                flagamasevic = 1;
                            }
                        }

                        if (flagamasevic == 0)
                        {
                            BOMBACLAT.Add('.');
                        }

                        for (int i = 0; i < dn - pn; i++)
                        {
                            BOMBACLAT.Add('0');
                        }
                    }
                }

                for (int i = 0; i < BOMBACLAT.Count; i++)
                {
                    rez += BOMBACLAT[i];
                }
                textBox2.Text = rez;

                rez = "";

                for (int i = 0; i < ALLAHUAKBAR.Count; i++)
                {
                    rez += ALLAHUAKBAR[i];
                }
                textBox6.Text = rez;


                for (int i = 0; i<BOMBACLAT.Count; i++)
                {
                    REZ.Add(0);
                }

                for (int i = BOMBACLAT.Count-1; i >= 0; i--)
                {

                    if (BOMBACLAT[i] == '.')
                    {
                        REZ[i + 1] = REZ[i];
                        OBAMNA.Add('.');
                    }
                    else
                    {

                        //int allah = Convert.ToInt32(ALLAHUAKBAR[i]) - 48;
                        //int bomba = Convert.ToInt32(BOMBACLAT[i]) - 48;
                        int allah = int.Parse(ALLAHUAKBAR[i].ToString());
                        int bomba = int.Parse(BOMBACLAT[i].ToString());
                        int rezultasevic = (bomba + allah + REZ[i]) % 10;
                        OBAMNA.Insert(OBAMNA.Count,Convert.ToChar(rezultasevic+4800));

                        /*
                        if (i != 0)
                        {
                            REZ[i - 1] = (allah + bomba + REZ[i]) / 10;
                        }
                        else
                        {
                            if(((allah + bomba + REZ[i]) / 10) > 0)
                            {
                                OBAMNA.Add(Convert.ToChar((allah + bomba + REZ[i]) / 10));
                            }
                        }
                        */
                    }
                }

                

                for(int i = 0; i < OBAMNA.Count; i++)
                {
                    rez += OBAMNA[i];
                }

                textBox4.Text = rez;
            }

        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            player.controls.stop();
        }
    }
}
