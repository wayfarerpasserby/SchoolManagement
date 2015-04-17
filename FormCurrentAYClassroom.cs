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
    public partial class FormCurrentAYClassroom : Form
    {
        public FormCurrentAYClassroom()
        {
            InitializeComponent();
        }

        public string strAYClassroom { get; set; }

        private void classroomBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.classroomBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.schoolDataSet);

        }

        private void FormCurrentAYClassroom_Load(object sender, EventArgs e)
        {
            // This is for the new academic year
            // TODO: This line of code loads data into the 'schoolDataSet.TheAcademicYear' table. You can move, or remove it, as needed.
            this.theAcademicYearTableAdapter.FillTheAcademicYears(this.schoolDataSet.TheAcademicYear);
            //gradeBindingSource1.DataSource = gradeTableAdapter;
            //comboBoxGradeNameIns.DataSource = gradeBindingSource1;
            //DataView dv = new DataView();
            //dv.DataViewManager.DataSet = schoolDataSet;
            
            //----------------------------------------------------------------------------------
            // strAYClassroom comes form FormCurrentAcademicYearWorks  loading with FormCurrentAcademicYearWorks.lblAYear.Text
            lblAYClassroom.Text = strAYClassroom;

            // TODO: This line of code loads data into the 'schoolDataSet.Grade' table. You can move, or remove it, as needed.
            //this.gradeTableAdapter.FillGrades(this.schoolDataSet.Grade);
            this.gradeTableAdapter.FillByAcademicYear(this.schoolDataSet.Grade, lblAYClassroom.Text);

            // TODO: This line of code loads data into the 'schoolDataSet.Classroom' table. You can move, or remove it, as needed.
            //this.classroomTableAdapter.FillClassrooms(this.schoolDataSet.Classroom);
            this.classroomTableAdapter.FillByGradeNameAcademicYear(this.schoolDataSet.Classroom, comboBoxGrClassroom.Text, lblAYClassroom.Text);
            
        }

        private void comboBoxGrClassroom_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.classroomTableAdapter.FillByGradeNameAcademicYear(this.schoolDataSet.Classroom, comboBoxGrClassroom.Text, lblAYClassroom.Text);
            buttonNAYCmMove.Visible = true;
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            // Auto fill known fields 
            gradeNameTextBox.Text = comboBoxGrClassroom.Text;
            academicYearTextBox.Text = lblAYClassroom.Text;
            gradeIdTextBox.Text = comboBoxGrClassroom.SelectedValue.ToString();
        }

        private void buttonNewAYClassroom_Click(object sender, EventArgs e)
        {
            //buttonNAYCmMove.Visible = true;
            //textBoxClassroomNameIns.Visible = true;
            //textBoxGradeNameIns.Visible = true;
            //comboBoxGradeNameIns.Visible = true;
            comboBoxAcademicYearIns.Visible = true;
            //textBoxGradeIdIns.Visible = true;
            //textBoxClassroomStudentsNumberIns.Visible = true;
            //buttonChooseGrade.Visible = true;
        }

        private void buttonNAYCmMove_Click(object sender, EventArgs e)
        {
            textBoxClassroomNameIns.Text = classroomNameTextBox.Text;
            comboBoxGradeNameIns.Text = gradeNameTextBox.Text;
            textBoxClassroomStudentsNumberIns.Text = classroomStudentsNumberTextBox.Text;

            SchoolDataSet.GradeDataTable DTGrade = this.gradeTableAdapter.GetDataByGradeNameAcademicYear(comboBoxGradeNameIns.Text,
                comboBoxAcademicYearIns.Text);

            if (DTGrade.Rows.Count > 0)
                textBoxGradeIdIns.Text = DTGrade.Rows[0].ItemArray[0].ToString();
            else
                textBoxGradeIdIns.Text = "Not found";
        }

        private void comboBoxAcademicYearIns_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonNAYCmMove.Visible = true;
            textBoxClassroomNameIns.Visible = true;
            //textBoxGradeNameIns.Visible = true;
            comboBoxGradeNameIns.Visible = true;
            textBoxGradeIdIns.Visible = true;
            textBoxClassroomStudentsNumberIns.Visible = true;
            buttonNewClassroomIns.Visible = true;
            //buttonChooseGrade.Visible = true;

            //this.gradeTableAdapter.FillByAcademicYear(schoolDataSet.Grade, comboBoxAcademicYearIns.Text);
            
        }

        private void buttonNewClassroomIns_Click(object sender, EventArgs e)
        {
            int tryparse10, tryparse11;
            bool ok10 = int.TryParse(textBoxGradeIdIns.Text, out tryparse10);
            bool ok11 = int.TryParse(textBoxClassroomStudentsNumberIns.Text, out tryparse11);
            if (ok10 && ok11)
            {
                this.classroomTableAdapter.InsertQueryClassrooms(textBoxClassroomNameIns.Text,
                    comboBoxGradeNameIns.Text, comboBoxAcademicYearIns.Text, int.Parse(textBoxGradeIdIns.Text),
                    int.Parse(textBoxClassroomStudentsNumberIns.Text));
                buttonNAYCmMove.Visible = false;
            }
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            buttonNAYCmMove.Visible = true;
        }
    }
}
