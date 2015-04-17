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
    public partial class FormStart : Form
    {
        public FormStart()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'schoolDataSet.TheAcademicYear' table. You can move, or remove it, as needed.
            //this.theAcademicYearTableAdapter.FillTheAcademicYears(this.schoolDataSet.TheAcademicYear);
            //this.Size.Width = 1200;
        }

        private void buttonCurrentAY_Click(object sender, EventArgs e)
        {
            comboBoxCurrentAY.Visible = true;
            this.theAcademicYearTableAdapter.FillTheAcademicYears(this.schoolDataSet.TheAcademicYear);
            buttonCurrentAYWorks.Visible = true;
        }

        private void buttonCurrentAYWorks_Click(object sender, EventArgs e)
        {
            string ay = comboBoxCurrentAY.Text;
            FormCurrentAcademicYearWorks f = new FormCurrentAcademicYearWorks();
            f.lblAcademicYear = ay;
            f.Show();
        }

        private void buttonCurrentAYCourse_Click(object sender, EventArgs e)
        {
            FormCurrentAYCourse f = new FormCurrentAYCourse();
            f.Show();
        }

        private void buttonCurrentAYTeacher_Click(object sender, EventArgs e)
        {
            FormCurrentAYTeacher f = new FormCurrentAYTeacher();
            f.Show();
        }

        private void buttonLibrary_Click(object sender, EventArgs e)
        {
            FormLibrary f = new FormLibrary();
            f.Show();
        }

        private void buttonTheSchool_Click(object sender, EventArgs e)
        {
            FormTheSchool f = new FormTheSchool();
            f.Show();
        }
    }
}
