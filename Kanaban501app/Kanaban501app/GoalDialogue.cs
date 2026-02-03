using Kanaban501app;
using System;
using System.Windows.Forms;

namespace Kanban501
{
    /// <summary>
    /// Add and edit dialogue
    /// </summary>
    public partial class GoalDialog : Form
    {
        /// <summary>
        /// blank activity to make new goals
        /// </summary>
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
            txtResources.Text = activity.Resources;
        }
        /// <summary>
        /// submits changes to add edit goals
        /// </summary>
        /// <param name="sender">button</param>
        /// <param name="e">click</param>

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text == string.Empty)
            {
                MessageBox.Show("Please give this goal a name!");
            }
            else
            {

                if (Activity == null)
                    Activity = new GoalActivity();

                Activity.Title = txtTitle.Text;
                Activity.CompleteBy = datePicker.Value.Date;
                Activity.Status = (Status)comboStatus.SelectedItem;
                Activity.Resources = txtResources.Text;


                DialogResult = DialogResult.OK;
            }
        }
        /// <summary>
        /// cancels changes to add edit goals
        /// </summary>
        /// <param name="sender">button</param>
        /// <param name="e">click</param>
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
