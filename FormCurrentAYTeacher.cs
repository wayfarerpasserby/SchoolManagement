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
    public partial class FormCurrentAYTeacher : Form
    {
        public FormCurrentAYTeacher()
        {
            InitializeComponent();
        }

        private void teacherBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.teacherBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.schoolDataSet);

        }

        private void FormCurrentAYTeacher_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'schoolDataSet.Course' table. You can move, or remove it, as needed.
            //this.courseTableAdapter.FillCourses(this.schoolDataSet.Course);
            this.courseTableAdapter.FillByGradeName(this.schoolDataSet.Course, comboBoxGrTeacher.Text);

            // TODO: This line of code loads data into the 'schoolDataSet.Teacher' table. You can move, or remove it, as needed.
            //this.teacherTableAdapter.FillTeachers(this.schoolDataSet.Teacher);
            this.teacherTableAdapter.FillByGradeName(this.schoolDataSet.Teacher, comboBoxGrTeacher.Text);

        }

        private void comboBoxGrTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.courseTableAdapter.FillByGradeName(this.schoolDataSet.Course, comboBoxGrTeacher.Text);
            this.teacherTableAdapter.FillByGradeName(this.schoolDataSet.Teacher, comboBoxGrTeacher.Text);

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            gradeNameTextBox.Text = comboBoxGrTeacher.Text;
        }
    }
}
