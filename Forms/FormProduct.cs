using Market_Automation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Market_Automation.Forms
{
    public partial class FormProduct : Form
    {   
        
        marketDBEntities db = new marketDBEntities();
        public FormProduct()
        {
            InitializeComponent();
        }
        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btns.BackColor = ThemeColor.PrimaryColor;
                    btns.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
            label4.ForeColor = ThemeColor.SecondaryColor;
            label5.ForeColor = ThemeColor.PrimaryColor;
        }
        private void FormProduct_Load(object sender, EventArgs e)
        {
            try
            {
                LoadTheme();
                dataGridView1.DataSource = db.productsTB.ToList();
                // dataGridView1.DataSource = db.productsTB.Select(p => new { p.productID, p.product_UnitPrice, p.product_KgPrice }).ToList();
            }
            catch (Exception error )
            {
                MessageBox.Show("Error: " + error.Message);
            }
            

        }

        private void save_Click(object sender, EventArgs e)
        {
            productsTB prodb = new productsTB();
            prodb.productName = urun_name.Text;
            prodb.product_UnitPrice = Convert.ToDouble(birim_fiyat.Text);
            prodb.product_KgPrice=Convert.ToDouble(kg_fiyat.Text);

            db.productsTB.Add(prodb);
            db.SaveChanges();
            dataGridView1.DataSource = db.productsTB.ToList();



        }

    }
}
