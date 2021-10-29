using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AAAA
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            label8.Parent = pictureBox7;
            label8.BackColor = Color.Transparent;

            label9.Parent = pictureBox7;
            label9.BackColor = Color.Transparent;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            TrainMaster TM = new TrainMaster();
            TM.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            PassengerMaster Ps = new PassengerMaster();
            Ps.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            TravelMaster Tr = new TravelMaster();
            Tr.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            ReservationMaster Res = new ReservationMaster();
            Res.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            CancellationMaster Cancel = new CancellationMaster();
            Cancel.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            TrainMaster TM = new TrainMaster();
            TM.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            PassengerMaster PS = new PassengerMaster();
            PS.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            TravelMaster Tr = new TravelMaster();
            Tr.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

            ReservationMaster Res = new ReservationMaster();
            Res.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            CancellationMaster Cancel = new CancellationMaster();
            Cancel.Show();
            this.Hide();
        }
    }
}