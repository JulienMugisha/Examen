using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvolutionDemographique.formulaire
{
    public partial class splashscreen : Form
    {
        public splashscreen()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel1.Width += 5;
            if (panel1.Width >= 550)
            {
                timer1.Stop();
                Form1 lgn = new Form1();
                lgn.Show();
                this.Hide();
            }
        }

        private void splashscreen_Load(object sender, EventArgs e)
        {

        }

        
    }
}
