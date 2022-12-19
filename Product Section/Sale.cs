using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Market_Automation.Product_Section
{
    public partial class Sale : Form
    {
        SqlConnection con = new SqlConnection(@"Data source=.; initial catalog=marketDB; integrated Security=True");
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;

        private ArrayList ticket_products = new ArrayList();
        private ArrayList ticket_counts = new ArrayList();
        private ArrayList ticket_prices = new ArrayList();
        private ArrayList products = new ArrayList();
        private ArrayList types = new ArrayList();

        public Sale()
        {
            InitializeComponent();
        }

        private void Sale_Load(object sender, EventArgs e)
        {

        }
    }
}
