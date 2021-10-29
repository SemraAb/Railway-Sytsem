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
    public partial class ReservationMaster : Form
    {
        public ReservationMaster()
        {
            InitializeComponent();
            populate();
            FillPid();
            FillTravCode();
        }
        private void bunifuThinButton22_Click(object sender, EventArgs e) // ADD RESERVATION 
        {

            if (TravelCb.SelectedIndex == -1 || PIdCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {

                    Con.Open();
                    string Query = "insert into RESERVATIONTBL values(" + PIdCb.SelectedItem.ToString() + ",'" + pname + "','" + TravelCb.SelectedItem.ToString() + "','" + Datee + "','" + Src + "','" + Dest + "'," + Cost + ")";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Reservation Accepted");
                    Con.Close();
                    populate();
                    // Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }

        }

       SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\source\repos\RailwayPorject\RailwayProject.mdf;Integrated Security=True;Connect Timeout=30");

     //db , elave   SqlConnection Con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\Documents\2 ci kurs 2 ci semestr\OOP\RailwayTuto\RailwayTuto\RailwaysDb.mdf;Integrated Security = True; Connect Timeout = 30");



        private void populate()
        {
            Con.Open();
            string query = "select * from RESERVATIONTBL";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            var ds = new DataSet();
            sda.Fill(ds);
            ReservationDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void FillPid()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select Pid from PassengerTbl", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Pid", typeof(int));
            dt.Load(rdr);
            PIdCb.ValueMember = "Pid";
            PIdCb.DataSource = dt;
            Con.Close();
        }
        private void FillTravCode()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select TravCode from TravelTbl", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("TravCode", typeof(int));
            dt.Load(rdr);
            TravelCb.ValueMember = "TravCode";
            TravelCb.DataSource = dt;
            Con.Close();
        }
        string pname;
        private void GetPName()
        {
            Con.Open();
            string mysql = "select * from PassengerTbl where Pid=" + PIdCb.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(mysql, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                pname = dr["PName"].ToString();
            }
            Con.Close();
            //MessageBox.Show(pname);
        }

        string Datee, Src, Dest;
        int Cost;
        private void GetTravel()
        {
            Con.Open();
            string mysql = "select * from TravelTbl where TravCode=" + TravelCb.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(mysql, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {

                Datee = dr["TravDate"].ToString();
                Src = dr["Src"].ToString();
                Dest = dr["Dest"].ToString();
                Cost = Convert.ToInt32(dr["Cost"].ToString());
            }
            Con.Close();
            // MessageBox.Show(Date+Src+Dest+Cost);
        }

        private void TravelCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetTravel();
        }  
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            MainForm Main = new MainForm();
            Main.Show();
            this.Hide();
        }
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void label9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

  

        private void PIdCb_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            GetPName();
        }

        private void ReservationMaster_Load(object sender, EventArgs e)
        {

        }
    }
}