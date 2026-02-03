using Kanban501;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Kanaban501app
{
    /// <summary>
    /// the main view for all three goals types, doesnt show resources per task
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// where the goals are stored for use after closing program
        /// </summary>
        private const string _fileName = "GoalActivity.txt";

        public MainForm()
        {
            InitializeComponent();
            listToDo.DrawMode = DrawMode.OwnerDrawFixed;
            listWorking.DrawMode = DrawMode.OwnerDrawFixed;
            listDone.DrawMode = DrawMode.OwnerDrawFixed;
            listToDo.DrawItem += List_DrawItem;
            listWorking.DrawItem += List_DrawItem;
            listDone.DrawItem += List_DrawItem;
            LoadData();
            RefreshLists();
        }
        /// <summary>
        /// list of all goals for display
        /// </summary>
        private readonly List<GoalActivity> _activities = new List<GoalActivity>();
        /// <summary>
        /// called when list is edited
        /// </summary>
        private void RefreshLists()
        {
            listToDo.Items.Clear();
            listWorking.Items.Clear();
            listDone.Items.Clear();

            foreach (GoalActivity g in _activities)
            {
                if (g.Status == Status.ToDo) listToDo.Items.Add(g);
                if (g.Status == Status.WorkingOn) listWorking.Items.Add(g);
                if (g.Status == Status.Done) listDone.Items.Add(g);
            }

            btnNew.Enabled =
                listToDo.Items.Count < 15 &&
                listWorking.Items.Count < 3;
        }
        /// <summary>
        /// starts the goal dialogue edit a new goal
        /// </summary>
        /// <param name="sender">button</param>
        /// <param name="e">click</param>
        private void BtnNew_Click(object sender, EventArgs e)
        {
            using (var dlg = new GoalDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _activities.Add(dlg.Activity);
                    RefreshLists();
                }
            }
        }
        /// <summary>
        /// starts the goal dialogue without creating a blank goal to edit
        /// </summary>
        /// <param name="sender">button</param>
        /// <param name="e">click</param>
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            GoalActivity selected = GetSelected();
            if (selected == null) return;

            using (var dlg = new GoalDialog(selected))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (selected.Status == Status.WorkingOn && !CanMoveToWorkingOn(selected))
                    {
                        MessageBox.Show("Only 3 activities can be in Working On.");
                        selected.Status = Status.ToDo;
                    }

                    RefreshLists();
                }
            }
        }
        /// <summary>
        /// removes the selected activity 
        /// </summary>
        /// <param name="sender">delete button</param>
        /// <param name="e">click</param>
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            GoalActivity selected = GetSelected();
            if (selected == null) return;

            _activities.Remove(selected);
            RefreshLists();
        }
        /// <summary>
        /// helping method, didnt want to copy and paste it
        /// </summary>
        /// <returns>the listbox item typed as a goalactivity</returns>
        private GoalActivity GetSelected()
        {
            if (listToDo.SelectedItem != null) return (GoalActivity)listToDo.SelectedItem;
            if (listWorking.SelectedItem != null) return (GoalActivity)listWorking.SelectedItem;
            if (listDone.SelectedItem != null) return (GoalActivity)listDone.SelectedItem;
            return null;
        }
        /// <summary>
        /// grabs data using GoalActivities internal file to string methods
        /// </summary>
        private void LoadData()
        {
            if (!File.Exists(_fileName)) return;

            foreach (var line in File.ReadAllLines(_fileName))
            {
                _activities.Add(GoalActivity.FromFileString(line));
            }
        }
        /// <summary>
        /// when closing the main form, send all the goals to "Goals activity"
        /// </summary>
        /// <param name="sender">mainform task ends</param>
        /// <param name="e">the form closing</param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(_fileName))
            {
                foreach (var g in _activities)
                    sw.WriteLine(g.ToFileString());
            }
        }
        /// <summary>
        /// gets the listbox item thats overdue and changes its forecolor red
        /// </summary>
        /// <param name="sender">lists</param>
        /// <param name="e">make it red</param>
        private void List_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            var list = (ListBox)sender;
            var activity = (GoalActivity)list.Items[e.Index];

            bool overdue = activity.CompleteBy.Date < DateTime.Today &&
                            activity.Status != Status.Done;

            e.DrawBackground();

            Color color = overdue ? Color.Red : e.ForeColor;

            TextRenderer.DrawText(
                e.Graphics,
                activity.ToString(),
                e.Font,
                e.Bounds,
                color
            );

            e.DrawFocusRectangle();
        }
        /// <summary>
        /// makes sure that any edit or added item cant be grandfathered in to break the 15 3 limits
        /// </summary>
        /// <param name="activity">current goal</param>
        /// <returns>if you can move it</returns>
        private bool CanMoveToWorkingOn(GoalActivity activity)
        {
            int workingCount = _activities.Count(a =>
                a.Status == Status.WorkingOn && a != activity);

            return workingCount < 3;
        }


    }
}
