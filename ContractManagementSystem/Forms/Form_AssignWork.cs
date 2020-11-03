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
    public partial class Form_AssignWork : Form
    {
        public string workId { get; set; }
        public string workTitle { get; set; }
        public string TsAmount { get; set; }

        DbConnector db;
        public Form_AssignWork()
        {
            InitializeComponent();
            db = new DbConnector();
        }

        private void cmbContractor_SelectedIndexChanged(object sender, EventArgs e)
        {
            string address;
            db.getSingleValue("select address from tblContractors where full_name='" + cmbContractor.SelectedItem.ToString() + "' ", out address, 0);
            txtAddress.Text = address;
        }

        private void Form_AssignWork_Load(object sender, EventArgs e)
        {
            db.FillCombobox("select full_name from tblContractors", cmbContractor);
            txtWorkTitle.Text = workTitle;
            txtTsAmount.Text = TsAmount;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        string ContractorId;
        private void cmbContractor_Leave(object sender, EventArgs e)
        {
            db.getSingleValue("select id from tblContractors where full_name= '" + cmbContractor.Text + "' name address = '" + txtAddress.Text + "'", out ContractorId, 0);
            if(ContractorId == null)
            {
                MessageBox.Show("Contractor not found.. Please Add a Contractor First", "Contractor not found", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(isFormValid())
            {

            }
        }

        private bool isFormValid()
        {
            if (ContractorId == null)
            {
                MessageBox.Show("Contractor not found.. Please Add a Contractor First", "Contractor not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }else if(cmbContractor.Text.Trim() == string.Empty || cmbYear.Text.Trim() == string.Empty || txtCACost.Text.Trim() == string.Empty || txtAssignDate.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Fill all required fields", "Required Fields are Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
            else
            {
                return true;
            }
        }
    }
}
