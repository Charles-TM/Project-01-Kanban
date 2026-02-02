using Kanaban501app;
using System;
using System.Windows.Forms;

namespace Kanban501
{
    public partial class GoalDialog : Form
    {
        public GoalActivity Activity { get; private set; }

        public GoalDialog()
        {
            InitializeComponent();
            comboStatus.DataSource = Enum.GetValues(typeof(Status));
        }

        public GoalDialog(GoalActivity activity) : this()
        {
            Activity = activity;
            txtTitle.Text = activity.Title;
            datePicker.Value = activity.CompleteBy;
            comboStatus.SelectedItem = activity.Status;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (Activity == null)
                Activity = new GoalActivity();

            Activity.Title = txtTitle.Text;
            Activity.CompleteBy = datePicker.Value.Date;
            Activity.Status = (Status)comboStatus.SelectedItem;

            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
