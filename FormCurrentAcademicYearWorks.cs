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
    public partial class FormCurrentAcademicYearWorks : Form
    {
        public FormCurrentAcademicYearWorks()
        {
            InitializeComponent();
        }

        public string lblAcademicYear { get; set; }

        private void FormCurrentAcademicYear_Load(object sender, EventArgs e)
        {
            lblAYear.Text = lblAcademicYear;
            // lblAcademicYear comes for FormStart loading with FormStart.comboBoxCurrentAY.Text
        }

        private void buttonUpdateStudentStudyFile_Click(object sender, EventArgs e)
        {
            FormCurrentAYStudentStudyFile f = new FormCurrentAYStudentStudyFile();
            // sending lblAyear.text to FormStudentStudyFile to fill by it
            f.strAYStudentStudyFile = lblAYear.Text;
            f.Show();
            /*FormStudentStudyFile f = new FormStudentStudyFile();
            // sending lblAyear.text to FormStudentStudyFile to fill by it
            f.lblssfAcademicYear = lblAYear.Text;
            f.Show();*/
            
        }

        private void buttonUpdateCurrentAcademicYear_Click(object sender, EventArgs e)
        {
            FormCurrentAY f = new FormCurrentAY(lblAYear.Text);
            f.Show();
        }

        private void buttonUpdateCurrentAYGrade_Click(object sender, EventArgs e)
        {
            FormCurrentAYGrade f = new FormCurrentAYGrade();
            f.strAYGrade = lblAYear.Text;
            f.Show();
            // sending lblAyear.text to FormCurrentAYGrade to fill by it
        }

        private void buttonUpdateAYClassroom_Click(object sender, EventArgs e)
        {
            FormCurrentAYClassroom f = new FormCurrentAYClassroom();
            f.strAYClassroom = lblAYear.Text;
            f.Show();
            // sending lblAyear.text to FormCurrentAYClassroom to fill by it
        }

        private void buttonNewStudentReg_Click(object sender, EventArgs e)
        {
            FormCurrentAYNewStudentReg f = new FormCurrentAYNewStudentReg();
            f.strAYNewStudentReg = lblAYear.Text;
            f.Show();
        }

        private void buttonUpdateCurrentAYStudent_Click(object sender, EventArgs e)
        {
            FormCurrentAYStudent f = new FormCurrentAYStudent();
            // sending lblAyear.text to FormCurrentAYStudent to fill by it
            f.strAYStudent = lblAYear.Text;
            f.Show();
        }
    }
}

