using System;
using System.Windows.Forms;

namespace UIForms
{
    public partial class FormDateInterval : Form
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public FormDateInterval()
        {
            InitializeComponent();
            datePickerStartDate.Format = DateTimePickerFormat.Custom;
            datePickerStartDate.CustomFormat = "dd-MM-yyyy";
            datePickerStartDate.Value = DateTime.Today;

            datePickerEndDate.Format = DateTimePickerFormat.Custom;
            datePickerEndDate.CustomFormat = "dd-MM-yyyy";
            datePickerEndDate.Value = DateTime.Today;
        }

        private void DatePickerStartDate_ValueChanged(object sender, EventArgs e)
        {
            datePickerEndDate.MinDate = datePickerStartDate.Value;
        }


        private void BtnOK_Click(object sender, EventArgs e)
        {
            this.StartDate = datePickerStartDate.Value;
            this.EndDate = datePickerEndDate.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
