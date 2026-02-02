using Kanban501;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kanaban501app
{
    public partial class MainForm : Form
    {
        private const string FileName = "GoalActivity.txt";

        public MainForm()
        {
            InitializeComponent();
            LoadData();
            RefreshLists();
        }
        private List<GoalActivity> activities = new List<GoalActivity>();

        private void RefreshLists()
        {
            listToDo.Items.Clear();
            listWorking.Items.Clear();
            listDone.Items.Clear();

            foreach (GoalActivity g in activities)
            {
                if (g.Status == Status.ToDo) listToDo.Items.Add(g);
                if (g.Status == Status.WorkingOn) listWorking.Items.Add(g);
                if (g.Status == Status.Done) listDone.Items.Add(g);
            }

            btnNew.Enabled = listToDo.Items.Count < 15 || listWorking.Items.Count < 3;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            using (var dlg = new GoalDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    activities.Add(dlg.Activity);
                    RefreshLists();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            GoalActivity selected = GetSelected();
            if (selected == null) return;

            using (var dlg = new GoalDialog(selected))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    RefreshLists();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            GoalActivity selected = GetSelected();
            if (selected == null) return;

            activities.Remove(selected);
            RefreshLists();
        }

        private GoalActivity GetSelected()
        {
            if (listToDo.SelectedItem != null) return (GoalActivity)listToDo.SelectedItem;
            if (listWorking.SelectedItem != null) return (GoalActivity)listWorking.SelectedItem;
            if (listDone.SelectedItem != null) return (GoalActivity)listDone.SelectedItem;
            return null;
        }

        private void LoadData()
        {
            if (!File.Exists(FileName)) return;

            foreach (var line in File.ReadAllLines(FileName))
            {
                activities.Add(GoalActivity.FromFileString(line));
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(FileName))
            {
                foreach (var g in activities)
                    sw.WriteLine(g.ToFileString());
            }
        }
    }
}
