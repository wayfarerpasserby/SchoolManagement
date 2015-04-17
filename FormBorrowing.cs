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
    public partial class FormBorrowing : Form
    {
        public FormBorrowing()
        {
            InitializeComponent();
        }

        private void borrowingBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.borrowingBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.schoolDataSet);
            
        }

        private void FormBorrowing_Load(object sender, EventArgs e)
        {
            
            // TODO: This line of code loads data into the 'schoolDataSet.TheAcademicYear' table. You can move, or remove it, as needed.
            this.theAcademicYearTableAdapter.FillTheAcademicYears(this.schoolDataSet.TheAcademicYear);

            // TODO: This line of code loads data into the 'schoolDataSet.Grade' table. You can move, or remove it, as needed.
            this.gradeTableAdapter.FillByAcademicYear(this.schoolDataSet.Grade, comboBoxYearLibrary.Text);

            // TODO: This line of code loads data into the 'schoolDataSet.Classroom' table. You can move, or remove it, as needed.
            this.classroomTableAdapter.FillByGradeNameAcademicYear(this.schoolDataSet.Classroom, comboBoxGradeLibrary.Text, comboBoxYearLibrary.Text);

            // TODO: This line of code loads data into the 'schoolDataSet.Library' table. You can move, or remove it, as needed.
            this.libraryTableAdapter.FillLibraries(this.schoolDataSet.Library);

            // TODO: This line of code loads data into the 'schoolDataSet.Student' table. You can move, or remove it, as needed.
            this.studentTableAdapter.FillByClassroomId(this.schoolDataSet.Student, int.Parse(comboBoxClassroomLibrary.SelectedValue.ToString()));

            // TODO: This line of code loads data into the 'schoolDataSet.Borrowing' table. You can move, or remove it, as needed.
            this.borrowingTableAdapter.FillBorrowings(this.schoolDataSet.Borrowing);

            
        }

        private void comboBoxGradeLibrary_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.classroomTableAdapter.FillByGradeNameAcademicYear(this.schoolDataSet.Classroom, comboBoxGradeLibrary.Text, comboBoxYearLibrary.Text);
        }

        private void comboBoxClassroomLibrary_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.studentTableAdapter.FillByClassroomId(this.schoolDataSet.Student, int.Parse(comboBoxClassroomLibrary.SelectedValue.ToString()));
        }
    }
}
