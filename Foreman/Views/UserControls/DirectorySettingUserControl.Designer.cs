namespace Foreman.Views.Controls
{
    partial class DirectorySettingControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelDirectory = new System.Windows.Forms.Label();
            this.labelInfo = new System.Windows.Forms.Label();
            this.labelInfoValue = new System.Windows.Forms.Label();
            this.comboBoxSelectDirectory = new System.Windows.Forms.ComboBox();
            this.buttonSelectDirectory = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(713, 159);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.labelDirectory, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelInfo, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelInfoValue, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxSelectDirectory, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonSelectDirectory, 2, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(707, 140);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelDirectory
            // 
            this.labelDirectory.AutoSize = true;
            this.labelDirectory.Location = new System.Drawing.Point(3, 0);
            this.labelDirectory.MaximumSize = new System.Drawing.Size(300, 13);
            this.labelDirectory.MinimumSize = new System.Drawing.Size(300, 13);
            this.labelDirectory.Name = "labelDirectory";
            this.labelDirectory.Size = new System.Drawing.Size(300, 13);
            this.labelDirectory.TabIndex = 0;
            this.labelDirectory.Text = "Directory";
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Location = new System.Drawing.Point(503, 0);
            this.labelInfo.MaximumSize = new System.Drawing.Size(200, 13);
            this.labelInfo.MinimumSize = new System.Drawing.Size(200, 13);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(200, 13);
            this.labelInfo.TabIndex = 1;
            this.labelInfo.Text = "Info";
            // 
            // labelInfoValue
            // 
            this.labelInfoValue.AutoSize = true;
            this.labelInfoValue.Location = new System.Drawing.Point(503, 27);
            this.labelInfoValue.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.labelInfoValue.MaximumSize = new System.Drawing.Size(200, 13);
            this.labelInfoValue.MinimumSize = new System.Drawing.Size(200, 13);
            this.labelInfoValue.Name = "labelInfoValue";
            this.labelInfoValue.Size = new System.Drawing.Size(200, 13);
            this.labelInfoValue.TabIndex = 2;
            this.labelInfoValue.Text = "InfoValue";
            // 
            // comboBoxSelectDirectory
            // 
            this.comboBoxSelectDirectory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSelectDirectory.FormattingEnabled = true;
            this.comboBoxSelectDirectory.Location = new System.Drawing.Point(3, 24);
            this.comboBoxSelectDirectory.MaximumSize = new System.Drawing.Size(350, 0);
            this.comboBoxSelectDirectory.MinimumSize = new System.Drawing.Size(350, 0);
            this.comboBoxSelectDirectory.Name = "comboBoxSelectDirectory";
            this.comboBoxSelectDirectory.Size = new System.Drawing.Size(450, 21);
            this.comboBoxSelectDirectory.TabIndex = 4;
            this.comboBoxSelectDirectory.TextChanged += new System.EventHandler(this.comboBox1_TextChanged);
            // 
            // buttonSelectDirectory
            // 
            this.buttonSelectDirectory.Location = new System.Drawing.Point(458, 23);
            this.buttonSelectDirectory.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSelectDirectory.MaximumSize = new System.Drawing.Size(25, 23);
            this.buttonSelectDirectory.MinimumSize = new System.Drawing.Size(25, 23);
            this.buttonSelectDirectory.Name = "buttonSelectDirectory";
            this.buttonSelectDirectory.Size = new System.Drawing.Size(25, 23);
            this.buttonSelectDirectory.TabIndex = 9;
            this.buttonSelectDirectory.Text = "...";
            this.buttonSelectDirectory.UseVisualStyleBackColor = true;
            this.buttonSelectDirectory.Click += new System.EventHandler(this.buttonSelectDirectory_Click);
            // 
            // DirectorySettingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new System.Drawing.Size(713, 70);
            this.Name = "DirectorySettingControl";
            this.Size = new System.Drawing.Size(713, 159);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelDirectory;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Label labelInfoValue;
        private System.Windows.Forms.ComboBox comboBoxSelectDirectory;
        private System.Windows.Forms.Button buttonSelectDirectory;
    }
}
