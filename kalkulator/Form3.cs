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

    public partial class Form3 : Form
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();
        

        public int prvif = 1;
        int flagcic = 0;

        int[] rindexasevic = new int[100];
        int[] vrednostZumajahad = new int[100];
        int[] vrednostHadzenadin = new int[100];

        int[] indexasevic = new int[100];
        int[] indexasevanovic = new int[100];

        List<char> zumajahad = new List<char>();
        List<char> hadzenadin = new List<char>();

        List<char> lrimski = new List<char>();

        public Form3()
        {
            InitializeComponent();

            

            pictureBox2.BackColor = Color.Transparent; 
            pictureBox3.BackColor = Color.Transparent;

            pictureBox2.Parent = pictureBox1;
            pictureBox3.Parent = pictureBox1;
           
        }

        


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Unesi prvi broj majmune");

            }
            else
            {
                textBox3.Text = " +";
            }
            prvif = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Unesi prvi broj majmune");

            }
            else
            {
                textBox3.Text = "  -";
            }
            prvif = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Unesi prvi broj majmune");

            }
            else
            {
                textBox3.Text = " ×";
            }
            prvif = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Unesi prvi broj majmune");

            }
            else
            {
                textBox3.Text = " ÷";
            }
            prvif = 0;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(prvif == 1)
            {
                textBox1.Text = textBox1.Text + "I";
                zumajahad.Add('I');
            }
            else
            {
                textBox2.Text = textBox2.Text + "I";
                hadzenadin.Add('I');
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (prvif == 1)
            {
                textBox1.Text = textBox1.Text + "V";
                zumajahad.Add('V');
            }
            else
            {
                textBox2.Text = textBox2.Text + "V";
                hadzenadin.Add('V');
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (prvif == 1)
            {
                textBox1.Text = textBox1.Text + "X";
                zumajahad.Add('X');
            }
            else
            {
                textBox2.Text = textBox2.Text + "X";
                hadzenadin.Add('X');
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (prvif == 1)
            {
                textBox1.Text = textBox1.Text + "L";
                zumajahad.Add('L');
            }
            else
            {
                textBox2.Text = textBox2.Text + "L";
                hadzenadin.Add('L');
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (prvif == 1)
            {
                textBox1.Text = textBox1.Text + "C";
                zumajahad.Add('C');
            }
            else
            {
                textBox2.Text = textBox2.Text + "C";
                hadzenadin.Add('C');
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (prvif == 1)
            {
                textBox1.Text = textBox1.Text + "D";
                zumajahad.Add('D');
            }
            else
            {
                textBox2.Text = textBox2.Text + "D";
                hadzenadin.Add('D');
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (prvif == 1)
            {
                textBox1.Text = textBox1.Text + "M";
                zumajahad.Add('M');
            }
            else
            {
                textBox2.Text = textBox2.Text + "M";
                hadzenadin.Add('M');
            }
        }


        private void button12_Click(object sender, EventArgs e)
        {
            int brv = 0;
            int brl = 0;
            int brd = 0;

            int brv2 = 0;
            int brl2 = 0;
            int brd2 = 0;




            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Niste uneli brojeve majmuneee");
            }
            else
            {

                textBox1.Text = "";
                textBox2.Text = "";

                for (int i = 0; i < zumajahad.Count; i++)
                {
                    if (zumajahad[i] == 'V')
                    {
                        brv++;
                    }
                    if (zumajahad[i] == 'L')
                    {
                        brl++;
                    }
                    if (zumajahad[i] == 'D')
                    {
                        brd++;
                    }
                }

                for (int i = 0; i < hadzenadin.Count; i++)
                {
                    if (hadzenadin[i] == 'V')
                    {
                        brv2++;
                    }
                    if (hadzenadin[i] == 'L')
                    {
                        brl2++;
                    }
                    if (hadzenadin[i] == 'D')
                    {
                        brd2++;
                    }
                }

                if (brv > 1 || brl > 1 || brd > 1 || brv2 > 1 || brl2 > 1 || brd2 > 1)
                {
                    MessageBox.Show("Greska! Brojevi V,L i D se ne mogu ponavljati!");
                    zumajahad.Clear();
                    hadzenadin.Clear();
                    resetIndexa();
                    brv = 0;
                    brl = 0;
                    brd = 0;
                    brv2 = 0;
                    brl2 = 0;
                    brd2 = 0;
                    return;
                }

                triBroja('I', 1);
                triBroja('X', 1);
                triBroja('C', 1);
                triBroja('M', 1);

                triBroja('I', 2);
                triBroja('X', 2);
                triBroja('C', 2);
                triBroja('M', 2);

                if (flagcic == 1)
                {
                    return;
                }

                

                

                for (int i = 0; i<zumajahad.Count; i++)
                {
                    if (zumajahad[i] == 'I')
                    {
                        indexasevic[i] = 1;
                    }
                    if (zumajahad[i] == 'V')
                    {
                        indexasevic[i] = 2;
                    }
                    if (zumajahad[i] == 'X')
                    {
                        indexasevic[i] = 3;
                    }
                    if (zumajahad[i] == 'L')
                    {
                        indexasevic[i] = 4;
                    }
                    if (zumajahad[i] == 'C')
                    {
                        indexasevic[i] = 5;
                    }
                    if (zumajahad[i] == 'D')
                    {
                        indexasevic[i] = 6;
                    }
                    if (zumajahad[i] == 'M')
                    {
                        indexasevic[i] = 7;
                    }
                }

                for (int i = 0; i < hadzenadin.Count; i++)
                {
                    if (hadzenadin[i] == 'I')
                    {
                        indexasevanovic[i] = 1;
                    }
                    if (hadzenadin[i] == 'V')
                    {
                        indexasevanovic[i] = 2;
                    }
                    if (hadzenadin[i] == 'X')
                    {
                        indexasevanovic[i] = 3;
                    }
                    if (hadzenadin[i] == 'L')
                    {
                        indexasevanovic[i] = 4;
                    }
                    if (hadzenadin[i] == 'C')
                    {
                        indexasevanovic[i] = 5;
                    }
                    if (hadzenadin[i] == 'D')
                    {
                        indexasevanovic[i] = 6;
                    }
                    if (hadzenadin[i] == 'M')
                    {
                        indexasevanovic[i] = 7;
                    }
                }

                for(int i = 0; i < zumajahad.Count; i++)
                {
                    if (zumajahad[i] == 'V' || zumajahad[i] == 'L' || zumajahad[i] == 'D' || zumajahad[i] == 'M')
                    {
                        if (i < hadzenadin.Count-1)
                        {
                            if (indexasevic[i] < indexasevic[i + 1])
                            {
                                MessageBox.Show("Greska! Samo I,X i C se mogu staviti pre veceg broja!");
                                zumajahad.Clear();
                                hadzenadin.Clear();
                                resetIndexa();
                                return;
                            }
                        }
                    }
                }

                for (int i = 0; i < hadzenadin.Count; i++)
                {
                    if (hadzenadin[i] == 'V' || hadzenadin[i] == 'L' || hadzenadin[i] == 'D' || hadzenadin[i] == 'M')
                    {
                        if (i < hadzenadin.Count-1)
                        {
                            if (hadzenadin[i] < hadzenadin[i + 1])
                            {
                                MessageBox.Show("Greska! Samo I,X i C se mogu staviti pre veceg broja!");
                                zumajahad.Clear();
                                hadzenadin.Clear();
                                resetIndexa();
                                return;
                            }
                        }
                    }
                }

                /*
                for(int i = 0; i<hadzenadin.Count; i++)
                {
                    if (indexasevic[i] < indexasevic[i + 1])
                    {
                        for(int j = i; j < hadzenadin.Count; j++)
                        {
                            if(indexasevic)
                            if (indexasevic[i] == indexasevic[j])
                            {
                                MessageBox.Show("Greska! Broj ne postoji");
                                zumajahad.Clear();
                                hadzenadin.Clear();
                                return;
                            }
                        }
                    }
                }

                for (int i = 0; i < zumajahad.Count; i++)
                {
                    if (indexasevanovic[i] < indexasevanovic[i + 1])
                    {
                        for (int j = i; j < zumajahad.Count; j++)
                        {
                            if (indexasevanovic[i] == indexasevanovic[j])
                            {
                                MessageBox.Show("Greska! Broj ne postoji");
                                zumajahad.Clear();
                                hadzenadin.Clear();
                                return;
                            }
                        }
                    }
                }
                */

                /*Vrednosti*/

                

                for (int i = 0; i < zumajahad.Count; i++)
                {
                    if (zumajahad[i] == 'I')
                    {
                        vrednostZumajahad[i] = 1;
                    }
                    if (zumajahad[i] == 'V')
                    {
                        vrednostZumajahad[i] = 5;
                    }
                    if (zumajahad[i] == 'X')
                    {
                        vrednostZumajahad[i] = 10;
                    }
                    if (zumajahad[i] == 'L')
                    {
                        vrednostZumajahad[i] = 50;
                    }
                    if (zumajahad[i] == 'C')
                    {
                        vrednostZumajahad[i] = 100;
                    }
                    if (zumajahad[i] == 'D')
                    {
                        vrednostZumajahad[i] = 500;
                    }
                    if (zumajahad[i] == 'M')
                    {
                        vrednostZumajahad[i] = 1000;
                    }
                }

                for (int i = 0; i < hadzenadin.Count; i++)
                {
                    if (hadzenadin[i] == 'I')
                    {
                        vrednostHadzenadin[i] = 1;
                    }
                    if (hadzenadin[i] == 'V')
                    {
                        vrednostHadzenadin[i] = 5;
                    }
                    if (hadzenadin[i] == 'X')
                    {
                        vrednostHadzenadin[i] = 10;
                    }
                    if (hadzenadin[i] == 'L')
                    {
                        vrednostHadzenadin[i] = 50;
                    }
                    if (hadzenadin[i] == 'C')
                    {
                        vrednostHadzenadin[i] = 100;
                    }
                    if (hadzenadin[i] == 'D')
                    {
                        vrednostHadzenadin[i] = 500;
                    }
                    if (hadzenadin[i] == 'M')
                    {
                        vrednostHadzenadin[i] = 1000;
                    }
                }

                /*RIMSKI U ARAPSKI*/

                int banovicStrahinja=0;
                int strahinjicBane=0;

                for (int i =0; i < zumajahad.Count; i++)
                {
                    if (indexasevic[i] >= indexasevic[i + 1])
                    {
                        banovicStrahinja += vrednostZumajahad[i];
                    }
                    else
                    {
                        banovicStrahinja -= vrednostZumajahad[i];
                    }
                }

                for (int i = 0; i < hadzenadin.Count; i++)
                {
                    if (indexasevanovic[i] >= indexasevanovic[i + 1])
                    {
                        strahinjicBane += vrednostHadzenadin[i];
                    }
                    else
                    {
                        strahinjicBane -= vrednostHadzenadin[i];
                    }
                }


                /*
                textBox6.Text = Convert.ToString(banovicStrahinja);
                textBox7.Text = Convert.ToString(strahinjicBane);
                */

                /*---------------------OPERACIJE-------------------------*/

                int rez = 0;
                int ostatak = 0;
                string resenje;
                string resenjeOstatak;

                int res;

                if(textBox3.Text == " +")
                {
                    rez = banovicStrahinja + strahinjicBane;

                    if (rez < 4000)
                    {
                        resenje = toRimski(rez);
                        res = proveraResenja(resenje);
                        if(res == 1) { textBox4.Text = resenje; }
                        zumajahad.Clear();
                        hadzenadin.Clear();
                        resetIndexa();
                        return;
                    }
                    MessageBox.Show("Broj ne moze biti veci od 4000!");
                    zumajahad.Clear();
                    hadzenadin.Clear();
                    resetIndexa();
                    return;
                }
                else if(textBox3.Text == "  -")
                {
                    if (banovicStrahinja < strahinjicBane)
                    {
                        MessageBox.Show("Greska! Ne postoji negativan rimski broj!");
                        zumajahad.Clear();
                        hadzenadin.Clear();
                        resetIndexa();
                        return;
                    }

                    if (rez < 4000)
                    {
                        rez = banovicStrahinja - strahinjicBane;
                        resenje = toRimski(rez);
                        res = proveraResenja(resenje);
                        if (res == 1) { textBox4.Text = resenje; }
                        zumajahad.Clear();
                        hadzenadin.Clear();
                        resetIndexa();
                        return;
                    }

                    MessageBox.Show("Broj ne moze biti veci od 3999!");
                    zumajahad.Clear();
                    hadzenadin.Clear();
                    resetIndexa();
                    return;
                }
                else if (textBox3.Text == " ×")
                {
                    rez = banovicStrahinja * strahinjicBane;

                    if (rez < 4000)
                    {
                        resenje = toRimski(rez);
                        res = proveraResenja(resenje);
                        if (res == 1) { textBox4.Text = resenje; }
                        zumajahad.Clear();
                        hadzenadin.Clear();
                        resetIndexa();
                        return;
                    }
                    MessageBox.Show("Broj ne moze biti veci od 3999!");
                    zumajahad.Clear();
                    hadzenadin.Clear();
                    resetIndexa();
                    return;
                }
                else if(textBox3.Text == " ÷")
                {
                    rez = banovicStrahinja / strahinjicBane;
                    resenje = toRimski(rez);
                    res = proveraResenja(resenje);
                    if (res == 1) { textBox4.Text = resenje; }

                    ostatak = banovicStrahinja % strahinjicBane;
                    resenjeOstatak = toRimski(ostatak);
                    res = proveraResenja(resenjeOstatak);
                    if (res == 1) { textBox5.Text = resenjeOstatak; }

                    zumajahad.Clear();
                    hadzenadin.Clear();
                    resetIndexa();
                    return;
                }

            }
        }

        public int proveraResenja(string resenje)
        {
            for(int i = 0; i < lrimski.Count; i++)
            {
                if (rindexasevic[i] < rindexasevic[i + 1])
                {
                    for (int j = i; j < lrimski.Count; j++)
                    {
                        if (rindexasevic[i] == rindexasevic[j])
                        {
                            MessageBox.Show("Greska! Broj ne postoji xdxdxdxdxd");
                            return 0;
                        }
                    }
                }
            }
            return 1;
        } 
        public string toRimski(int broj)
        {
            string rimski = "";
            int i = 0;
            while (broj > 0)
            {
                if (broj >= 1000)
                {
                    rimski += "M";
                    lrimski.Add('M');
                    rindexasevic[i] = 7;
                    i++;
                    broj -= 1000;
                }
                else if (broj >= 900)
                {
                    rimski += "CM";
                    lrimski.Add('C');
                    rindexasevic[i] = 5;
                    i++;
                    lrimski.Add('M');
                    rindexasevic[i] = 7;
                    i++;
                    broj -= 900;
                }
                else if (broj >= 500)
                {
                    rimski += "D";
                    lrimski.Add('D');
                    rindexasevic[i] = 6;
                    i++;
                    broj -= 500;
                }
                else if (broj >= 400)
                {
                    rimski += "CD";
                    lrimski.Add('C');
                    rindexasevic[i] = 5;
                    i++;
                    lrimski.Add('D');
                    rindexasevic[i] = 6;
                    i++;
                    broj -= 400;
                }
                else if (broj >= 100)
                {
                    rimski += "C";
                    lrimski.Add('C');
                    rindexasevic[i] = 5;
                    i++;
                    broj -= 100;
                }
                else if (broj >= 90)
                {
                    rimski += "XC";
                    lrimski.Add('X');
                    rindexasevic[i] = 3;
                    i++;
                    lrimski.Add('C');
                    rindexasevic[i] = 5;
                    i++;
                    broj -= 90;
                }
                else if (broj >= 50)
                {
                    rimski += "L";
                    lrimski.Add('L');
                    rindexasevic[i] = 4;
                    i++;
                    broj -= 50;
                }
                else if (broj >= 40)
                {
                    rimski += "XL";
                    lrimski.Add('X');
                    rindexasevic[i] = 3;
                    i++;
                    lrimski.Add('L');
                    rindexasevic[i] = 4;
                    i++;
                    broj -= 40;
                }
                else if (broj >= 10)
                {
                    rimski += "X";
                    lrimski.Add('X');
                    rindexasevic[i] = 3;
                    i++;
                    broj -= 10;
                }
                else if (broj >= 9)
                {
                    rimski += "IX";
                    lrimski.Add('I');
                    rindexasevic[i] = 1;
                    i++;
                    lrimski.Add('X');
                    rindexasevic[i] = 3;
                    i++;
                    broj -= 9;
                }
                else if (broj >= 5)
                {
                    rimski += "V";
                    lrimski.Add('V');
                    rindexasevic[i] = 2;
                    i++;
                    broj -= 5;
                }
                else if (broj >= 4)
                {
                    rimski += "IV";
                    lrimski.Add('I');
                    rindexasevic[i] = 1;
                    i++;
                    lrimski.Add('V');
                    rindexasevic[i] = 2;
                    i++;
                    broj -= 4;
                }
                else if (broj >= 1)
                {
                    rimski += "I";
                    lrimski.Add('I');
                    rindexasevic[i] = 1;
                    i++;
                    broj -= 1;
                }
            }

            return rimski;
        }

        public void triBroja(char brojanovic, int lista)
        {
            if(lista == 1)
            {
                for(int i=0; i < zumajahad.Count(); i++)
                {
                    if (zumajahad[i] == brojanovic)
                    {
                        if (i < zumajahad.Count-3)
                        {
                            if (zumajahad[i + 1] == brojanovic)
                            {
                                if (zumajahad[i + 2] == brojanovic)
                                {
                                    if (zumajahad[i + 3] == brojanovic)
                                    {
                                        MessageBox.Show("Greska! Broj se ne moze ponoviti vise od 3 puta!");
                                        flagcic = 1;
                                        zumajahad.Clear();
                                        hadzenadin.Clear();
                                        resetIndexa();
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < hadzenadin.Count(); i++)
                {
                    if (hadzenadin[i] == brojanovic)
                    {
                        if (i < hadzenadin.Count - 3)
                        {
                            if (hadzenadin[i + 1] == brojanovic)
                            {
                                if (hadzenadin[i + 2] == brojanovic)
                                {
                                    if (hadzenadin[i + 3] == brojanovic)
                                    {
                                        {
                                            MessageBox.Show("Greska! Broj se ne moze ponoviti vise od 3 puta!");
                                            flagcic = 1;
                                            zumajahad.Clear();
                                            hadzenadin.Clear();
                                            resetIndexa();
                                            return;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    
                }
            }
        }

        public void resetIndexa()
        {
            Array.Clear(indexasevic, 0, indexasevic.Length);
            Array.Clear(indexasevanovic, 0, indexasevanovic.Length);
            Array.Clear(rindexasevic, 0, rindexasevic.Length);
            Array.Clear(vrednostZumajahad, 0, vrednostZumajahad.Length);
            Array.Clear(vrednostHadzenadin, 0, vrednostHadzenadin.Length);

        }
        private void button13_Click(object sender, EventArgs e)
        {
            prvif = 1;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            prvif = 0;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            player.URL = "sone.mp3";
            player.controls.play();
            
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            zumajahad.Clear();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            hadzenadin.Clear();
        }

        private void Form3_Leave(object sender, EventArgs e)
        {
            this.player.controls.stop();
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            player.controls.stop();
        }
    }
}
