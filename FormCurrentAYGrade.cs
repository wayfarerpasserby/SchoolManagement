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
    public partial class FormCurrentAYGrade : Form
    {
        public FormCurrentAYGrade()
        {
            InitializeComponent();
        }

        public string strAYGrade { get; set; }

        private void gradeBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.gradeBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.schoolDataSet);

        }

        private void FormCurrentAYGrade_Load(object sender, EventArgs e)
        {
            // This is for the New Year
            // TODO: This line of code loads data into the 'schoolDataSet.TheAcademicYear' table. You can move, or remove it, as needed.
            this.theAcademicYearTableAdapter.FillTheAcademicYears(this.schoolDataSet.TheAcademicYear);
            //------------------------------------------------------------------------------
            // strAYGrade comes form FormCurrentAcademicYearWorks  loading with FormCurrentAcademicYearWorks.lblAYear.Text
            lblAYGrade.Text = strAYGrade;

            // TODO: This line of code loads data into the 'schoolDataSet.Grade' table. You can move, or remove it, as needed.
            this.gradeTableAdapter.FillByAcademicYear(this.schoolDataSet.Grade, lblAYGrade.Text);
            // this.gradeTableAdapter.FillGrades(this.schoolDataSet.Grade);

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            academicYearTextBox.Text = lblAYGrade.Text;
        }
        //Moving grades to a new year
        private void buttonNewAYGrade_Click(object sender, EventArgs e)
        { 
            comboBoxAcademicYearIns.Visible = true;   
        }

        private void buttonNAYGrMove_Click(object sender, EventArgs e)
        {
            textBoxGradeNameIns.Text = gradeNameTextBox.Text;
            textBoxClassroomsNumberIns.Text = classroomsNumberTextBox.Text;
        }

        private void buttonNewGradeIns_Click(object sender, EventArgs e)
        {
            int tryparse12;
            bool ok12 = int.TryParse(textBoxClassroomsNumberIns.Text, out tryparse12);
            if (comboBoxAcademicYearIns.SelectedValue != null)
            {
                if (ok12)
                {
                    this.gradeTableAdapter.InsertQueryGrades(textBoxGradeNameIns.Text,
                        comboBoxAcademicYearIns.SelectedValue.ToString(), int.Parse(textBoxClassroomsNumberIns.Text));
                    buttonNAYGrMove.Visible = false;
                }
            }
        }

        private void comboBoxAcademicYearIns_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonNAYGrMove.Visible = true;
            textBoxGradeNameIns.Visible = true;
            textBoxClassroomsNumberIns.Visible = true;
            buttonNewGradeIns.Visible = true;
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            buttonNAYGrMove.Visible = true;
        }
    }
}
