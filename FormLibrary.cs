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
    public partial class FormLibrary : Form
    {
        public FormLibrary()
        {
            InitializeComponent();
        }

        private void libraryBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.libraryBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.schoolDataSet);

        }

        private void FormLibrary_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'schoolDataSet.TheSchool' table. You can move, or remove it, as needed.
            this.theSchoolTableAdapter.FillSchools(this.schoolDataSet.TheSchool);
            // TODO: This line of code loads data into the 'schoolDataSet.Library' table. You can move, or remove it, as needed.
            this.libraryTableAdapter.FillLibraries(this.schoolDataSet.Library);

        }

        private void buttonBorrowing_Click(object sender, EventArgs e)
        {
            FormBorrowing f = new FormBorrowing();
            f.Show();
        }
    }
}
