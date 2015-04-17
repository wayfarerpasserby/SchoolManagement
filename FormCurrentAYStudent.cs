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
    public partial class FormCurrentAYStudent : Form
    {
        public FormCurrentAYStudent()
        {
            InitializeComponent();
        }

        public string strAYStudent { get; set; }

        private void studentBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.studentBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.schoolDataSet);

        }

        private void FormCurrentAYStudent_Load(object sender, EventArgs e)
        {
            // This for the new year
            // TODO: This line of code loads data into the 'schoolDataSet.TheAcademicYear' table. You can move, or remove it, as needed.
            this.theAcademicYearTableAdapter.FillTheAcademicYears(this.schoolDataSet.TheAcademicYear);
            //----------------------------------------------------------------------
            // strAYStudent comes form FormCurrentAcademicYearWorks  loading with FormCurrentAcademicYearWorks.lblAYear.Text
            lblAYStudent.Text = strAYStudent;
            
            // TODO: This line of code loads data into the 'schoolDataSet.Grade' table. You can move, or remove it, as needed.
            //this.gradeTableAdapter.FillGrades(this.schoolDataSet.Grade);
            this.gradeTableAdapter.FillByAcademicYear(this.schoolDataSet.Grade, lblAYStudent.Text);

            // TODO: This line of code loads data into the 'schoolDataSet.Classroom' table. You can move, or remove it, as needed.
            //this.classroomTableAdapter.FillClassrooms(this.schoolDataSet.Classroom);
            if (comboBoxGrStudent.SelectedValue != null)
            {
                this.classroomTableAdapter.FillByGradeNameAcademicYear(this.schoolDataSet.Classroom, comboBoxGrStudent.Text, lblAYStudent.Text);
            }
            
            // TODO: This line of code loads data into the 'schoolDataSet.Student' table. You can move, or remove it, as needed.
            //this.studentTableAdapter.FillStudents(this.schoolDataSet.Student);
            if (comboBoxCmStudent.SelectedValue != null)
            {
                this.studentTableAdapter.FillByClassroomId(this.schoolDataSet.Student, int.Parse(comboBoxCmStudent.SelectedValue.ToString()));
            }

        }

        private void comboBoxGrStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxGrStudent.SelectedValue != null)
            {
                this.classroomTableAdapter.FillByGradeNameAcademicYear(this.schoolDataSet.Classroom, comboBoxGrStudent.Text, lblAYStudent.Text);
            }
            if (comboBoxCmStudent.SelectedValue != null)
            {
                this.studentTableAdapter.FillByClassroomId(this.schoolDataSet.Student, int.Parse(comboBoxCmStudent.SelectedValue.ToString()));
                buttonNAYStMove.Visible = true;
            }
        }

        private void comboBoxCmStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCmStudent.SelectedValue != null)
            {
                this.studentTableAdapter.FillByClassroomId(this.schoolDataSet.Student, int.Parse(comboBoxCmStudent.SelectedValue.ToString()));
                buttonNAYStMove.Visible = true;
            }
        }

        private void buttonNewAYStudent_Click(object sender, EventArgs e)
        {
            comboBoxAcademicYearIns.Visible = true;
        }

        private void comboBoxAcademicYearIns_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxFullNameIns.Visible = true;
            dateTimePickerBirthDateIns.Visible = true;
            textBoxBirthPlaceIns.Visible = true;
            textBoxRegisterNoandPlaceIns.Visible = true;
            comboBoxGradeNameIns.Visible = true;
            textBoxClassroomIdIns.Visible = true;
            textBoxPresenceFileIdIns.Visible = true;
            textBoxPersonalFileIdIns.Visible = true;
            buttonNAYStMove.Visible = true;
            buttonNewClassroom.Visible = true;
            buttonNewPresenceFileId.Visible = true;
            buttonNewStudentIns.Visible = true;
        }

        private void buttonNAYStMove_Click(object sender, EventArgs e)
        {
            textBoxFullNameIns.Text = fullNameTextBox.Text;
            dateTimePickerBirthDateIns.Value = birthDateDateTimePicker.Value;
            textBoxBirthPlaceIns.Text = birthPlaceTextBox.Text;
            textBoxRegisterNoandPlaceIns.Text = registerNoandPlaceTextBox.Text;
            textBoxPersonalFileIdIns.Text = personalFileIdTextBox.Text;
        }

        private void buttonNewClassroom_Click(object sender, EventArgs e)
        {
            FormCurrentAYClassroom f = new FormCurrentAYClassroom();
            f.strAYClassroom = comboBoxAcademicYearIns.Text;
            f.Show();
        }

        private void buttonNewPresenceFileId_Click(object sender, EventArgs e)
        {
            FormCurrentAYPresenceFile f = new FormCurrentAYPresenceFile();
            f.Show();
        }

        private void buttonNewStudentIns_Click(object sender, EventArgs e)
        {
            int tryparse7, tryparse8, tryparse9;
            bool ok7 = int.TryParse(textBoxClassroomIdIns.Text, out tryparse7);
            bool ok8 = int.TryParse(textBoxPresenceFileIdIns.Text, out tryparse8);
            bool ok9 = int.TryParse(textBoxPersonalFileIdIns.Text, out tryparse9);
            if (ok7 && ok8 && ok9)
            {
                this.studentTableAdapter.InsertQueryStudents(textBoxFullNameIns.Text, dateTimePickerBirthDateIns.Value,
                    textBoxBirthPlaceIns.Text, textBoxRegisterNoandPlaceIns.Text, comboBoxGradeNameIns.Text,
                    comboBoxAcademicYearIns.Text, int.Parse(textBoxClassroomIdIns.Text),
                    int.Parse(textBoxPresenceFileIdIns.Text), int.Parse(textBoxPersonalFileIdIns.Text));

                buttonNAYStMove.Visible = false;
            }
            
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            buttonNAYStMove.Visible = true;
        }

        private void buttonUpdateAYPresenceFile_Click(object sender, EventArgs e)
        {
            FormCurrentAYPresenceFile f = new FormCurrentAYPresenceFile(int.Parse(presenceFileIdTextBox.Text));
            f.Show();
        }

        private void buttonUpdateAYPersonalFile_Click(object sender, EventArgs e)
        {
            FormCurrentAYPersonalFile f = new FormCurrentAYPersonalFile(int.Parse(personalFileIdTextBox.Text));
            f.Show();
        }

    }
}
