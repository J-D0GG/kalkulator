using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
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

        public List<int> REZ = new List<int>();

        public List<int> OSTATAK = new List<int>();

        public List<int> MNOZENJE = new List<int>();

        string rez;

        
        int PrviPre = 0;
        int PrviNakon = 0;

        
        int DrugiPre = 0;
        int DrugiNakon = 0;

        int PrviNegativan = 0;
        int DrugiNegativan = 0;
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
            string drugi = textBox5.Text;


            if (textBox1.Text == "" || textBox3.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Mashallah! Morate uneti brojeve i operaciju ");
                return;
            }

            /*UNOS BROJEVA U LISTE*/

            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                if (textBox1.Text[i] == ',')
                {
                    PRVI.Add(-1);
                }
                else if (textBox1.Text[i] != '-')
                {
                    PRVI.Add(int.Parse(textBox1.Text[i].ToString()));
                }

                if (textBox1.Text[i] == '-')
                {
                    PrviNegativan = 1;
                }
            }

            for (int i = 0; i < textBox5.Text.Length; i++)
            {
                if (textBox5.Text[i] == ',')
                {
                    DRUGI.Add(-1);
                }
                else if(textBox5.Text[i] != '-')
                {
                    DRUGI.Add(int.Parse(textBox5.Text[i].ToString()));
                }

                if (textBox5.Text[i] == '-')
                {
                    DrugiNegativan = 1;
                }

            }

            if(textBox3.Text == " +") 
            {
                if (PrviNegativan == 1 & DrugiNegativan == 0)
                {
                    Oduzmi(DRUGI,PRVI);
                }
                else if (PrviNegativan == 0 & DrugiNegativan == 1)
                {
                    Oduzmi(PRVI, DRUGI);    
                }
                else if (PrviNegativan == 1 & DrugiNegativan == 1)
                {
                    Saberi();
                }
                else if (PrviNegativan == 0 & DrugiNegativan == 0)
                {
                    Saberi();
                }
            }
            if (textBox3.Text == "  -") 
            { 
                if(PrviNegativan == 1 & DrugiNegativan == 0)
                {
                    Saberi();
                }
                if (PrviNegativan == 0 & DrugiNegativan == 1)
                {
                    Saberi();
                }
                if (PrviNegativan == 1 & DrugiNegativan == 1)
                {
                    Oduzmi(DRUGI,PRVI);
                }
                if (PrviNegativan == 0 & DrugiNegativan == 0)
                {
                    Oduzmi(PRVI,DRUGI);
                }

            }

            if(textBox3.Text == " ×")
            {
                Pomnozi(textBox1.Text, textBox5.Text);
            }

            if(textBox3.Text == " ÷")
            {
                Podeli(textBox1.Text, textBox5.Text);
            }
        }

        public void PreiNakon()
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

        public void Oduzmi(List<int> PRVI, List<int> DRUGI)
        {
            rez = "";
            PreiNakon();

            int manjevece = ManjeVece(PRVI, DRUGI);

            if (manjevece == 0)
            {
                textBox4.Text = "0";
                Clear();
                return;
            }

            /*PRVI BROJ JE VECI*/

            else if (manjevece == 1)
            {
                for (int i = 0; i < PRVI.Count; i++)
                {
                    OSTATAK.Add(0);
                }


                for (int i = PRVI.Count - 1; i >= 0; i--)
                {

                    if (PRVI[i] == -1)
                    {
                        OSTATAK[i - 1] = OSTATAK[i];
                        REZ.Insert(0, -1);
                        continue;
                    }

                    if (PRVI[i] - (DRUGI[i] + OSTATAK[i]) >= 0)
                    {

                        REZ.Insert(0, PRVI[i] - (DRUGI[i] + OSTATAK[i]));

                    }
                    else
                    {
                        int oduzmi = (DRUGI[i] + OSTATAK[i]) - PRVI[i];
                        REZ.Insert(0, 10 - oduzmi);

                        if (i != 0)
                        {
                            OSTATAK[i - 1] = 1;
                        }

                    }
                }



                for (int i = 0; i < PRVI.Count; i++)
                {
                    if (REZ[i] == -1)
                    {
                        rez += ",";
                    }
                    else
                    {
                        rez += Convert.ToString(REZ[i]);
                    }
                }

                textBox4.Text = rez;

                Clear();
            }

            /*DRUGI BROJ JE VECI*/

            else if (manjevece == 2)
            {
                for (int i = 0; i < DRUGI.Count; i++)
                {
                    OSTATAK.Add(0);
                }


                for (int i = DRUGI.Count - 1; i >= 0; i--)
                {

                    if (DRUGI[i] == -1)
                    {
                        OSTATAK[i - 1] = OSTATAK[i];
                        REZ.Insert(0, -1);
                        continue;
                    }

                    if (DRUGI[i] - (PRVI[i] + OSTATAK[i]) >= 0)
                    {

                        REZ.Insert(0, DRUGI[i] - (PRVI[i] + OSTATAK[i]));

                    }
                    else
                    {
                        int oduzmi = (PRVI[i] + OSTATAK[i]) - DRUGI[i];
                        REZ.Insert(0, 10 - oduzmi);

                        if (i != 0)
                        {
                            OSTATAK[i - 1] = 1;
                        }

                    }
                }

                rez += "-";

                for (int i = 0; i < DRUGI.Count; i++)
                {
                    if (REZ[i] == -1)
                    {
                        rez += ",";
                    }
                    else
                    {
                        rez += Convert.ToString(REZ[i]);
                    }
                }

                textBox4.Text = rez;

                Clear();
            }
            

        }

        public int ManjeVece(List<int> PRVI, List<int> DRUGI)
        {
            for(int i = 0;i < PRVI.Count;i++)
            {
                if (PRVI[i] > DRUGI[i])
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
            return 0;
        }
        public void Saberi()
        {
            rez = "";
            PreiNakon();

            //for (int i = 0; i < PRVI.Count; i++)
            //{
            //    textBox2.Text += Convert.ToString(PRVI[i]);
            //}
            //for (int i = 0; i < DRUGI.Count; i++)
            //{
            //    textBox6.Text += Convert.ToString(DRUGI[i]);
            //}

            for (int i = 0; i < PRVI.Count+1; i++)
            {
                OSTATAK.Add(0);
            }

            for (int i = PRVI.Count - 1; i >= 0; i--)
            {

                if (PRVI[i] == -1)
                {
                    OSTATAK[i - 1] = OSTATAK[i];
                    REZ.Insert(0, -1);
                    continue;
                }


                REZ.Insert(0, (PRVI[i] + DRUGI[i] + OSTATAK[i]) % 10);

                if (i != 0)
                {
                    OSTATAK[i - 1] = (DRUGI[i] + PRVI[i] + OSTATAK[i]) / 10;
                }
                else
                {
                    if (((DRUGI[i] + PRVI[i] + OSTATAK[i]) / 10) > 0)
                    {
                        REZ.Insert(0, (DRUGI[i] + PRVI[i] + OSTATAK[i]) / 10);
                    }
                }


            }

            if (PrviNegativan == 1)
            {
                rez += "-";
            }

            for (int i = 0; i < REZ.Count; i++)
            {
                if (REZ[i] == -1)
                {
                    rez += ",";
                }
                else
                {
                    rez += Convert.ToString(REZ[i]);
                }
            }

            
            textBox4.Text = rez;

            Clear();

        }

        public void Pomnozi(string prvi, string drugi)
        {

            System.Numerics.BigInteger prvasevic = new BigInteger();
            prvasevic = System.Numerics.BigInteger.Parse(prvi);

            System.Numerics.BigInteger drugasevic = new BigInteger();
            drugasevic = System.Numerics.BigInteger.Parse(drugi);

            prvasevic = prvasevic * drugasevic;

            textBox4.Text = prvasevic.ToString();

        }

        public void Podeli(string prvi, string drugi)
        {
            System.Numerics.BigInteger prvasevic = new BigInteger();
            prvasevic = System.Numerics.BigInteger.Parse(prvi);

            System.Numerics.BigInteger drugasevic = new BigInteger();
            drugasevic = System.Numerics.BigInteger.Parse(drugi);

            prvasevic = prvasevic / drugasevic;

            textBox4.Text = prvasevic.ToString();
        }
        public void Clear()
        {
            PRVI.Clear();
            DRUGI.Clear();
            REZ.Clear();
            OSTATAK.Clear();
            PrviPre = 0;
            PrviNakon = 0;
            DrugiPre = 0;
            DrugiNakon = 0;
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            player.controls.stop();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
