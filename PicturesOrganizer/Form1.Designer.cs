namespace PicturesOrganizer
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxFolderPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSelectFolder = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxYearFolder = new System.Windows.Forms.CheckBox();
            this.checkBoxMonthFolder = new System.Windows.Forms.CheckBox();
            this.checkBoxDateFolder = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxAddTag = new System.Windows.Forms.TextBox();
            this.buttonAddTag = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.listBoxTags = new System.Windows.Forms.ListBox();
            this.buttonStartOrganizing = new System.Windows.Forms.Button();
            this.progressBarOrganizing = new System.Windows.Forms.ProgressBar();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxOutputFolderPath = new System.Windows.Forms.TextBox();
            this.buttonSelectOutputFolder = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.radioButtonMoveFiles = new System.Windows.Forms.RadioButton();
            this.radioButtonCopyFiles = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBoxFileNameDate = new System.Windows.Forms.CheckBox();
            this.textBoxFileNameDateFormat = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxFileExtensions = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxSetNewDate = new System.Windows.Forms.CheckBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.radioButtonDateCustom = new System.Windows.Forms.RadioButton();
            this.radioButtonDateReadFromFile = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxNewName = new System.Windows.Forms.TextBox();
            this.checkBoxNewName = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxFolderPath
            // 
            this.textBoxFolderPath.Enabled = false;
            this.textBoxFolderPath.Location = new System.Drawing.Point(136, 30);
            this.textBoxFolderPath.Name = "textBoxFolderPath";
            this.textBoxFolderPath.Size = new System.Drawing.Size(335, 20);
            this.textBoxFolderPath.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Path ";
            // 
            // buttonSelectFolder
            // 
            this.buttonSelectFolder.Location = new System.Drawing.Point(477, 29);
            this.buttonSelectFolder.Name = "buttonSelectFolder";
            this.buttonSelectFolder.Size = new System.Drawing.Size(92, 23);
            this.buttonSelectFolder.TabIndex = 2;
            this.buttonSelectFolder.Text = "Select Folder";
            this.buttonSelectFolder.UseVisualStyleBackColor = true;
            this.buttonSelectFolder.Click += new System.EventHandler(this.buttonSelectFolder_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Folders Hierarchy";
            // 
            // checkBoxYearFolder
            // 
            this.checkBoxYearFolder.AutoSize = true;
            this.checkBoxYearFolder.Checked = true;
            this.checkBoxYearFolder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxYearFolder.Enabled = false;
            this.checkBoxYearFolder.Location = new System.Drawing.Point(134, 208);
            this.checkBoxYearFolder.Name = "checkBoxYearFolder";
            this.checkBoxYearFolder.Size = new System.Drawing.Size(48, 17);
            this.checkBoxYearFolder.TabIndex = 4;
            this.checkBoxYearFolder.Text = "Year";
            this.checkBoxYearFolder.UseVisualStyleBackColor = true;
            // 
            // checkBoxMonthFolder
            // 
            this.checkBoxMonthFolder.AutoSize = true;
            this.checkBoxMonthFolder.Checked = true;
            this.checkBoxMonthFolder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxMonthFolder.Location = new System.Drawing.Point(188, 208);
            this.checkBoxMonthFolder.Name = "checkBoxMonthFolder";
            this.checkBoxMonthFolder.Size = new System.Drawing.Size(56, 17);
            this.checkBoxMonthFolder.TabIndex = 5;
            this.checkBoxMonthFolder.Text = "Month";
            this.checkBoxMonthFolder.UseVisualStyleBackColor = true;
            // 
            // checkBoxDateFolder
            // 
            this.checkBoxDateFolder.AutoSize = true;
            this.checkBoxDateFolder.Location = new System.Drawing.Point(250, 208);
            this.checkBoxDateFolder.Name = "checkBoxDateFolder";
            this.checkBoxDateFolder.Size = new System.Drawing.Size(49, 17);
            this.checkBoxDateFolder.TabIndex = 6;
            this.checkBoxDateFolder.Text = "Date";
            this.checkBoxDateFolder.UseVisualStyleBackColor = true;
            this.checkBoxDateFolder.CheckedChanged += new System.EventHandler(this.checkBoxDateFolder_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 234);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Add Tags ";
            // 
            // textBoxAddTag
            // 
            this.textBoxAddTag.Location = new System.Drawing.Point(133, 231);
            this.textBoxAddTag.Name = "textBoxAddTag";
            this.textBoxAddTag.Size = new System.Drawing.Size(165, 20);
            this.textBoxAddTag.TabIndex = 8;
            // 
            // buttonAddTag
            // 
            this.buttonAddTag.Location = new System.Drawing.Point(304, 229);
            this.buttonAddTag.Name = "buttonAddTag";
            this.buttonAddTag.Size = new System.Drawing.Size(75, 23);
            this.buttonAddTag.TabIndex = 9;
            this.buttonAddTag.Text = "Add";
            this.buttonAddTag.UseVisualStyleBackColor = true;
            this.buttonAddTag.Click += new System.EventHandler(this.buttonAddTag_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 267);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Set New Date ";
            // 
            // listBoxTags
            // 
            this.listBoxTags.FormattingEnabled = true;
            this.listBoxTags.Location = new System.Drawing.Point(385, 231);
            this.listBoxTags.Name = "listBoxTags";
            this.listBoxTags.Size = new System.Drawing.Size(181, 121);
            this.listBoxTags.TabIndex = 11;
            // 
            // buttonStartOrganizing
            // 
            this.buttonStartOrganizing.Location = new System.Drawing.Point(133, 401);
            this.buttonStartOrganizing.Name = "buttonStartOrganizing";
            this.buttonStartOrganizing.Size = new System.Drawing.Size(110, 23);
            this.buttonStartOrganizing.TabIndex = 12;
            this.buttonStartOrganizing.Text = "Start Organizing";
            this.buttonStartOrganizing.UseVisualStyleBackColor = true;
            this.buttonStartOrganizing.Click += new System.EventHandler(this.buttonStartOrganizing_Click);
            // 
            // progressBarOrganizing
            // 
            this.progressBarOrganizing.Location = new System.Drawing.Point(40, 430);
            this.progressBarOrganizing.Name = "progressBarOrganizing";
            this.progressBarOrganizing.Size = new System.Drawing.Size(526, 23);
            this.progressBarOrganizing.TabIndex = 13;
            this.progressBarOrganizing.Value = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Output Path ";
            // 
            // textBoxOutputFolderPath
            // 
            this.textBoxOutputFolderPath.Enabled = false;
            this.textBoxOutputFolderPath.Location = new System.Drawing.Point(135, 63);
            this.textBoxOutputFolderPath.Name = "textBoxOutputFolderPath";
            this.textBoxOutputFolderPath.Size = new System.Drawing.Size(336, 20);
            this.textBoxOutputFolderPath.TabIndex = 15;
            // 
            // buttonSelectOutputFolder
            // 
            this.buttonSelectOutputFolder.Location = new System.Drawing.Point(478, 63);
            this.buttonSelectOutputFolder.Name = "buttonSelectOutputFolder";
            this.buttonSelectOutputFolder.Size = new System.Drawing.Size(91, 23);
            this.buttonSelectOutputFolder.TabIndex = 16;
            this.buttonSelectOutputFolder.Text = "Select Output";
            this.buttonSelectOutputFolder.UseVisualStyleBackColor = true;
            this.buttonSelectOutputFolder.Click += new System.EventHandler(this.buttonSelectOutputFolder_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(47, 380);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Organize Mode ";
            // 
            // radioButtonMoveFiles
            // 
            this.radioButtonMoveFiles.AutoSize = true;
            this.radioButtonMoveFiles.Location = new System.Drawing.Point(143, 378);
            this.radioButtonMoveFiles.Name = "radioButtonMoveFiles";
            this.radioButtonMoveFiles.Size = new System.Drawing.Size(76, 17);
            this.radioButtonMoveFiles.TabIndex = 18;
            this.radioButtonMoveFiles.Text = "Move Files";
            this.radioButtonMoveFiles.UseVisualStyleBackColor = true;
            this.radioButtonMoveFiles.CheckedChanged += new System.EventHandler(this.radioButtonMoveFiles_CheckedChanged);
            // 
            // radioButtonCopyFiles
            // 
            this.radioButtonCopyFiles.AutoSize = true;
            this.radioButtonCopyFiles.Checked = true;
            this.radioButtonCopyFiles.Location = new System.Drawing.Point(225, 378);
            this.radioButtonCopyFiles.Name = "radioButtonCopyFiles";
            this.radioButtonCopyFiles.Size = new System.Drawing.Size(73, 17);
            this.radioButtonCopyFiles.TabIndex = 19;
            this.radioButtonCopyFiles.TabStop = true;
            this.radioButtonCopyFiles.Text = "Copy Files";
            this.radioButtonCopyFiles.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(40, 176);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "File Date Mode";
            // 
            // checkBoxFileNameDate
            // 
            this.checkBoxFileNameDate.AutoSize = true;
            this.checkBoxFileNameDate.Location = new System.Drawing.Point(134, 175);
            this.checkBoxFileNameDate.Name = "checkBoxFileNameDate";
            this.checkBoxFileNameDate.Size = new System.Drawing.Size(73, 17);
            this.checkBoxFileNameDate.TabIndex = 21;
            this.checkBoxFileNameDate.Text = "File Name";
            this.checkBoxFileNameDate.UseVisualStyleBackColor = true;
            this.checkBoxFileNameDate.CheckedChanged += new System.EventHandler(this.checkBoxFileNameDate_CheckedChanged);
            // 
            // textBoxFileNameDateFormat
            // 
            this.textBoxFileNameDateFormat.Enabled = false;
            this.textBoxFileNameDateFormat.Location = new System.Drawing.Point(279, 173);
            this.textBoxFileNameDateFormat.Name = "textBoxFileNameDateFormat";
            this.textBoxFileNameDateFormat.Size = new System.Drawing.Size(192, 20);
            this.textBoxFileNameDateFormat.TabIndex = 22;
            this.textBoxFileNameDateFormat.Text = "yyyyMMdd";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(231, 176);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Format ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(40, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "File Extensions";
            // 
            // textBoxFileExtensions
            // 
            this.textBoxFileExtensions.Location = new System.Drawing.Point(135, 100);
            this.textBoxFileExtensions.Multiline = true;
            this.textBoxFileExtensions.Name = "textBoxFileExtensions";
            this.textBoxFileExtensions.Size = new System.Drawing.Size(336, 67);
            this.textBoxFileExtensions.TabIndex = 25;
            this.textBoxFileExtensions.Text = "*.jpg,*.gif,*.png,*.bmp,*.jpe,*.jpeg,*.wmf,*.avi,*.mp4,*.3gp,*.amr,*.wav,*.mp3";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxSetNewDate);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.radioButtonDateCustom);
            this.groupBox1.Controls.Add(this.radioButtonDateReadFromFile);
            this.groupBox1.Location = new System.Drawing.Point(134, 257);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(245, 66);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            // 
            // checkBoxSetNewDate
            // 
            this.checkBoxSetNewDate.AutoSize = true;
            this.checkBoxSetNewDate.Location = new System.Drawing.Point(7, 11);
            this.checkBoxSetNewDate.Name = "checkBoxSetNewDate";
            this.checkBoxSetNewDate.Size = new System.Drawing.Size(44, 17);
            this.checkBoxSetNewDate.TabIndex = 5;
            this.checkBoxSetNewDate.Text = "Yes";
            this.checkBoxSetNewDate.UseVisualStyleBackColor = true;
            this.checkBoxSetNewDate.CheckedChanged += new System.EventHandler(this.checkBoxSetNewDate_CheckedChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Location = new System.Drawing.Point(7, 40);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // radioButtonDateCustom
            // 
            this.radioButtonDateCustom.AutoSize = true;
            this.radioButtonDateCustom.Enabled = false;
            this.radioButtonDateCustom.Location = new System.Drawing.Point(171, 10);
            this.radioButtonDateCustom.Name = "radioButtonDateCustom";
            this.radioButtonDateCustom.Size = new System.Drawing.Size(60, 17);
            this.radioButtonDateCustom.TabIndex = 1;
            this.radioButtonDateCustom.Text = "Custom";
            this.radioButtonDateCustom.UseVisualStyleBackColor = true;
            this.radioButtonDateCustom.CheckedChanged += new System.EventHandler(this.radioButtonDateCustom_CheckedChanged);
            // 
            // radioButtonDateReadFromFile
            // 
            this.radioButtonDateReadFromFile.AutoSize = true;
            this.radioButtonDateReadFromFile.Checked = true;
            this.radioButtonDateReadFromFile.Enabled = false;
            this.radioButtonDateReadFromFile.Location = new System.Drawing.Point(57, 10);
            this.radioButtonDateReadFromFile.Name = "radioButtonDateReadFromFile";
            this.radioButtonDateReadFromFile.Size = new System.Drawing.Size(96, 17);
            this.radioButtonDateReadFromFile.TabIndex = 0;
            this.radioButtonDateReadFromFile.TabStop = true;
            this.radioButtonDateReadFromFile.Text = "Read From File";
            this.radioButtonDateReadFromFile.UseVisualStyleBackColor = true;
            this.radioButtonDateReadFromFile.CheckedChanged += new System.EventHandler(this.radioButtonDateReadFromFile_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(43, 338);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "Set New Name";
            // 
            // textBoxNewName
            // 
            this.textBoxNewName.Enabled = false;
            this.textBoxNewName.Location = new System.Drawing.Point(184, 339);
            this.textBoxNewName.Name = "textBoxNewName";
            this.textBoxNewName.Size = new System.Drawing.Size(195, 20);
            this.textBoxNewName.TabIndex = 28;
            // 
            // checkBoxNewName
            // 
            this.checkBoxNewName.AutoSize = true;
            this.checkBoxNewName.Location = new System.Drawing.Point(134, 341);
            this.checkBoxNewName.Name = "checkBoxNewName";
            this.checkBoxNewName.Size = new System.Drawing.Size(44, 17);
            this.checkBoxNewName.TabIndex = 29;
            this.checkBoxNewName.Text = "Yes";
            this.checkBoxNewName.UseVisualStyleBackColor = true;
            this.checkBoxNewName.CheckedChanged += new System.EventHandler(this.checkBoxNewName_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 465);
            this.Controls.Add(this.checkBoxNewName);
            this.Controls.Add(this.textBoxNewName);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBoxFileExtensions);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxFileNameDateFormat);
            this.Controls.Add(this.checkBoxFileNameDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.radioButtonCopyFiles);
            this.Controls.Add(this.radioButtonMoveFiles);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.buttonSelectOutputFolder);
            this.Controls.Add(this.textBoxOutputFolderPath);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.progressBarOrganizing);
            this.Controls.Add(this.buttonStartOrganizing);
            this.Controls.Add(this.listBoxTags);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonAddTag);
            this.Controls.Add(this.textBoxAddTag);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkBoxDateFolder);
            this.Controls.Add(this.checkBoxMonthFolder);
            this.Controls.Add(this.checkBoxYearFolder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonSelectFolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxFolderPath);
            this.Name = "Form1";
            this.Text = "Pictures Organizer";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxFolderPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSelectFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxYearFolder;
        private System.Windows.Forms.CheckBox checkBoxMonthFolder;
        private System.Windows.Forms.CheckBox checkBoxDateFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxAddTag;
        private System.Windows.Forms.Button buttonAddTag;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBoxTags;
        private System.Windows.Forms.Button buttonStartOrganizing;
        private System.Windows.Forms.ProgressBar progressBarOrganizing;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxOutputFolderPath;
        private System.Windows.Forms.Button buttonSelectOutputFolder;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton radioButtonMoveFiles;
        private System.Windows.Forms.RadioButton radioButtonCopyFiles;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBoxFileNameDate;
        private System.Windows.Forms.TextBox textBoxFileNameDateFormat;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxFileExtensions;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonDateCustom;
        private System.Windows.Forms.RadioButton radioButtonDateReadFromFile;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.CheckBox checkBoxSetNewDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxNewName;
        private System.Windows.Forms.CheckBox checkBoxNewName;
    }
}

