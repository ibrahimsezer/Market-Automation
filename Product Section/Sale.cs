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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using System.IO;
using System.Drawing.Printing;
using System.Security;
using System.Security.Cryptography;
using System.Runtime.InteropServices;

namespace Market_Automation.Product_Section
{
    public partial class Sale : Form
    {
        SqlConnection con = new SqlConnection(@"Data source=.; initial catalog=marketDB; integrated Security=True");
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;
        public Sale()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string constr = @"Data source=.; initial catalog=marketDB; integrated Security=True";
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("select * from productsTB where productsID = '" + txtBarcode.Text + "'"))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            dr.Read();
                            lblBarcode.Text = dr["productsID"].ToString();
                            lblName.Text = dr["productsName"].ToString();
                            txtUnitPrice.Text = dr["product_UnitPrice"].ToString();
                            txtKgPrice.Text = dr["product_KgPrice"].ToString();
                            lblUnitPrice.Text = dr["product_UnitPrice"].ToString();
                            lblKgPrice.Text = dr["product_KgPrice"].ToString();
                            lblCategory.Text = dr["categoryName"].ToString();
                            lblTotalUnit.Text = dr["productUnitCount"].ToString();
                            lblTotalWeight.Text = dr["productKgCount"].ToString();
                        }
                        con.Close();
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error);
            }
            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            lblBarcode.Text = "";
            lblName.Text = "";
            txtUnitPrice.Text = "";
            txtKgPrice.Text = "";
            lblUnitPrice.Text = "";
            lblKgPrice.Text = "";
            lblCategory.Text = "";
            lblTotalUnit.Text = "";
            lblTotalWeight.Text = "";

            txtUnitPrice.Text = "";
            txtKgPrice.Text = "";
            txtBarcode.Text = "";
            unitCount.Text = "0";        
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int Kg = int.Parse(txtKgPrice.Text);
            int Unit = int.Parse(txtUnitPrice.Text);
            int total = (Kg + Unit) * int.Parse(unitCount.Text);
            string totalPrice = Convert.ToString(total);
            listReceipt.Items.Add(unitCount.Text + " Unit, Kg Price:" + txtKgPrice.Text + ", Unit Price:" + txtUnitPrice.Text + ", Total Price:" + totalPrice);
            lbltotalPrice.Text = (totalPrice);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            lblBarcode.Text = "";
            lblName.Text = "";
            txtUnitPrice.Text = "";
            txtKgPrice.Text = "";
            lblUnitPrice.Text = "";
            lblKgPrice.Text = "";
            lblCategory.Text = "";
            lblTotalUnit.Text = "";
            lblTotalWeight.Text = "";

            txtUnitPrice.Text = "";
            txtKgPrice.Text = "";
            txtBarcode.Text = "";
            unitCount.Text = "0";

            listReceipt.Items.Clear();
        }

        private void btnCut_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.Document = printDocument1;
            ppd.Document.DocumentName = "TESTING";
            printDocument1.PrintPage += printDocument1_PrintPage;
            ppd.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.PageUnit = GraphicsUnit.Millimeter;
            int leading = 5;
            int leftMargin = 80;
            int topMargin = 10;

            // a few simple formatting options..
            StringFormat FmtRight = new StringFormat() { Alignment = StringAlignment.Far };
            StringFormat FmtLeft = new StringFormat() { Alignment = StringAlignment.Near };
            StringFormat FmtCenter = new StringFormat() { Alignment = StringAlignment.Near };

            StringFormat fmt = FmtRight;

            using (Font font = new Font("Arial Narrow", 12f))
            {
                SizeF sz = e.Graphics.MeasureString("_|", Font);
                float h = sz.Height + leading;

                for (int i = 0; i < listReceipt.Items.Count; i++)
                    e.Graphics.DrawString(listReceipt.Items[i].ToString(), font, Brushes.Black, leftMargin, topMargin + h * i, fmt);
            }
        }
    }
}
