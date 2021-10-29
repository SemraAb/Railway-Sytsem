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
    public partial class TravelMaster : Form
    {
        public TravelMaster()
        {
            InitializeComponent();
            populate();
            FillTCode();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\source\repos\RailwayPorject\RailwayProject.mdf;Integrated Security=True;Connect Timeout=30");

        //SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\source\repos\RailwayPorject\RailwayReservationDB.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            Con.Open();
            string query = "select * from TRAVELTBL";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            var ds = new DataSet();
            sda.Fill(ds);
            TravelDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void FillTCode()
        {
            string TrStatus = "Available";
            Con.Open();
            SqlCommand cmd = new SqlCommand("select TrainId from TRAINTBL where TrainStatus='" + TrStatus + "'", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("TrainId", typeof(int));
            dt.Load(rdr);
            TCode.ValueMember = "TrainId";
            TCode.DataSource = dt;
            Con.Close();
        }
        private void TravelMaster_Load(object sender, EventArgs e)
        {

        }
         private void label7_Click(object sender, EventArgs e)
         {
            Application.Exit();
         }
         private void label5_Click(object sender, EventArgs e)
         {

         }
        private void ChangeStatus()
        {
            string TrStatus = "Busy";

            try
            {

                Con.Open();
                string Query = "update TRAINTBL set TrainStatus='" + TrStatus + "' where TrainId=" + TCode.SelectedValue.ToString() + ";";
                SqlCommand cmd = new SqlCommand(Query, Con);
                cmd.ExecuteNonQuery();
                // MessageBox.Show("Train Updated Successfully");
                Con.Close();
                populate();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }



        private void bunifuThinButton22_Click(object sender, EventArgs e) // ADD
        {
            if (TCostTb.Text == "" || TCode.SelectedIndex == -1 || SrcCb.SelectedIndex == -1 || DestCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {

                    Con.Open();
                    string Query = "insert into TRAVELTBL values('" + TravDate.Value.Date.ToString("yyyy-MM-dd") + "','" + TCode.SelectedValue.ToString() + "','" + SrcCb.SelectedItem.ToString() + "','" + DestCb.SelectedItem.ToString() + "'," + TCostTb.Text + ")";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Travel Added Successfully");
                    Con.Close();
                    populate();
                    ChangeStatus();
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
            SrcCb.SelectedIndex = -1;
            DestCb.SelectedIndex = -1;
            //TCode.SelectedIndex = -1;
            TCostTb.Text = "";
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e) //RESET
        {
            Reset();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e) // EDIT
        {

            if (SrcCb.SelectedIndex == -1 || DestCb.SelectedIndex == -1 || TCostTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {

                    Con.Open();
                    string Query = "update TRAVELTBL set TravDate='" + TravDate.Text  + "',Train=" + TCode.SelectedValue.ToString() + ",Src='" + SrcCb.SelectedItem.ToString() + "',Dest='" + DestCb.SelectedItem.ToString() + "',Cost=" + TCostTb.Text + " where TravCode=" + key + ";";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Travel Updated Successfully");
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
        int key = 0;

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TravelDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            TravDate.Text = TravelDGV.SelectedRows[0].Cells[1].Value.ToString();
            TCode.SelectedValue = TravelDGV.SelectedRows[0].Cells[2].Value.ToString();
            SrcCb.SelectedItem = TravelDGV.SelectedRows[0].Cells[3].Value.ToString();
            DestCb.SelectedItem = TravelDGV.SelectedRows[0].Cells[4].Value.ToString();
            TCostTb.Text = TravelDGV.SelectedRows[0].Cells[5].Value.ToString();
            if (TCode.SelectedIndex == -1)
            {
                key = 0;
                // TCostTb.Text = "";
                //   SrcCb.SelectedIndex = -1;
                // DestCb.SelectedIndex = -1;
            }
            else
            {
                key = Convert.ToInt32(TravelDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            MainForm Main = new MainForm();
            Main.Show();
            this.Hide();
        }

        private void TravDate_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}