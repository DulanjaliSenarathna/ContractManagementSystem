using SLRDbConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ContractManagementSystem.Forms
{
    public partial class Form_AddWork : Form
    {
        DbConnector db;
        public Form_AddWork()
        {
            InitializeComponent();
            db = new DbConnector();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form_AddWork_Load(object sender, EventArgs e)
        {
            db.FillCombobox("select Name from tblWorkTypes", cmbTypes);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isFormValid())
            {
                insertValues();
            }
        }

        private void insertValues()
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure want to add this work?","Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                string type_id = db.getSingleValue("select id from tblWorkTypes where Name = '" + cmbTypes.Text + "'", out type_id, 0);
                db.performCRUD("insert into tblWorks (title,location,ts_number,ts_amount,type_id) Values ('"+txtTitle.Text+ "','" + txtLocation.Text + "','" + txtTsNo.Text + "','" + txtAmount.Text + "','"+type_id+"')");
                MessageBox.Show("Work Added Successfully....!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
        }

        private bool isFormValid()
        {
            if(txtTitle.Text.Trim() == string.Empty
                || txtLocation.Text.Trim() == string.Empty
                || txtTsNo.Text.Trim() == string.Empty
                || txtAmount.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Required Fields are empty, Please fill all required fields..", "Caption", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
