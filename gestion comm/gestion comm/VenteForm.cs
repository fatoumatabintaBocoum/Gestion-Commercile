﻿using System;
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
    public partial class VenteForm : Form
    {
        public VenteForm()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-EL6NQK2;Integrated Security=True");

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
        private void populate()
        {
            Con.Open();
            string query = "select ProdName,ProdPrice from ProductTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ProdDGV1.DataSource = ds.Tables[0];             
            Con.Close();
        }
        private void populateBills()
        {
            Con.Open();
            string query = "select *from BillTbl"; 
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
          BillsDGV .DataSource = ds.Tables[0];
            Con.Close();
        }
        private void VenteForm_Load(object sender, EventArgs e)
        {
            populate();
            populateBills();
            fillcombo();
            ClientNamelbl.Text = Form1.ClientName;

        }
       

        private void ProdDGV1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ProdName.Text = ProdDGV1.SelectedRows[0].Cells[0].Value.ToString();
            ProdPrice.Text = ProdDGV1.SelectedRows[0].Cells[1].Value.ToString();
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Datelbl.Text = DateTime.Today.Day.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Year.ToString();
        }
        int Grdtotal = 0,n=0;
        private void button1_Click(object sender, EventArgs e)
        {
           
            if(ProdName.Text==""||ProdQty.Text == "")
            {
                MessageBox.Show("Missing data");
            }
            else { 
            int total= Convert.ToInt32(ProdPrice.Text) * Convert.ToInt32(ProdQty.Text);
            DataGridViewRow newRow = new DataGridViewRow();
            newRow.CreateCells(ORDERDGV);
            newRow.Cells[0].Value = n + 1;
            newRow.Cells[1].Value = ProdName.Text;
            newRow.Cells[2].Value = ProdPrice.Text;
            newRow.Cells[3].Value = ProdQty.Text;
            newRow.Cells[4].Value = Convert.ToInt32(ProdPrice.Text)* Convert.ToInt32(ProdQty.Text);
            ORDERDGV.Rows.Add(newRow);
            n++;
            Grdtotal = Grdtotal + total;
                Amtlbl.Text = "" + Grdtotal;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (BILLID.Text == "") 
            {
                MessageBox.Show("missing bill id");
            }
            else {

            
            try
            {
                Con.Open();
                string query = "insert into BillTbl values(" + BILLID.Text + ",'" + ClientNamelbl.Text + "','" + Datelbl.Text + "'," + Amtlbl.Text +")";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Order added successfully");
                Con.Close();
                populateBills();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
      }

        private void button6_Click(object sender, EventArgs e)
        {
            if(printPreviewDialog1.ShowDialog()== DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void BillsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("GlobalExpertise", new Font("Century Gothic", 25, FontStyle.Bold), Brushes.CadetBlue, new Point(230));
            e.Graphics.DrawString("Bill ID : " + BillsDGV.SelectedRows[0].Cells[0].Value.ToString(), new Font("Century Gothic", 20,FontStyle.Bold), Brushes.Teal, new Point(100, 70));
            e.Graphics.DrawString("CLIENT NAME : "+BillsDGV.SelectedRows[0].Cells[1].Value.ToString(), new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Teal, new Point(100, 100));
            e.Graphics.DrawString("DATE : " + BillsDGV.SelectedRows[0].Cells[2].Value.ToString(), new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Teal, new Point(100, 130));
            e.Graphics.DrawString("Total AMOUNT : " + BillsDGV.SelectedRows[0].Cells[3].Value.ToString(), new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Teal, new Point(100, 160));
            e.Graphics.DrawString("CodeSpace", new Font("Century Gothic", 20, FontStyle.Italic), Brushes.CadetBlue, new Point(230, 230));
            
        }
        private void fillcombo()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select CatName from CategoryTbl", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CatName", typeof(string));
            dt.Load(rdr);
            //tCb.ValueMember = "CatName";
            //atCb.DataSource = dt;
            SearchCb.ValueMember = "CatName";
            SearchCb.DataSource = dt;

            Con.Close();
        }

        private void SearchCb_SelectedIndexChanged(object sender, EventArgs e)
        {
               

        }

        private void button8_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void SearchCb_SelectionChangeCommitted(object sender, EventArgs e)
        {

            Con.Open();
            string query = "select ProdName,prodQty from productTbl where ProdCat='" + SearchCb.SelectedValue.ToString() + ";'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ProdDGV1.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Amtlbl_Click(object sender, EventArgs e)
        {

        }

        private void ORDERDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
