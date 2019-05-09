namespace Foreman.Views
{
    partial class SettingsView
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonGameDir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxGameDir = new System.Windows.Forms.TextBox();
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxModDir = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonModDir = new System.Windows.Forms.Button();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.buttonSaveSettings = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Controls.Add(this.buttonGameDir, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBoxGameDir, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxLanguage, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.textBoxModDir, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.buttonModDir, 3, 7);
            this.tableLayoutPanel1.Controls.Add(this.buttonSaveSettings, 5, 13);
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 15;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(742, 426);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // buttonGameDir
            // 
            this.buttonGameDir.Location = new System.Drawing.Point(295, 95);
            this.buttonGameDir.Margin = new System.Windows.Forms.Padding(0);
            this.buttonGameDir.MaximumSize = new System.Drawing.Size(30, 22);
            this.buttonGameDir.MinimumSize = new System.Drawing.Size(30, 22);
            this.buttonGameDir.Name = "buttonGameDir";
            this.buttonGameDir.Size = new System.Drawing.Size(30, 22);
            this.buttonGameDir.TabIndex = 1;
            this.buttonGameDir.Text = "...";
            this.buttonGameDir.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 75);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.MaximumSize = new System.Drawing.Size(0, 20);
            this.label1.MinimumSize = new System.Drawing.Size(250, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Factorio Game Directory";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxGameDir
            // 
            this.textBoxGameDir.Location = new System.Drawing.Point(40, 96);
            this.textBoxGameDir.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.textBoxGameDir.MaximumSize = new System.Drawing.Size(4, 20);
            this.textBoxGameDir.MinimumSize = new System.Drawing.Size(250, 20);
            this.textBoxGameDir.Name = "textBoxGameDir";
            this.textBoxGameDir.Size = new System.Drawing.Size(250, 20);
            this.textBoxGameDir.TabIndex = 2;
            // 
            // comboBoxLanguage
            // 
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Location = new System.Drawing.Point(40, 219);
            this.comboBoxLanguage.Margin = new System.Windows.Forms.Padding(0);
            this.comboBoxLanguage.MinimumSize = new System.Drawing.Size(150, 0);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(150, 21);
            this.comboBoxLanguage.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 199);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.MaximumSize = new System.Drawing.Size(0, 20);
            this.label2.MinimumSize = new System.Drawing.Size(250, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(250, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Language";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxModDir
            // 
            this.textBoxModDir.Location = new System.Drawing.Point(40, 158);
            this.textBoxModDir.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.textBoxModDir.MaximumSize = new System.Drawing.Size(4, 20);
            this.textBoxModDir.MinimumSize = new System.Drawing.Size(250, 20);
            this.textBoxModDir.Name = "textBoxModDir";
            this.textBoxModDir.Size = new System.Drawing.Size(250, 20);
            this.textBoxModDir.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 137);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.MaximumSize = new System.Drawing.Size(0, 20);
            this.label3.MinimumSize = new System.Drawing.Size(250, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(250, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Factorio Mod Directory";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonModDir
            // 
            this.buttonModDir.Location = new System.Drawing.Point(295, 157);
            this.buttonModDir.Margin = new System.Windows.Forms.Padding(0);
            this.buttonModDir.MaximumSize = new System.Drawing.Size(30, 22);
            this.buttonModDir.MinimumSize = new System.Drawing.Size(30, 22);
            this.buttonModDir.Name = "buttonModDir";
            this.buttonModDir.Size = new System.Drawing.Size(30, 22);
            this.buttonModDir.TabIndex = 5;
            this.buttonModDir.Text = "...";
            this.buttonModDir.UseVisualStyleBackColor = true;
            // 
            // buttonSaveSettings
            // 
            this.buttonSaveSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveSettings.Location = new System.Drawing.Point(627, 383);
            this.buttonSaveSettings.Margin = new System.Windows.Forms.Padding(0);
            this.buttonSaveSettings.MaximumSize = new System.Drawing.Size(75, 23);
            this.buttonSaveSettings.MinimumSize = new System.Drawing.Size(75, 23);
            this.buttonSaveSettings.Name = "buttonSaveSettings";
            this.buttonSaveSettings.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveSettings.TabIndex = 6;
            this.buttonSaveSettings.Text = "Save";
            this.buttonSaveSettings.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(40, 20);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.MaximumSize = new System.Drawing.Size(0, 35);
            this.label4.MinimumSize = new System.Drawing.Size(250, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(250, 35);
            this.label4.TabIndex = 7;
            this.label4.Text = "Settings";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SettingsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SettingsView";
            this.Size = new System.Drawing.Size(742, 426);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonGameDir;
        private System.Windows.Forms.TextBox textBoxGameDir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxLanguage;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.TextBox textBoxModDir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonModDir;
        private System.Windows.Forms.Button buttonSaveSettings;
        private System.Windows.Forms.Label label4;
    }
}
