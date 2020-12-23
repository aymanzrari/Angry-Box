using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Media;

namespace ProjetPictue
{
    public partial class home : Form
    {
        public home()
        {
            InitializeComponent();
        }
        SoundPlayer simpleSound = new SoundPlayer(@"son/son.wav");

        private void home_Load(object sender, EventArgs e)
        {
        }
        private void startSon_Click(object sender, EventArgs e)
        {
            startSon.Hide();
            simpleSound.Play();
            stopSon.Show();
        }

        private void stopSon_Click(object sender, EventArgs e)
        {
            stopSon.Hide();
            simpleSound.Stop();
            startSon.Show();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void play_Click(object sender, EventArgs e)
        {
            Games gm = new Games();
            gm.FormClosed += (x, ex) => this.Show();
            gm.Show();
            this.Hide();
        }
    }
}
