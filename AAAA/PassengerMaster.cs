using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AAAA
{
    public partial class PassengerMaster : Form
    {
        public PassengerMaster()
        {
            InitializeComponent();
            populate();
        }
        //SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\source\repos\RailwayPorject\RailwayProject.mdf;Integrated Security=True;Connect Timeout=30");

        SqlConnection Con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\Documents\2 ci kurs 2 ci semestr\OOP\RailwayTuto\RailwayTuto\RailwaysDb.mdf;Integrated Security = True; Connect Timeout = 30");

        private void populate()
        {
            Con.Open();
            string query = "select * from PASSENGERTBL";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            var ds = new DataSet();
            sda.Fill(ds);
            PassengerDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void PassengerMaster_Load(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton28_Click(object sender, EventArgs e) // ADD
        {
            string Gender = "";
            if (PnameTb.Text == "" || PPhoneTb.Text == "" || PaddressTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                if (MaleRd.Checked == true)
                {
                    Gender = "Male";
                }
                else if (FemaleRd.Checked == true)
                {
                    Gender = "Female";
                }

                try
                {

                    Con.Open();
                    string Query = "insert into PASSENGERTBL values('" + PnameTb.Text + "','" + PaddressTb.Text + "','" + Gender + "','" + AgeCb.SelectedItem.ToString() + "','" + PPhoneTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Passenger Added Successfully");
                    Con.Close();
                    populate();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        private void Reset()
        {
            PnameTb.Text = "";
            PaddressTb.Text = "";
            PPhoneTb.Text = "";
            MaleRd.Checked = false;
            FemaleRd.Checked = false;
            AgeCb.SelectedIndex = -1;
            key = 0;
        }

        private void bunifuThinButton26_Click(object sender, EventArgs e)  // Reset 
        {
            Reset();
        }
        int key = 0;

        private void PassengerDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PnameTb.Text = PassengerDGV.SelectedRows[0].Cells[1].Value.ToString();
            PaddressTb.Text = PassengerDGV.SelectedRows[0].Cells[2].Value.ToString();
            AgeCb.SelectedItem = PassengerDGV.SelectedRows[0].Cells[4].Value.ToString();
            PPhoneTb.Text = PassengerDGV.SelectedRows[0].Cells[5].Value.ToString();
            if (PnameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(PassengerDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e) //DELETE 
        {
            if (key == 0)
            {
                MessageBox.Show("Select The Passenger To Be Deleted");
            }
            else
            {
                try
                {

                    Con.Open();
                    string Query = "Delete from PASSENGERTBL where PId=" + key + "";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Passenger Deleted Successfully");
                    Con.Close();
                    populate();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void bunifuThinButton27_Click(object sender, EventArgs e) //EDIT
        {

            string Gender = "";
            if (PnameTb.Text == "" || PPhoneTb.Text == "" || PaddressTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                if (MaleRd.Checked == true)
                {
                    Gender = "Male";
                }
                else if (FemaleRd.Checked == true)
                {
                    Gender = "Female";
                }
                try
                {

                    Con.Open();
                    string Query = "update PASSENGERTBL set Pname='" + PnameTb.Text + "',PAdd='" + PaddressTb.Text + "',PGender='" + Gender + "',PAge='" + AgeCb.SelectedItem.ToString() + "',PPhone='" + PPhoneTb.Text + "' where PId=" + key + ";";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Passenger Updated Successfully");
                    Con.Close();
                    populate();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            MainForm Main = new MainForm();
            Main.Show();
            this.Hide();
        }
    }
}