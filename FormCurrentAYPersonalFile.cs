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
    public partial class FormCurrentAYPersonalFile : Form
    {
        public FormCurrentAYPersonalFile()
        {
            InitializeComponent();
        }

        public FormCurrentAYPersonalFile(int PersonalFileId)
        {
            InitializeComponent();
            this.PersonalFileId = PersonalFileId;
        }

        private int PersonalFileId { get; set; }

        private void personalFileBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.personalFileBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.schoolDataSet);

        }

        private void FormCurrentAYPersonalFile_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'schoolDataSet.PersonalFile' table. You can move, or remove it, as needed.
            //this.personalFileTableAdapter.FillPersonalFiles(this.schoolDataSet.PersonalFile);
            this.personalFileTableAdapter.FillByPersonalFileId(this.schoolDataSet.PersonalFile, PersonalFileId);

        }
    }
}
