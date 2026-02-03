namespace Kanaban501app
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private System.Windows.Forms.ListBox listToDo;
        private System.Windows.Forms.ListBox listWorking;
        private System.Windows.Forms.ListBox listDone;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// EDITED to have everything below this.Text = mainform1
        /// tried programmatically adding these instead of through the designer
        /// which was kind of HARD!
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "MainForm1";

            this.listToDo = new System.Windows.Forms.ListBox();
            this.listWorking = new System.Windows.Forms.ListBox();
            this.listDone = new System.Windows.Forms.ListBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();

            this.SuspendLayout();

            this.listToDo.Location = new System.Drawing.Point(12, 12);
            this.listToDo.Size = new System.Drawing.Size(200, 300);

            this.listWorking.Location = new System.Drawing.Point(230, 12);
            this.listWorking.Size = new System.Drawing.Size(200, 300);

            this.listDone.Location = new System.Drawing.Point(450, 12);
            this.listDone.Size = new System.Drawing.Size(200, 300);

            this.btnNew.Text = "New";
            this.btnNew.Location = new System.Drawing.Point(12, 330);
            this.btnNew.Click += new System.EventHandler(this.BtnNew_Click);

            this.btnEdit.Text = "Edit";
            this.btnEdit.Location = new System.Drawing.Point(100, 330);
            this.btnEdit.Click += new System.EventHandler(this.BtnEdit_Click);

            this.btnDelete.Text = "Delete";
            this.btnDelete.Location = new System.Drawing.Point(190, 330);
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);

            this.ClientSize = new System.Drawing.Size(670, 380);
            this.Controls.Add(this.listToDo);
            this.Controls.Add(this.listWorking);
            this.Controls.Add(this.listDone);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Text = "Kanban501";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);

            this.ResumeLayout(false);
        }

        #endregion
    }
}