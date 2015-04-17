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
    public partial class FormCurrentAYPresenceFile : Form
    {
        public FormCurrentAYPresenceFile()
        {
            InitializeComponent();
        }

        public FormCurrentAYPresenceFile(int PresenceFileId)
        {
            InitializeComponent();
            this.PresenceFileId = PresenceFileId;
        }

        private int PresenceFileId { get; set; }

        private void presenceFileBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.presenceFileBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.schoolDataSet);
        }

        private void FormCurrentAYPresenceFile_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'schoolDataSet.PresenceFile' table. You can move, or remove it, as needed.
            //this.presenceFileTableAdapter.FillPresenceFiles(this.schoolDataSet.PresenceFile);
            this.presenceFileTableAdapter.FillByPresenceFileId(this.schoolDataSet.PresenceFile, PresenceFileId);
             
        }

        private void sSActualPresenceDaysNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            int tryparse1;
            bool ok1 = int.TryParse(sSActualPresenceDaysNumberTextBox.Text, out tryparse1);
            if (ok1)
            {
                actualPresenceDaysSumTextBox.Text = (int.Parse(fSActualPresenceDaysNumberTextBox.Text) +
                    int.Parse(sSActualPresenceDaysNumberTextBox.Text)).ToString();
            }
        }

        private void sSStudentPresenceDaysNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            int tryparse2;
            bool ok2 = int.TryParse(sSStudentPresenceDaysNumberTextBox.Text, out tryparse2);
            if (ok2)
            {
                studentPresenceDaysSumTextBox.Text = (int.Parse(fSStudentPresenceDaysNumberTextBox.Text) +
                    int.Parse(sSStudentPresenceDaysNumberTextBox.Text)).ToString();
            }
        }

        private void studentPresenceDaysSumTextBox_TextChanged(object sender, EventArgs e)
        {
            int tryparse3;
            bool ok3 = int.TryParse(studentPresenceDaysSumTextBox.Text, out tryparse3);
            if (ok3)
            {
                presencePercentTextBox.Text = (int.Parse(studentPresenceDaysSumTextBox.Text) * 100 /
                    int.Parse(actualPresenceDaysSumTextBox.Text)).ToString();
            }
        }
    }
}
