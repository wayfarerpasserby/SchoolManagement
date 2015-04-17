using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Project_SVU_ISE_PR1
{
    public partial class FormTheSchool : Form
    {
        public FormTheSchool()
        {
            InitializeComponent();
        }

        private void theSchoolBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (schoolNameTextBox.Text != "")
            {
                this.Validate();
                this.theSchoolBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.schoolDataSet);
            }

        }

        private void FormTheSchool_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'schoolDataSet.TheSchool' table. You can move, or remove it, as needed.
            this.theSchoolTableAdapter.FillSchools(this.schoolDataSet.TheSchool);

        }
    }
}
