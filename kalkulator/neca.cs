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
    public partial class neca : Form
    {
        public neca()
        {
            InitializeComponent();
            label1.Parent = pictureBox1;
            pictureBox2.Parent = pictureBox1;
            pictureBox3.Parent = pictureBox1;
            pictureBox4.Parent = pictureBox1;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void neca_Load(object sender, EventArgs e)
        {
            
        }
    }
}
