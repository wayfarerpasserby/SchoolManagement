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
    public partial class FormCurrentAYCourse : Form
    {
        public FormCurrentAYCourse()
        {
            InitializeComponent();
        }

        private void courseBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.courseBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.schoolDataSet);

        }

        private void FormCurrentAYCourse_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'schoolDataSet.Teacher' table. You can move, or remove it, as needed.
            this.teacherTableAdapter.FillByGradeName(this.schoolDataSet.Teacher,comboBoxGrCourse.Text);
            
            // TODO: This line of code loads data into the 'schoolDataSet.Course' table. You can move, or remove it, as needed.
            //this.courseTableAdapter.FillCourses(this.schoolDataSet.Course);
            this.courseTableAdapter.FillByGradeName(this.schoolDataSet.Course, comboBoxGrCourse.Text);

        }

        private void comboBoxGrCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.teacherTableAdapter.FillByGradeName(this.schoolDataSet.Teacher, comboBoxGrCourse.Text);
            this.courseTableAdapter.FillByGradeName(this.schoolDataSet.Course, comboBoxGrCourse.Text);
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            gradeNameTextBox.Text = comboBoxGrCourse.Text;
        }
    }
}
