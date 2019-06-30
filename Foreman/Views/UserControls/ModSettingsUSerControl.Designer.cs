﻿namespace Foreman.Views.UserControls
{
    partial class ModSettingsUserControl
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
            this.radioButtonModList = new System.Windows.Forms.RadioButton();
            this.radioButtonCustom = new System.Windows.Forms.RadioButton();
            this.treeViewModProperties = new System.Windows.Forms.TreeView();
            this.checkedListBoxSelectedMods = new Foreman.CheckedListBoxWithErrors();
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
            this.groupBox1.Size = new System.Drawing.Size(613, 500);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.labelDirectory, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelInfo, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelInfoValue, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxSelectDirectory, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonSelectDirectory, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.radioButtonModList, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.radioButtonCustom, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.treeViewModProperties, 4, 8);
            this.tableLayoutPanel1.Controls.Add(this.checkedListBoxSelectedMods, 0, 8);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(607, 481);
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
            this.labelInfo.Location = new System.Drawing.Point(398, 0);
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
            this.labelInfoValue.Location = new System.Drawing.Point(398, 27);
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
            this.comboBoxSelectDirectory.Size = new System.Drawing.Size(350, 21);
            this.comboBoxSelectDirectory.TabIndex = 4;
            this.comboBoxSelectDirectory.TextChanged += new System.EventHandler(this.comboBoxSelectDirectory_TextChanged);
            // 
            // buttonSelectDirectory
            // 
            this.buttonSelectDirectory.Location = new System.Drawing.Point(358, 23);
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
            // radioButtonModList
            // 
            this.radioButtonModList.AutoSize = true;
            this.radioButtonModList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButtonModList.Location = new System.Drawing.Point(3, 59);
            this.radioButtonModList.Name = "radioButtonModList";
            this.radioButtonModList.Size = new System.Drawing.Size(350, 17);
            this.radioButtonModList.TabIndex = 10;
            this.radioButtonModList.Text = "Use modlist";
            this.radioButtonModList.UseVisualStyleBackColor = true;
            this.radioButtonModList.CheckedChanged += new System.EventHandler(this.radioButtonModList_CheckedChanged);
            // 
            // radioButtonCustom
            // 
            this.radioButtonCustom.AutoSize = true;
            this.radioButtonCustom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButtonCustom.Location = new System.Drawing.Point(3, 82);
            this.radioButtonCustom.Name = "radioButtonCustom";
            this.radioButtonCustom.Size = new System.Drawing.Size(350, 17);
            this.radioButtonCustom.TabIndex = 11;
            this.radioButtonCustom.TabStop = true;
            this.radioButtonCustom.Text = "Custom modselection";
            this.radioButtonCustom.UseVisualStyleBackColor = true;
            // 
            // treeViewModProperties
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.treeViewModProperties, 2);
            this.treeViewModProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewModProperties.Location = new System.Drawing.Point(398, 113);
            this.treeViewModProperties.MaximumSize = new System.Drawing.Size(350, 350);
            this.treeViewModProperties.MinimumSize = new System.Drawing.Size(350, 350);
            this.treeViewModProperties.Name = "treeViewModProperties";
            this.treeViewModProperties.ShowPlusMinus = false;
            this.treeViewModProperties.Size = new System.Drawing.Size(350, 350);
            this.treeViewModProperties.TabIndex = 13;
            // 
            // checkedListBoxSelectedMods
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.checkedListBoxSelectedMods, 3);
            this.checkedListBoxSelectedMods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBoxSelectedMods.FormattingEnabled = true;
            this.checkedListBoxSelectedMods.Location = new System.Drawing.Point(3, 113);
            this.checkedListBoxSelectedMods.Name = "checkedListBoxSelectedMods";
            this.checkedListBoxSelectedMods.Size = new System.Drawing.Size(379, 365);
            this.checkedListBoxSelectedMods.TabIndex = 14;
            this.checkedListBoxSelectedMods.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxSelectedMods_SelectedIndexChanged);
            this.checkedListBoxSelectedMods.SelectedValueChanged += new System.EventHandler(this.checkedListBoxSelectedMods_SelectedValueChanged);
            // 
            // ModSettingsUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(0, 500);
            this.MinimumSize = new System.Drawing.Size(613, 264);
            this.Name = "ModSettingsUserControl";
            this.Size = new System.Drawing.Size(613, 500);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Label labelInfoValue;
        private System.Windows.Forms.Button buttonSelectDirectory;
        private System.Windows.Forms.Label labelDirectory;
        private System.Windows.Forms.ComboBox comboBoxSelectDirectory;
        private System.Windows.Forms.RadioButton radioButtonModList;
        private System.Windows.Forms.RadioButton radioButtonCustom;
        private System.Windows.Forms.TreeView treeViewModProperties;
        private Foreman.CheckedListBoxWithErrors checkedListBoxSelectedMods;
    }
}
