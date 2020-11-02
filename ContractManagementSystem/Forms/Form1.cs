using ContractManagementSystem.Forms;
using SLRDbConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ContractManagementSystem
{
    public partial class Form1 : Form
    {
        DbConnector db;
        public Form1()
        {
            InitializeComponent();
            db = new DbConnector();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6jjhhhhh_Click(object sender, EventArgs e)
        {
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (isFormVal())
            {
                if (checkLogin())
                {
                    using (Form_Dashboard fd = new Form_Dashboard())
                    {
                        fd.ShowDialog();
                        this.Close();
                    }
                }

            }
        }

        private bool checkLogin()
        {
            string username = db.getSingleValue("select UserName from tblUsers where UserName = '" + txtUserName.Text + "' and Password = '" + txtPassword.Text + "'", out username,0);

            if(username == null)
            {
                MessageBox.Show("User Name or Password is incorrect", "Incorrect Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool isFormVal()
        {
            if (txtUserName.Text.ToString().Trim() == string.Empty || txtPassword.Text.ToString().Trim() == string.Empty)
            {
                MessageBox.Show("Required Fields are empty, Please fill all required fields..", "Caption", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
