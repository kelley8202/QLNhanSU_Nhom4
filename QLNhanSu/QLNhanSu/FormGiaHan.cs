using System;
using System.Windows.Forms;

namespace QLNhanSu
{
    public partial class FormGiaHan : System.Windows.Forms.Form
    {
        public FormGiaHan()
        {
            InitializeComponent();
        }

        public int GetSelectedDuration()
        {
            if (rb1Month.Checked) return 1;
            if (rb3Months.Checked) return 3;
            if (rb6Months.Checked) return 6;
            if (rb1Year.Checked) return 12;
            if (rb3Years.Checked) return 36;
            if (rb10Years.Checked) return 120;

            return 0;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
