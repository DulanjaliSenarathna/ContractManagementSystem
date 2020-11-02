using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ContractManagementSystem.Forms;
using SLRDbConnector;

namespace ContractManagementSystem.UserControls
{
    public partial class UC_Works : UserControl
    {
        DbConnector db;
        public UC_Works()
        {
            InitializeComponent();
            db = new DbConnector();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (Form_AddWork fw = new Form_AddWork())
            {
                fw.ShowDialog();
                this.OnLoad(e);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void UC_Works_Load(object sender, EventArgs e)
        {
            db.fillDataGridView("select * from tblWorks", dataGridView1);
        }
    }
}
