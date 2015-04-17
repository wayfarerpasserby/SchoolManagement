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
    public partial class FormCurrentAYStudentStudyFile : Form
    {
        public FormCurrentAYStudentStudyFile()
        {
            InitializeComponent();
        }
        
        public string strAYStudentStudyFile { get; set; }

        private string maxMark { get; set; }

        private void studyFileBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.studyFileBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.schoolDataSet);

        }

        private void FormCurrentAYStudentStudyFile_Load(object sender, EventArgs e)
        {
            
            // strAYStudentStudyFile comes form FormCurrentAcademicYearWorks  loading with FormCurrentAcademicYearWorks.lblAYear.Text
            lblAYStudentStudyFile.Text = strAYStudentStudyFile;

            // TODO: This line of code loads data into the 'schoolDataSet.Course' table. You can move, or remove it, as needed.
            //this.courseTableAdapter.FillCourses(this.schoolDataSet.Course);

            // TODO: This line of code loads data into the 'schoolDataSet.Student' table. You can move, or remove it, as needed.
            //this.studentTableAdapter.FillStudents(this.schoolDataSet.Student);

            // TODO: This line of code loads data into the 'schoolDataSet.Classroom' table. You can move, or remove it, as needed.
            //this.classroomTableAdapter.FillClassrooms(this.schoolDataSet.Classroom);

            // TODO: This line of code loads data into the 'schoolDataSet.Grade' table. You can move, or remove it, as needed.
            //this.gradeTableAdapter.FillGrades(this.schoolDataSet.Grade);

            // TODO: This line of code loads data into the 'schoolDataSet.StudyFile' table. You can move, or remove it, as needed.
            //this.studyFileTableAdapter.FillStudyFiles(this.schoolDataSet.StudyFile);

        }

        private void buttonGrade_Click(object sender, EventArgs e)
        {
            this.gradeTableAdapter.FillByAcademicYear(this.schoolDataSet.Grade, lblAYStudentStudyFile.Text);
        }

        private void buttonClassroom_Click(object sender, EventArgs e)
        {
            if (comboBoxGrade.SelectedValue != null)
            {
                this.classroomTableAdapter.FillByGradeNameAcademicYear(this.schoolDataSet.Classroom, comboBoxGrade.Text, lblAYStudentStudyFile.Text);
            }
        }

        private void buttonStudent_Click(object sender, EventArgs e)
        {
            if (comboBoxClassroom.SelectedValue != null)
            {
                this.studentTableAdapter.FillByClassroomId(this.schoolDataSet.Student, int.Parse(comboBoxClassroom.SelectedValue.ToString()));
                if (comboBoxStudent.SelectedValue != null)
                {
                    studentIdTextBox.Text = comboBoxStudent.SelectedValue.ToString();
                }
            }
        }

        private void buttonCourse_Click(object sender, EventArgs e)
        {
            if (comboBoxGrade.SelectedValue != null)
            {
                this.courseTableAdapter.FillByGradeName(this.schoolDataSet.Course, comboBoxGrade.Text);

                //Aotu Fill courseId and max mark
                if (comboBoxCourse.SelectedValue != null)
                {
                    courseIdTextBox.Text = comboBoxCourse.SelectedValue.ToString();
                }
                SchoolDataSet.CourseDataTable DTCourse = this.courseTableAdapter.GetDataById(int.Parse(courseIdTextBox.Text));
                maxMark = DTCourse.Rows[0].ItemArray[5].ToString();
                lblMaxMark.Text = "(" + DTCourse.Rows[0].ItemArray[5].ToString() + ")";
            }
        }

        private void buttonStudyFile_Click(object sender, EventArgs e)
        {
            if (comboBoxStudent.SelectedValue != null && comboBoxCourse.SelectedValue != null)
            {
                this.studyFileTableAdapter.FillByStudentIdCourseId(this.schoolDataSet.StudyFile, int.Parse(comboBoxStudent.SelectedValue.ToString()), int.Parse(comboBoxCourse.SelectedValue.ToString()));
            }
        }

        private void comboBoxStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            studentIdTextBox.Text = comboBoxStudent.SelectedValue.ToString();
            lblPass.Text = lblPass2.Text = lblPass3.Text = "----------";
            textBoxFSTotalSum.Text = textBoxTotalSum.Text = null;
            buttonFinalResult.Visible = buttonPaper.Visible = false;
            // empty study file info
            studyFileIdTextBox.Text = fSOralTextBox.Text = fStHomeworksTextBox.Text = fSQuizzesTextBox.Text =
                fSSumTextBox.Text = fSAverageIsSumHalfTextBox.Text = fSemesterExamTextBox.Text =
                fSSummationTextBox.Text = fSNumericResultantTextBox.Text = fSWrittenResultantTextBox.Text =
                sSOralTextBox.Text = sSHomeworksTextBox.Text = sSQuizzesTextBox.Text = sSSumTextBox.Text =
                sSAverageIsSumHalfTextBox.Text = sSemesterExamTextBox.Text = sSSummationTextBox.Text =
                sSNumericResultantTextBox.Text = sSWrittenResultantTextBox.Text =
                fSSResultantSumTextBox.Text = finalMarkFSSResultantAverageNumericTextBox.Text =
                finalMarkFSSResultantAverageWrittenTextBox.Text = null;
        }

        private void comboBoxCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            courseIdTextBox.Text = comboBoxCourse.SelectedValue.ToString();
            SchoolDataSet.CourseDataTable DTCourse = this.courseTableAdapter.GetDataById(int.Parse(courseIdTextBox.Text));
            maxMark = DTCourse.Rows[0].ItemArray[5].ToString();
            lblMaxMark.Text = "(" + DTCourse.Rows[0].ItemArray[5].ToString() + ")";
            //empty study file info and make button invisible
            textBoxFSTotalSum.Text = textBoxTotalSum.Text = null;
            buttonFinalResult.Visible = buttonPaper.Visible = false;
            // empty study file info
            studyFileIdTextBox.Text = fSOralTextBox.Text = fStHomeworksTextBox.Text = fSQuizzesTextBox.Text =
                fSSumTextBox.Text = fSAverageIsSumHalfTextBox.Text = fSemesterExamTextBox.Text =
                fSSummationTextBox.Text = fSNumericResultantTextBox.Text = fSWrittenResultantTextBox.Text =
                sSOralTextBox.Text = sSHomeworksTextBox.Text = sSQuizzesTextBox.Text = sSSumTextBox.Text =
                sSAverageIsSumHalfTextBox.Text = sSemesterExamTextBox.Text = sSSummationTextBox.Text =
                sSNumericResultantTextBox.Text = sSWrittenResultantTextBox.Text =
                fSSResultantSumTextBox.Text = finalMarkFSSResultantAverageNumericTextBox.Text =
                finalMarkFSSResultantAverageWrittenTextBox.Text = null;
        }

        private void fSQuizzesTextBox_TextChanged(object sender, EventArgs e)
        {
            // Aotu fill known fields
            int tryparse1;
            bool ok1 = int.TryParse(fSQuizzesTextBox.Text, out tryparse1);
            if (ok1)
            {
                fSSumTextBox.Text = (int.Parse(fSQuizzesTextBox.Text) + int.Parse(fStHomeworksTextBox.Text) +
                    int.Parse(fSOralTextBox.Text)).ToString();

                fSAverageIsSumHalfTextBox.Text = Math.Ceiling((int.Parse(fSSumTextBox.Text) / 2.0)).ToString();
            }
        }

        private void fSemesterExamTextBox_TextChanged(object sender, EventArgs e)
        {
            // Aotu fill known fields
            int tryparse4;
            bool ok4 = int.TryParse(fSemesterExamTextBox.Text, out tryparse4);
            if (ok4)
            {
                fSSummationTextBox.Text = (int.Parse(fSemesterExamTextBox.Text) +
                    int.Parse(fSAverageIsSumHalfTextBox.Text)).ToString();

                fSNumericResultantTextBox.Text = Math.Ceiling((int.Parse(fSSummationTextBox.Text) / 2.0)).ToString();

            }
            // in case changing the first semester exam after filling the second semester exam
            int tryparse6;
            bool ok6 = int.TryParse(sSNumericResultantTextBox.Text, out tryparse6);
            if (ok6)
            {
                fSSResultantSumTextBox.Text = (int.Parse(fSNumericResultantTextBox.Text) +
                    int.Parse(sSNumericResultantTextBox.Text)).ToString();
                finalMarkFSSResultantAverageNumericTextBox.Text = Math.Ceiling((int.Parse(fSSResultantSumTextBox.Text) / 2.0)).ToString();
            }
        }

        private void sSQuizzesTextBox_TextChanged(object sender, EventArgs e)
        {
            // Aotu fill known fields
            int tryparse2;
            bool ok2 = int.TryParse(sSQuizzesTextBox.Text, out tryparse2);
            if (ok2)
            {
                sSSumTextBox.Text = (int.Parse(sSQuizzesTextBox.Text) + int.Parse(sSHomeworksTextBox.Text) +
                    int.Parse(sSOralTextBox.Text)).ToString();

                sSAverageIsSumHalfTextBox.Text = Math.Ceiling((int.Parse(sSSumTextBox.Text) / 2.0)).ToString();
            }
        }

        private void sSemesterExamTextBox_TextChanged(object sender, EventArgs e)
        {
            // Aotu fill known fields
            int tryparse5;
            bool ok5 = int.TryParse(sSemesterExamTextBox.Text, out tryparse5);
            if (ok5)
            {
                sSSummationTextBox.Text = (int.Parse(sSemesterExamTextBox.Text) +
                    int.Parse(sSAverageIsSumHalfTextBox.Text)).ToString();

                sSNumericResultantTextBox.Text = Math.Ceiling((int.Parse(sSSummationTextBox.Text) / 2.0)).ToString();

                // Final resultant
                fSSResultantSumTextBox.Text = (int.Parse(fSNumericResultantTextBox.Text) +
                    int.Parse(sSNumericResultantTextBox.Text)).ToString();

                finalMarkFSSResultantAverageNumericTextBox.Text = Math.Ceiling((int.Parse(fSSResultantSumTextBox.Text) / 2.0)).ToString();
            }
                
        }

        private void buttonTotalSum_Click(object sender, EventArgs e)
        {
            if (comboBoxStudent.SelectedValue != null)
            {
                //
                SchoolDataSet.StudyFileDataTable DTTSStudyFile = this.studyFileTableAdapter.GetDataByStudentId(int.Parse(comboBoxStudent.SelectedValue.ToString()));
                if (DTTSStudyFile.Rows.Count > 0)
                {
                    int totalsum = (int)this.studyFileTableAdapter.ScalarQueryTotalSum(int.Parse(studentIdTextBox.Text));

                    SchoolDataSet.StudentDataTable DTStudent2 = this.studentTableAdapter.GetDataByStudentId(int.Parse(comboBoxStudent.SelectedValue.ToString()));

                    textBoxTotalSum.Text = totalsum.ToString();
                    //update the total sum in studentdatatable
                    this.studentTableAdapter.UpdateQueryStudentPassingOrder(totalsum.ToString(),
                        int.Parse(DTStudent2.Rows[0].ItemArray[0].ToString()), 1, DTStudent2.Rows[0].ItemArray[1].ToString(), 1,
                        DateTime.Parse(DTStudent2.Rows[0].ItemArray[2].ToString()), 1, DTStudent2.Rows[0].ItemArray[3].ToString(), 1,
                        DTStudent2.Rows[0].ItemArray[4].ToString(), 1, DTStudent2.Rows[0].ItemArray[5].ToString(), 1,
                        DTStudent2.Rows[0].ItemArray[6].ToString(), 1, int.Parse(DTStudent2.Rows[0].ItemArray[7].ToString()), 1,
                        int.Parse(DTStudent2.Rows[0].ItemArray[8].ToString()), 1, int.Parse(DTStudent2.Rows[0].ItemArray[9].ToString()),
                        1, int.Parse(DTStudent2.Rows[0].ItemArray[10].ToString())/*null*/, 1, DTStudent2.Rows[0].ItemArray[11].ToString(),
                        1, DTStudent2.Rows[0].ItemArray[12].ToString(), int.Parse(comboBoxStudent.SelectedValue.ToString()));
                    //
                    buttonFinalResult.Visible = true;
                    buttonPaper.Visible = true;
                }
            }
        }//end of buttonTotalSum_Click

        private void buttonFSTotalSum_Click(object sender, EventArgs e)
        {
            if (comboBoxStudent.SelectedValue != null)
            {
                SchoolDataSet.StudyFileDataTable DTFSStudyFile = this.studyFileTableAdapter.GetDataByStudentId(int.Parse(comboBoxStudent.SelectedValue.ToString()));
                if (DTFSStudyFile.Rows.Count > 0)
                {
                    int fstotalsum = (int)this.studyFileTableAdapter.ScalarQueryFSTotalSum(int.Parse(studentIdTextBox.Text));
                    textBoxFSTotalSum.Text = fstotalsum.ToString();
                    buttonPaper.Visible = true;
                }
            }
        }

        private void buttonFinalResult_Click(object sender, EventArgs e)
        {

            lblPass.Text = lblPass2.Text = lblPass3.Text = "----------";
            bool success = true;
            //string arabiccourse = "اللغة العربية";
            string agrade = "الحادي عشر العلمي";
            string bgrade = "الثاني الثانوي العلمي";
            string passresult = "رسوب في الصف ";
            passresult += comboBoxGrade.Text;
            // WWWWWWWWWWWWWWWWWWWW arabic course text combination WWWWWWWWWWWWWWWW
            string passresult2;
            string result = "نتيجة هذا الطالب ";
            result += "رسوب في الصف ";
            result += comboBoxGrade.Text;
            passresult2 = result + " بسبب رسوبه في مادة اللغة العربية";
            // WWWWWWWWWWWWWWWWWWWW total sum text combination WWWWWWWWWWWWWWWW
            string result2 = "نتيجة هذا الطالب ";
            result2 += "رسوب في الصف ";
            result2 += comboBoxGrade.Text;
            string passresult3 = result2 + " بسبب المجموع العام";
            // WWWWWWWWWWWWWWWWWWWW other courses text combination WWWWWWWWWWWWWWWW
            string result3 = "نتيجة هذا الطالب ";
            result3 += "رسوب في الصف ";
            result3 += comboBoxGrade.Text;
            string passresult4 = result3 + " بسبب رسوبه في ثلاث مواد أو أكثر";
            // WWWWWWWWWWWWWWWWWWWW other courses text combination WWWWWWWWWWWWWWWW
            string result4 = "رسوب في مادة ";
            // WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW
            

            //(1) ZZZZZZZZZZZZZZZZZZZZ determin success by total sum ZZZZZZZZZZZZZZZZZZZZZZZZ
            // max marks of courses of specific grade
            SchoolDataSet.StudentDataTable DTStudent3 = this.studentTableAdapter.GetDataByStudentId(int.Parse(comboBoxStudent.SelectedValue.ToString()));
            int maxmarksum = (int)this.courseTableAdapter.ScalarQueryMaxMarkSum(comboBoxGrade.Text);
            // calc total sum of specific student
            int totalsum2 = int.Parse(textBoxTotalSum.Text);
            if (totalsum2 < (0.5 * maxmarksum))
            {
                lblPass3.Text = passresult3;
                success = false;
                this.studentTableAdapter.UpdateQueryStudentPass(passresult,
                    int.Parse(DTStudent3.Rows[0].ItemArray[0].ToString()), 1, DTStudent3.Rows[0].ItemArray[1].ToString(),
                    1, DateTime.Parse(DTStudent3.Rows[0].ItemArray[2].ToString()), 1, DTStudent3.Rows[0].ItemArray[3].ToString(), 1,
                    DTStudent3.Rows[0].ItemArray[4].ToString(), 1, DTStudent3.Rows[0].ItemArray[5].ToString(), 1,
                    DTStudent3.Rows[0].ItemArray[6].ToString(), 1, int.Parse(DTStudent3.Rows[0].ItemArray[7].ToString()), 1,
                    int.Parse(DTStudent3.Rows[0].ItemArray[8].ToString()), 1, int.Parse(DTStudent3.Rows[0].ItemArray[9].ToString()), 1,
                    int.Parse(DTStudent3.Rows[0].ItemArray[10].ToString())/*null*/, 1, DTStudent3.Rows[0].ItemArray[11].ToString(), 1,
                    DTStudent3.Rows[0].ItemArray[12].ToString(), int.Parse(comboBoxStudent.SelectedValue.ToString()));

            }
            //    ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZ
            //(2) ZZZZZZZZZZZZZZZZZZZZ determin success by arabic course ZZZZZZZZZZZZZZZZZZZZZZZZ
            SchoolDataSet.StudentDataTable DTStudent = this.studentTableAdapter.GetDataByStudentId(int.Parse(comboBoxStudent.SelectedValue.ToString()));
            int arabicMaxMark = 0;
            int studentArabicMark = 0;
            int courseMaxMark = 0, studentCourseMark = 0;
            int failcourses = 0;
            SchoolDataSet.StudyFileDataTable DTStudyFile = this.studyFileTableAdapter.GetDataByStudentId(int.Parse(comboBoxStudent.SelectedValue.ToString()));
            // look for arabic course and get student final resultant mark
            for (int i = 0; i < DTStudyFile.Rows.Count; i++)
            {
                // getting one record by CourseId from DTStudyFile
                SchoolDataSet.CourseDataTable DTCourse2 = this.courseTableAdapter.GetDataById
                    (int.Parse(DTStudyFile.Rows[i].ItemArray[2].ToString()));
                if (DTCourse2.Rows.Count > 0)
                {
                    if ((string)DTCourse2.Rows[0].ItemArray[1] == "اللغة العربية")
                    {
                        arabicMaxMark = int.Parse(DTCourse2.Rows[0].ItemArray[5].ToString());
                        //get student final resultant mark from StudyFile record
                        studentArabicMark = int.Parse(DTStudyFile.Rows[i].ItemArray[22].ToString());
                        // determine fail in arabic
                        if (comboBoxGrade.Text != agrade && comboBoxGrade.Text != bgrade)
                        {
                            if (studentArabicMark < (0.5 * arabicMaxMark))
                            {
                                lblPass.Text = passresult2;
                                success = false;
                                failcourses++;
                                this.studentTableAdapter.UpdateQueryStudentPass(passresult,
                                    int.Parse(DTStudent.Rows[0].ItemArray[0].ToString()), 1, DTStudent.Rows[0].ItemArray[1].ToString(),
                                    1, DateTime.Parse(DTStudent.Rows[0].ItemArray[2].ToString()), 1, DTStudent.Rows[0].ItemArray[3].ToString(), 1,
                                    DTStudent.Rows[0].ItemArray[4].ToString(), 1, DTStudent.Rows[0].ItemArray[5].ToString(), 1,
                                    DTStudent.Rows[0].ItemArray[6].ToString(), 1, int.Parse(DTStudent.Rows[0].ItemArray[7].ToString()), 1,
                                    int.Parse(DTStudent.Rows[0].ItemArray[8].ToString()), 1, int.Parse(DTStudent.Rows[0].ItemArray[9].ToString()), 1,
                                    /*int.Parse(DTStudent.Rows[0].ItemArray[10].ToString())*/null, 1, DTStudent.Rows[0].ItemArray[11].ToString(), 1,
                                    DTStudent.Rows[0].ItemArray[12].ToString(), int.Parse(comboBoxStudent.SelectedValue.ToString()));
                            }
                        }
                        else// when student is grade 11
                        {
                            if (studentArabicMark < (0.4 * arabicMaxMark))
                            {
                                lblPass.Text = passresult2;
                                success = false;
                                failcourses++;
                                this.studentTableAdapter.UpdateQueryStudentPass(passresult,
                                    int.Parse(DTStudent.Rows[0].ItemArray[0].ToString()), 1, DTStudent.Rows[0].ItemArray[1].ToString(),
                                    1, DateTime.Parse(DTStudent.Rows[0].ItemArray[2].ToString()), 1, DTStudent.Rows[0].ItemArray[3].ToString(), 1,
                                    DTStudent.Rows[0].ItemArray[4].ToString(), 1, DTStudent.Rows[0].ItemArray[5].ToString(), 1,
                                    DTStudent.Rows[0].ItemArray[6].ToString(), 1, int.Parse(DTStudent.Rows[0].ItemArray[7].ToString()), 1,
                                    int.Parse(DTStudent.Rows[0].ItemArray[8].ToString()), 1, int.Parse(DTStudent.Rows[0].ItemArray[9].ToString()), 1,
                                    /*int.Parse(DTStudent.Rows[0].ItemArray[10].ToString())*/null, 1, DTStudent.Rows[0].ItemArray[11].ToString(), 1,
                                    DTStudent.Rows[0].ItemArray[12].ToString(), int.Parse(comboBoxStudent.SelectedValue.ToString()));
                            }
                        }//end else
                    }//end if arabic course
                    else// when course is not arabic
                    {
                        courseMaxMark = int.Parse(DTCourse2.Rows[0].ItemArray[5].ToString());
                        //get student final resultant mark from StudyFile record
                        studentCourseMark = int.Parse(DTStudyFile.Rows[i].ItemArray[22].ToString());
                        if (studentCourseMark < (0.2 * courseMaxMark))
                        {
                            failcourses++;
                            result4 += DTCourse2.Rows[0].ItemArray[1].ToString() + " " + ", ";
                            if (failcourses >= 3)
                            {
                                lblPass2.Text = passresult4;
                                success = false;
                                this.studentTableAdapter.UpdateQueryStudentPass(passresult,
                                    int.Parse(DTStudent.Rows[0].ItemArray[0].ToString()), 1, DTStudent.Rows[0].ItemArray[1].ToString(),
                                    1, DateTime.Parse(DTStudent.Rows[0].ItemArray[2].ToString()), 1, DTStudent.Rows[0].ItemArray[3].ToString(), 1,
                                    DTStudent.Rows[0].ItemArray[4].ToString(), 1, DTStudent.Rows[0].ItemArray[5].ToString(), 1,
                                    DTStudent.Rows[0].ItemArray[6].ToString(), 1, int.Parse(DTStudent.Rows[0].ItemArray[7].ToString()), 1,
                                    int.Parse(DTStudent.Rows[0].ItemArray[8].ToString()), 1, int.Parse(DTStudent.Rows[0].ItemArray[9].ToString()), 1,
                                    /*int.Parse(DTStudent.Rows[0].ItemArray[10].ToString())*/null, 1, DTStudent.Rows[0].ItemArray[11].ToString(), 1,
                                    DTStudent.Rows[0].ItemArray[12].ToString(), int.Parse(comboBoxStudent.SelectedValue.ToString()));
                            }
                            else
                                lblPass2.Text = result4;

                        }//end if course fail
                    }//end else when course is not arabic
                }//end first if
            }//end for
            //    ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZ
            if (success == true)
            {
                
                string successresult = "نجاح إلى الصف ";
                if (comboBoxGrade.Text == "السابع")
                    successresult += "الثامن";
                if (comboBoxGrade.Text == "الثامن")
                    successresult += "التاسع";
                if (comboBoxGrade.Text == "التاسع")
                    successresult += "العاشر";
                if (comboBoxGrade.Text == "العاشر")
                    successresult += "الحادي عشر";
                if (comboBoxGrade.Text == "الحادي عشر الأدبي")
                    successresult += "الثاني عشر الأدبي";
                if (comboBoxGrade.Text == "الحادي عشر العلمي")
                    successresult += "الثاني عشر العلمي";
                
                if (comboBoxGrade.Text != "الثاني عشر العلمي" && comboBoxGrade.Text != "الثاني عشر الأدبي" &&
                    comboBoxGrade.Text != "الثالث الثانوي العلمي" && comboBoxGrade.Text != "الثالث الثانوي الأدبي")
                {
                    
                    lblPass.Text = successresult;
                    this.studentTableAdapter.UpdateQueryStudentPass(successresult,
                        int.Parse(DTStudent.Rows[0].ItemArray[0].ToString()), 1, DTStudent.Rows[0].ItemArray[1].ToString(),
                        1, DateTime.Parse(DTStudent.Rows[0].ItemArray[2].ToString()), 1, DTStudent.Rows[0].ItemArray[3].ToString(), 1,
                        DTStudent.Rows[0].ItemArray[4].ToString(), 1, DTStudent.Rows[0].ItemArray[5].ToString(), 1,
                        DTStudent.Rows[0].ItemArray[6].ToString(), 1, int.Parse(DTStudent.Rows[0].ItemArray[7].ToString()), 1,
                        int.Parse(DTStudent.Rows[0].ItemArray[8].ToString()), 1, int.Parse(DTStudent.Rows[0].ItemArray[9].ToString()), 1,
                        /*int.Parse(DTStudent.Rows[0].ItemArray[10].ToString())*/null, 1, DTStudent.Rows[0].ItemArray[11].ToString(), 1,
                        DTStudent.Rows[0].ItemArray[12].ToString(), int.Parse(comboBoxStudent.SelectedValue.ToString()));
                }
                
            }

        }// end buttonFinalResult_Click

        private void buttonPaper_Click(object sender, EventArgs e)
        {
            int StudentId = int.Parse(comboBoxStudent.SelectedValue.ToString());
            //FormReportPaper f = new FormReportPaper(StudentId);
            //f.Show();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            lblPass.Text = lblPass2.Text = lblPass3.Text = "----------";
            textBoxFSTotalSum.Text = textBoxTotalSum.Text = null;
            buttonFinalResult.Visible = buttonPaper.Visible = false;

            studentIdTextBox.Text = comboBoxStudent.SelectedValue.ToString();
            courseIdTextBox.Text = comboBoxCourse.SelectedValue.ToString();
        }
    }
}
