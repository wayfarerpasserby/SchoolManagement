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
    public partial class FormCurrentAYNewStudentReg : Form
    {
        public FormCurrentAYNewStudentReg()
        {
            InitializeComponent();
        }

        public string strAYNewStudentReg { get; set; }
        public int strPrFIdNewStudentReg { get; set; }

        private void studentBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.studentBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.schoolDataSet);

        }

        private void FormCurrentAYNewStudentReg_Load(object sender, EventArgs e)
        {
            // strAYNewStudentReg comes form FormCurrentAcademicYearWorks loading with FormCurrentAcademicYearWorks.lblAYear.Text
            lblAYNewStudentReg.Text = strAYNewStudentReg;

            // Aotu fill of known fields
            academicYearTextBox.Text = lblAYNewStudentReg.Text;

            // TODO: This line of code loads data into the 'schoolDataSet.Grade' table. You can move, or remove it, as needed.
            this.gradeTableAdapter.FillByAcademicYear(this.schoolDataSet.Grade,lblAYNewStudentReg.Text);

            // TODO: This line of code loads data into the 'schoolDataSet.Classroom' table. You can move, or remove it, as needed.
            //this.classroomTableAdapter.FillClassrooms(this.schoolDataSet.Classroom);
            this.classroomTableAdapter.FillByGradeNameAcademicYear(this.schoolDataSet.Classroom, comboBoxGrNewStudentReg.Text, lblAYNewStudentReg.Text);

            // TODO: This line of code loads data into the 'schoolDataSet.Student' table. You can move, or remove it, as needed.
            //this.studentTableAdapter.FillStudents(this.schoolDataSet.Student);
            
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            // Auto fill of known fields
            academicYearTextBox.Text = lblAYNewStudentReg.Text;
        }

        private void comboBoxGrNewStudentReg_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.classroomTableAdapter.FillByGradeNameAcademicYear(this.schoolDataSet.Classroom,comboBoxGrNewStudentReg.Text,lblAYNewStudentReg.Text);
            
        }

        private void buttonNewPresenceFile_Click(object sender, EventArgs e)
        {
            FormCurrentAYPresenceFile f = new FormCurrentAYPresenceFile();
            
            f.Show();
        }

        private void buttonNewPersonalFile_Click(object sender, EventArgs e)
        {
            FormCurrentAYPersonalFile f = new FormCurrentAYPersonalFile();
            f.Show();
        }
    }
}
