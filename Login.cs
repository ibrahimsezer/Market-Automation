using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Market_Automation
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUsername_Click(object sender, EventArgs e)
        {
            txtUsername.BackColor = Color.White;
            panel3.BackColor = Color.White;
            panel4.BackColor = SystemColors.Control;
            txtPassword.BackColor = SystemColors.Control;
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            txtPassword.BackColor = Color.White;
            panel4.BackColor = Color.White;
            txtUsername.BackColor = SystemColors.Control;
            panel3.BackColor = SystemColors.Control;
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = false;
        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        internal class loginClass
        {
            SqlConnection con = new SqlConnection(@"Data source=.;initial catalog=marketDB; integrated Security=True");
            SqlCommand cmd;
            SqlDataReader dr;
            public void loginActivity(string username, string password, Login loginPage)
            {
                try
                {
                    cmd = new SqlCommand("Select * From userTB where userName='" + username + "' and userPassword='" + password + "'", con);
                    con.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        dr.Close();
                        string condition = "SELECT * FROM userTB WHERE EXISTS(SELECT * FROM userTB WHERE userAuthority = 'Admin')";
                        cmd = new SqlCommand(condition, con);
                        dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            MessageBox.Show("You have successfully logged in", "Informing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Login login = new Login();
                            login.Hide();
                            MainMenu mm = new MainMenu();
                            mm.Show();
                        }  
                    }
                    else
                    {
                        loginPage.BackColor = Color.Red;
                        MessageBox.Show("You entered your information incorrectly.", "You Could Not Log in", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        loginPage.BackColor = default(Color);
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error: " + error.Message);
                }
                con.Close();
                cmd.Dispose();
            }
        }
        private void loginbtn_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            loginClass getLogin = new loginClass();
            getLogin.loginActivity(username, password, this);
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string username = txtUsername.Text;
                string password = txtPassword.Text;
                loginClass getLogin = new loginClass();
                getLogin.loginActivity(username, password, this);
            }
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                VisitLink();
            }
            catch (Exception error)
            {
                MessageBox.Show("Unable to open link that was clicked. " + error.Message);
            }
        }
        private void VisitLink()
        {
            // Change the color of the link text by setting LinkVisited
            linkLabel1.LinkVisited = true;

            //Call the Process.

            //System.Diagnostics.Process.Start("http://www.microsoft.com"); //with this method we go to the link

            //System.Diagnostics.Process.Start("mailto:" + linkLabel1.Text) ;//with this method, the sending e-mail part opens

            System.Diagnostics.Process.Start("mailto:yesirensar@gmail.com");
        }

        private void forgetPasswordbtn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://ensaryesir.great-site.net");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
