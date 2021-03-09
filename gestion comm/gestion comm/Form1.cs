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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static string ClientName = "";
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-EL6NQK2;Integrated Security=True");

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            UsernameTb.Text = "";
            PassTb.Text = "";

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if(UsernameTb.Text=="" || PassTb.Text=="")
            {
                MessageBox.Show("Enter the username and password");
            }
            else
            {
                if (RoleCb.SelectedIndex > -1) { 
                if(RoleCb.SelectedItem.ToString()=="ADMIN")
                {
                    if (UsernameTb.Text == "Admin" && PassTb.Text == "Admin") 
                    {
                        ProductForm prod = new ProductForm();
                        prod.Show();
                        this.Hide();
                    }
                    else
                        {
                        MessageBox.Show("if you are the admin, enter the correct id and password");
                    }
                }
                    else
                    {
                        // MessageBox.Show("you are in the seller section");
                        Con.Open();
                        SqlDataAdapter sda = new SqlDataAdapter("select count(8) from ClientTbl where ClientName='"+UsernameTb.Text+"'and ClientPass='"+PassTb.Text+"'",Con);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        if (dt.Rows[0][0].ToString() == "1")
                        {
                            ClientName = UsernameTb.Text;
                            VenteForm sell = new VenteForm();
                            sell.Show();
                            this.Hide();
                            Con.Close();
                        }
                        else
                        {
                            MessageBox.Show("wrong username or password");
                        }
                        Con.Close();
                    }
               
                }
                else
                {
                    MessageBox.Show("select a Role");
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void UsernameTb_OnValueChanged(object sender, EventArgs e)
        {

        }
    }
}
