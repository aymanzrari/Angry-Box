using System;
using System.Media;
using System.Windows.Forms;

namespace ProjetPictue
{
    public partial class Games : Form
    {
        SoundPlayer simpleSound = new SoundPlayer(@"son/son.wav");
        GameEngine gameEngine;
        public Games()
        {
            InitializeComponent();

            Program.FlowLayoutPanel = flowLayoutPanel_grid;
            gameEngine = GameEngine.GetInstance();
        }

        
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to exit the game?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }

        private void Games_Load(object sender, EventArgs e)
        {
            label_score.Text = gameEngine.Player.Score.ToString();
            label_highScore.Text = gameEngine.HighScore.ToString();
            label_time.Text = gameEngine.Time.ToString();
            label_highScore.Text = Properties.Settings.Default.HighScore.ToString();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            gameEngine.Time = gameEngine.Time.Add(TimeSpan.FromSeconds(1));
            label_time.Text = gameEngine.Time.ToString();
            label_score.Text = gameEngine.Player.Score.ToString();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void stopSon_Click(object sender, EventArgs e)
        {
            stopSon.Hide();
            simpleSound.Stop();
            startSon.Show();
        }

        private void startSon_Click(object sender, EventArgs e)
        {
            startSon.Hide();
            simpleSound.Play();
            stopSon.Show();
        }
    }
}
