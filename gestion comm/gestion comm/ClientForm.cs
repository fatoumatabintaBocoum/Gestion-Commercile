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
namespace Globalexpertise
{
    public partial class ClientForm : Form
    {
        public ClientForm()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-EL6NQK2;Integrated Security=True");
        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void ClientForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                string query = "insert into ClientTbl values(" + ClientId.Text + ",'" + ClientName.Text + "'," + ClientAge.Text + "," + ClientPhone.Text + ",'" + ClientPass.Text + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Client added successfully");
                Con.Close();
                populate();
                ClientId.Text = "";
                ClientName.Text = "";
                ClientPhone.Text = "";
                ClientPass.Text = "";
                ClientAge.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void populate()
        {
            Con.Open();
            string query = "select * from ClientTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            SellerDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ClientId.Text = SellerDGV.SelectedRows[0].Cells[0].Value.ToString();
            ClientName.Text =SellerDGV.SelectedRows[0].Cells[1].Value.ToString();
            ClientAge.Text = SellerDGV.SelectedRows[0].Cells[2].Value.ToString();
            ClientPhone.Text = SellerDGV.SelectedRows[0].Cells[3].Value.ToString();
            ClientPass.Text = SellerDGV.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (ClientId.Text == "" || ClientName.Text == "" || ClientAge.Text == "" || ClientPhone.Text == "" || ClientPass.Text== "")
                {
                    MessageBox.Show("missing information");
                }
                else
                {
                    Con.Open();
                    string query = "update ClientTbl set ClientName='" + ClientName.Text + "',ClientAge=" + ClientAge.Text + ",ClientPhone='" + ClientPhone.Text + "',ClientPass='" + ClientPass + "'where ClientId=" + ClientId.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("client successfully update");
                    Con.Close();
                    populate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (ClientId.Text == "")
                {
                    MessageBox.Show("select the client to delete");
                }
                else
                {
                    Con.Open();
                    string query = "delete from ClientTbl where ClientId=" + ClientId.Text + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("client deleted successfully");
                    Con.Close();
                    populate();
                    ClientId.Text="";
                    ClientName.Text="";
                    ClientPhone.Text = "";
                    ClientPass.Text = "";
                    ClientAge.Text = "";

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            CATEGORYForm cat = new CATEGORYForm();
            cat.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProductForm prod = new ProductForm();
            prod.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();
        }
    }
}
