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
            if(workId != null)
            {
                using (Form_AssignWork fw = new Form_AssignWork())
                {
                    fw.workId = workId;
                    fw.workTitle = title;
                    fw.TsAmount = TsAmount;
                    fw.ShowDialog();
                    this.OnLoad(e);
                }
            }
        }

        private void UC_Works_Load(object sender, EventArgs e)
        {
            db.fillDataGridView("select * from tblWorks", dataGridView1);
        }

        private string workId, title, TsAmount;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView1.SelectedRows)
            {
                workId = item.Cells[0].Value.ToString();
                title = item.Cells[1].Value.ToString();
                TsAmount = item.Cells[4].Value.ToString();

            }
        }
    }
}
