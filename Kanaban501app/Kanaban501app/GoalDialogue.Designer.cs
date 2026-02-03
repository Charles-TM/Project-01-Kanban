namespace Kanban501
{
    partial class GoalDialog
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblResources;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.ComboBox comboStatus;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblResourcesAct;
        private System.Windows.Forms.RichTextBox txtResources;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            #region initComponents
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblResources = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.comboStatus = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblResourcesAct = new System.Windows.Forms.Label();
            this.txtResources = new System.Windows.Forms.RichTextBox();
            #endregion
            
            this.SuspendLayout();
            
            #region lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(15, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(36, 16);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Title:";
            #endregion
           
            #region lblDate
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(15, 57);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(87, 16);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "Complete By:";
            #endregion
           
            #region lblStatus
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(15, 97);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(47, 16);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Status:";
            #endregion
            
            #region lblResources
            this.lblResources.AutoSize = true;
            this.lblResources.Location = new System.Drawing.Point(15, 55);
            this.lblResources.Name = "lblResources";
            this.lblResources.Size = new System.Drawing.Size(87, 16);
            this.lblResources.TabIndex = 0;
            this.lblResources.Text = "Resources:";
            #endregion
            
            
            #region txtTitle
            this.txtTitle.Location = new System.Drawing.Point(110, 12);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(200, 22);
            this.txtTitle.TabIndex = 0;
            #endregion
           
            #region datePicker
            this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePicker.Location = new System.Drawing.Point(110, 54);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(200, 22);
            this.datePicker.TabIndex = 1;
            #endregion
            
            #region comboStatus
            this.comboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboStatus.Location = new System.Drawing.Point(110, 94);
            this.comboStatus.Name = "comboStatus";
            this.comboStatus.Size = new System.Drawing.Size(121, 24);
            this.comboStatus.TabIndex = 2;
            #endregion
            
            #region btnOK
            this.btnOK.Location = new System.Drawing.Point(110, 142);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 28);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.BtnOK_Click);
            #endregion

            #region btnCancel
            this.btnCancel.Location = new System.Drawing.Point(195, 142);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 28);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            #endregion
            
            #region lblResources
            this.lblResourcesAct.AutoSize = true;
            this.lblResourcesAct.Location = new System.Drawing.Point(343, 18);
            this.lblResourcesAct.Name = "lblResourcesAct";
            this.lblResourcesAct.Size = new System.Drawing.Size(76, 16);
            this.lblResourcesAct.TabIndex = 5;
            this.lblResourcesAct.Text = "Resources:";
            #endregion
            
            #region txtResources
            this.txtResources.Location = new System.Drawing.Point(345, 52);
            this.txtResources.Name = "txtResources";
            this.txtResources.Size = new System.Drawing.Size(234, 290);
            this.txtResources.TabIndex = 6;
            this.txtResources.Text = "";
            #endregion
            
            #region GoalDialog
            this.ClientSize = new System.Drawing.Size(609, 384);
            this.Controls.Add(this.txtResources);
            this.Controls.Add(this.lblResourcesAct);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.comboStatus);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GoalDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Goal / Activity";
            #endregion
            
            this.ResumeLayout(false);

            this.PerformLayout();

        }

        
    }
}
