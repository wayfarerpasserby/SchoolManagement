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
    public partial class FormCurrentAY : Form
    {
        public FormCurrentAY()
        {
            InitializeComponent();
        }

        public FormCurrentAY(string AcademicYear)
        {
            InitializeComponent();
            this.AcademicYear = AcademicYear;
        }

        private string AcademicYear { get; set; }

        private void theAcademicYearBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.theAcademicYearBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.schoolDataSet);

        }

        private void FormCurrentAY_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'schoolDataSet.TheSchool' table. You can move, or remove it, as needed.
            this.theSchoolTableAdapter.FillSchools(this.schoolDataSet.TheSchool);
            // TODO: This line of code loads data into the 'schoolDataSet.TheAcademicYear' table. You can move, or remove it, as needed.
            //this.theAcademicYearTableAdapter.FillTheAcademicYears(this.schoolDataSet.TheAcademicYear);
            this.theAcademicYearTableAdapter.FillByAcademicYear(this.schoolDataSet.TheAcademicYear, AcademicYear);
            
        }

        private void firstSemesterEndDateDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            fSDaysNumberTextBox.Text = (firstSemesterEndDateDateTimePicker.Value - firstSemesterStartDateDateTimePicker.Value).Days.ToString();
        }

        private void secondSemesterEndDateDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            sSDaysNumberTextBox.Text = (secondSemesterEndDateDateTimePicker.Value - secondSemesterStartDateDateTimePicker.Value).Days.ToString();
        }
    }
}
