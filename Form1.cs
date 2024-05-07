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
using System.Configuration;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Form_Test_Fail
{
    public partial class Form1 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataTable dt;

        // 0 references

        public void ShowDataOnGridview()
        {
            using (con = new SqlConnection(cs))
            {
                adapter = new SqlDataAdapter("Select * From CarsTable", con);
                dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewCars.DataSource = dt;
            }
        }
        public Form1()
        {
            InitializeComponent();
            ShowDataOnGridview();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewCars_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label6.Text = this.dataGridViewCars.CurrentRow.Cells["Brand"].Value.ToString();

            Model.Text = this.dataGridViewCars.CurrentRow.Cells["Model"].Value.ToString();
            YearBox.Text = this.dataGridViewCars.CurrentRow.Cells["Year"].Value.ToString();
            FuelBox.Text = this.dataGridViewCars.CurrentRow.Cells["Fuel"].Value.ToString();            Brand.Text = this.dataGridViewCars.CurrentRow.Cells["Brand"].Value.ToString();
            Brand.Text = this.dataGridViewCars.CurrentRow.Cells["VehicleBrand"].Value.ToString();
        }

        private void YearBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Model_TextChanged(object sender, EventArgs e)
        {

        }

        private void Add_Click(object sender, EventArgs e)
        {
            using (con = new SqlConnection(cs))
            {
                con.Open();
                cmd = new SqlCommand("Insert Into CarsTable (Model, Year, Fuel, VehicleBrand) Values (@model, @year, @fuel, @vehiclebrand)", con);
                cmd.Parameters.AddWithValue("@model", Model.Text);
                cmd.Parameters.AddWithValue("@year", Model.Text);
                cmd.Parameters.AddWithValue("@fuel", FuelBox.Text);
                cmd.Parameters.AddWithValue("@vehiclebrand", Brand.Text);


                cmd.ExecuteNonQuery();

                con.Close();

                MessageBox.Show("Data inserted successfully");
                ShowDataOnGridview();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (con = new SqlConnection(cs))
            {
                con.Open();

                cmd = new SqlCommand("Delete From CarsTable Where Brand=@brand", con);
                cmd.Parameters.AddWithValue("@brand", label6.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                ShowDataOnGridview();
            }

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (con = new SqlConnection(cs))
            {
                con.Open();
                cmd = new SqlCommand("UPDATE CarsTable Set Model=@model, Year=@year, Fuel=@fuel, VehicleBrand=@vehiclebrand Where Brand=@brand", con);
                cmd.Parameters.AddWithValue("@model", Model.Text);
                cmd.Parameters.AddWithValue("@year", YearBox.Text); // Changed from Model.Text to Year.Text
                cmd.Parameters.AddWithValue("@fuel", FuelBox.Text);
                cmd.Parameters.AddWithValue("@vehiclebrand", Brand.Text);
                cmd.Parameters.AddWithValue("@brand", label6.Text);


                cmd.ExecuteNonQuery();

                con.Close();

                MessageBox.Show("Data updated successfully");
                ShowDataOnGridview();
            }
        }

    }
}
