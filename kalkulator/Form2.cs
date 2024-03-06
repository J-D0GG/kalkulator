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

        public List<int> PRVI = new List<int>();
        public List<int> DRUGI = new List<int>();

        public List<int> OBAMNA = new List<int>();

        public List<int> REZ = new List<int>();

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
            string prvi = textBox1.Text;
            int PrviPre = 0;
            int PrviNakon = 0;

            string drugi = textBox5.Text;
            int DrugiPre = 0;
            int DrugiNakon = 0;


            if (textBox1.Text == "" || textBox3.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Mashallah! Morate uneti brojeve i operaciju ");
                return;
            }

            /*UNOS BROJEVA U LISTE*/

            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                if (textBox1.Text[i] == '.')
                {
                    PRVI.Add(-1);
                }
                else
                {
                    PRVI.Add(int.Parse(textBox1.Text[i].ToString()));
                }
                
            }

            for (int i = 0; i < textBox5.Text.Length; i++)
            {
                if (textBox5.Text[i] == '.')
                {
                    DRUGI.Add(-1);
                }
                else
                {
                    DRUGI.Add(int.Parse(textBox5.Text[i].ToString()));
                }
                
            }

            PreiNakon(PrviPre, PrviNakon, DrugiPre, DrugiNakon);

            
            for(int i = 0; i < PRVI.Count; i++)
            {
                textBox2.Text += Convert.ToString(PRVI[i]);
            }
            for (int i = 0; i < DRUGI.Count; i++)
            {
                textBox6.Text += Convert.ToString(DRUGI[i]);
            }
            

            /*
            if (textBox3.Text == " +")
            {
                Saberi();
                PreiNakon(PrviPre, PrviNakon, DrugiPre, DrugiNakon);
            }
            */



        }

        public void PreiNakon(int PrviPre, int PrviNakon, int DrugiPre, int DrugiNakon)
        {
            int flag = 0;

            for (int i = 0; i < PRVI.Count; i++)
            {
                if (PRVI[i] == -1)
                {
                    flag = 1;
                }

                if (flag == 0)
                {
                    PrviPre++;
                }
                else
                {
                    if (PRVI[i] != -1)
                    {
                        PrviNakon++;
                    }

                }
            }

            flag = 0;

            for (int i = 0; i < DRUGI.Count; i++)
            {
                if (DRUGI[i] == -1)
                {
                    flag = 1;
                }

                if (flag == 0)
                {
                    DrugiPre++;
                }
                else
                {
                    if (DRUGI[i] != -1)
                    {
                        DrugiNakon++;
                    }
                }
            }

            if (PrviPre > DrugiPre)
            {
                for (int i = 0; i < PrviPre - DrugiPre; i++)
                {
                    DRUGI.Insert(0, 0);
                }
            }
            else
            {
                for (int i = 0; i < DrugiPre - PrviPre; i++)
                {
                    PRVI.Insert(0, 0);
                }

            }

            if (PrviNakon > DrugiNakon)
            {
                int flagic = 0;

                for (int i = 0; i < DRUGI.Count; i++)
                {
                    if (DRUGI[i] == -1)
                    {
                        flagic = 1;
                    }
                }

                if (flagic == 0)
                {
                    DRUGI.Add(-1);
                }

                for (int i = 0; i < PrviNakon - DrugiNakon; i++)
                {
                    DRUGI.Add(0);
                }
            }
            else
            {
                if (PrviNakon < DrugiNakon)
                {
                    int flagic = 0;

                    for (int i = 0; i < PRVI.Count; i++)
                    {
                        if (PRVI[i] == -1)
                        {
                            flagic = 1;
                        }
                    }

                    if (flagic == 0)
                    {
                        PRVI.Add(-1);
                    }

                    for (int i = 0; i < DrugiNakon - PrviNakon; i++)
                    {
                        PRVI.Add(0);
                    }
                }
            }
        }

        public void Saberi()
        {
            /*

            string prvi = textBox1.Text;
            int PrviPre = 0;
            int PrviNakon = 0;

            string drugi = textBox5.Text;
            int DrugiPre = 0;
            int DrugiNakon = 0;

            int flag = 0;


            

            for (int i = 0; i < PRVI.Count; i++)
            {
                rez += Convert.ToString(PRVI[i]);
            }
            textBox2.Text = rez;

            rez = "";

            for (int i = 0; i < DRUGI.Count; i++)
            {
                rez += Convert.ToString(DRUGI[i]);
            }
            textBox6.Text = rez;

            

            for (int i = 0; i < PRVI.Count; i++)
            {
                REZ.Add(0);
            }

            for (int i = PRVI.Count - 1; i >= 0; i--)
            {

                if (PRVI[i] == '.')
                {
                    REZ[i + 1] = REZ[i];
                    OBAMNA.Add('.');
                }
                else
                {

                    //int allah = Convert.ToInt32(ALLAHUAKBAR[i]) - 48;
                    //int bomba = Convert.ToInt32(BOMBACLAT[i]) - 48;
                    int allah = int.Parse(DRUGI[i].ToString());
                    int bomba = int.Parse(PRVI[i].ToString());
                    int rezultasevic = (bomba + allah + REZ[i]) % 10;
                    OBAMNA.Insert(OBAMNA.Count, Convert.ToChar(rezultasevic + 4800));

                    
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
                    
                }
            }



            for (int i = 0; i < OBAMNA.Count; i++)
            {
                rez += OBAMNA[i];
            }

            textBox4.Text = rez;
            */

        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            player.controls.stop();
        }
    }
}
