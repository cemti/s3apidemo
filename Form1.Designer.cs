namespace S3ApiDemo
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            uploadTabPage = new TabPage();
            uploadButton = new Button();
            targetBucketComboBox = new ComboBox();
            selectFileButton = new Button();
            objectNameTextBox = new TextBox();
            fileTextBox = new TextBox();
            filesTabPage = new TabPage();
            moveObjectButton = new Button();
            renameButton = new Button();
            newObjectNameTextBox = new TextBox();
            deleteButton = new Button();
            downloadButton = new Button();
            moveToBucketComboBox = new ComboBox();
            sourceBucketComboBox = new ComboBox();
            objectListBox = new ListBox();
            bucketsTabPage = new TabPage();
            createBucketButton = new Button();
            deleteBucketButton = new Button();
            bucketNameTextBox = new TextBox();
            bucketToDeleteComboBox = new ComboBox();
            tabControl1.SuspendLayout();
            uploadTabPage.SuspendLayout();
            filesTabPage.SuspendLayout();
            bucketsTabPage.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(uploadTabPage);
            tabControl1.Controls.Add(filesTabPage);
            tabControl1.Controls.Add(bucketsTabPage);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(344, 321);
            tabControl1.TabIndex = 0;
            // 
            // uploadTabPage
            // 
            uploadTabPage.Controls.Add(uploadButton);
            uploadTabPage.Controls.Add(targetBucketComboBox);
            uploadTabPage.Controls.Add(selectFileButton);
            uploadTabPage.Controls.Add(objectNameTextBox);
            uploadTabPage.Controls.Add(fileTextBox);
            uploadTabPage.Location = new Point(4, 24);
            uploadTabPage.Name = "uploadTabPage";
            uploadTabPage.Padding = new Padding(3);
            uploadTabPage.Size = new Size(336, 293);
            uploadTabPage.TabIndex = 0;
            uploadTabPage.Text = "Upload";
            uploadTabPage.UseVisualStyleBackColor = true;
            // 
            // uploadButton
            // 
            uploadButton.Location = new Point(255, 64);
            uploadButton.Name = "uploadButton";
            uploadButton.Size = new Size(75, 23);
            uploadButton.TabIndex = 2;
            uploadButton.Text = "Upload";
            uploadButton.UseVisualStyleBackColor = true;
            uploadButton.Click += UploadButton_Click;
            // 
            // targetBucketComboBox
            // 
            targetBucketComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            targetBucketComboBox.FormattingEnabled = true;
            targetBucketComboBox.Location = new Point(8, 35);
            targetBucketComboBox.Name = "targetBucketComboBox";
            targetBucketComboBox.Size = new Size(241, 23);
            targetBucketComboBox.TabIndex = 1;
            // 
            // selectFileButton
            // 
            selectFileButton.Location = new Point(255, 6);
            selectFileButton.Name = "selectFileButton";
            selectFileButton.Size = new Size(75, 23);
            selectFileButton.TabIndex = 1;
            selectFileButton.Text = "Select file";
            selectFileButton.UseVisualStyleBackColor = true;
            selectFileButton.Click += SelectFileButton_Click;
            // 
            // objectNameTextBox
            // 
            objectNameTextBox.Location = new Point(8, 64);
            objectNameTextBox.Name = "objectNameTextBox";
            objectNameTextBox.PlaceholderText = "Object name";
            objectNameTextBox.Size = new Size(241, 23);
            objectNameTextBox.TabIndex = 0;
            // 
            // fileTextBox
            // 
            fileTextBox.Location = new Point(8, 6);
            fileTextBox.Name = "fileTextBox";
            fileTextBox.ReadOnly = true;
            fileTextBox.Size = new Size(241, 23);
            fileTextBox.TabIndex = 0;
            // 
            // filesTabPage
            // 
            filesTabPage.Controls.Add(moveObjectButton);
            filesTabPage.Controls.Add(renameButton);
            filesTabPage.Controls.Add(newObjectNameTextBox);
            filesTabPage.Controls.Add(deleteButton);
            filesTabPage.Controls.Add(downloadButton);
            filesTabPage.Controls.Add(moveToBucketComboBox);
            filesTabPage.Controls.Add(sourceBucketComboBox);
            filesTabPage.Controls.Add(objectListBox);
            filesTabPage.Location = new Point(4, 24);
            filesTabPage.Name = "filesTabPage";
            filesTabPage.Padding = new Padding(3);
            filesTabPage.Size = new Size(336, 293);
            filesTabPage.TabIndex = 1;
            filesTabPage.Text = "Files";
            filesTabPage.UseVisualStyleBackColor = true;
            // 
            // moveObjectButton
            // 
            moveObjectButton.Location = new Point(207, 200);
            moveObjectButton.Name = "moveObjectButton";
            moveObjectButton.Size = new Size(75, 23);
            moveObjectButton.TabIndex = 5;
            moveObjectButton.Text = "Move";
            moveObjectButton.UseVisualStyleBackColor = true;
            moveObjectButton.Click += MoveObjectButton_Click;
            // 
            // renameButton
            // 
            renameButton.Location = new Point(207, 132);
            renameButton.Name = "renameButton";
            renameButton.Size = new Size(75, 23);
            renameButton.TabIndex = 5;
            renameButton.Text = "Rename";
            renameButton.UseVisualStyleBackColor = true;
            renameButton.Click += RenameButton_Click;
            // 
            // newObjectNameTextBox
            // 
            newObjectNameTextBox.Location = new Point(207, 103);
            newObjectNameTextBox.Name = "newObjectNameTextBox";
            newObjectNameTextBox.PlaceholderText = "New object name";
            newObjectNameTextBox.Size = new Size(121, 23);
            newObjectNameTextBox.TabIndex = 4;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(207, 64);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(75, 23);
            deleteButton.TabIndex = 3;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += DeleteButton_Click;
            // 
            // downloadButton
            // 
            downloadButton.Location = new Point(207, 35);
            downloadButton.Name = "downloadButton";
            downloadButton.Size = new Size(75, 23);
            downloadButton.TabIndex = 2;
            downloadButton.Text = "Download";
            downloadButton.UseVisualStyleBackColor = true;
            downloadButton.Click += DownloadButton_Click;
            // 
            // moveToBucketComboBox
            // 
            moveToBucketComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            moveToBucketComboBox.FormattingEnabled = true;
            moveToBucketComboBox.Location = new Point(209, 171);
            moveToBucketComboBox.Name = "moveToBucketComboBox";
            moveToBucketComboBox.Size = new Size(119, 23);
            moveToBucketComboBox.TabIndex = 1;
            // 
            // sourceBucketComboBox
            // 
            sourceBucketComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            sourceBucketComboBox.FormattingEnabled = true;
            sourceBucketComboBox.Location = new Point(207, 6);
            sourceBucketComboBox.Name = "sourceBucketComboBox";
            sourceBucketComboBox.Size = new Size(121, 23);
            sourceBucketComboBox.TabIndex = 1;
            sourceBucketComboBox.SelectedIndexChanged += SourceBucketComboBox_SelectedIndexChanged;
            // 
            // objectListBox
            // 
            objectListBox.Dock = DockStyle.Left;
            objectListBox.FormattingEnabled = true;
            objectListBox.Location = new Point(3, 3);
            objectListBox.Name = "objectListBox";
            objectListBox.Size = new Size(198, 287);
            objectListBox.TabIndex = 0;
            // 
            // bucketsTabPage
            // 
            bucketsTabPage.Controls.Add(createBucketButton);
            bucketsTabPage.Controls.Add(deleteBucketButton);
            bucketsTabPage.Controls.Add(bucketNameTextBox);
            bucketsTabPage.Controls.Add(bucketToDeleteComboBox);
            bucketsTabPage.Location = new Point(4, 24);
            bucketsTabPage.Name = "bucketsTabPage";
            bucketsTabPage.Padding = new Padding(3);
            bucketsTabPage.Size = new Size(336, 293);
            bucketsTabPage.TabIndex = 2;
            bucketsTabPage.Text = "Buckets";
            bucketsTabPage.UseVisualStyleBackColor = true;
            // 
            // createBucketButton
            // 
            createBucketButton.Location = new Point(255, 35);
            createBucketButton.Name = "createBucketButton";
            createBucketButton.Size = new Size(75, 23);
            createBucketButton.TabIndex = 3;
            createBucketButton.Text = "Create";
            createBucketButton.UseVisualStyleBackColor = true;
            createBucketButton.Click += CreateBucketButton_Click;
            // 
            // deleteBucketButton
            // 
            deleteBucketButton.Location = new Point(255, 6);
            deleteBucketButton.Name = "deleteBucketButton";
            deleteBucketButton.Size = new Size(75, 23);
            deleteBucketButton.TabIndex = 2;
            deleteBucketButton.Text = "Delete";
            deleteBucketButton.UseVisualStyleBackColor = true;
            deleteBucketButton.Click += DeleteBucketButton_Click;
            // 
            // bucketNameTextBox
            // 
            bucketNameTextBox.Location = new Point(8, 35);
            bucketNameTextBox.Name = "bucketNameTextBox";
            bucketNameTextBox.PlaceholderText = "Bucket name";
            bucketNameTextBox.Size = new Size(241, 23);
            bucketNameTextBox.TabIndex = 1;
            // 
            // bucketToDeleteComboBox
            // 
            bucketToDeleteComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            bucketToDeleteComboBox.FormattingEnabled = true;
            bucketToDeleteComboBox.Location = new Point(8, 6);
            bucketToDeleteComboBox.Name = "bucketToDeleteComboBox";
            bucketToDeleteComboBox.Size = new Size(241, 23);
            bucketToDeleteComboBox.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(344, 321);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            Text = "S3 demo";
            tabControl1.ResumeLayout(false);
            uploadTabPage.ResumeLayout(false);
            uploadTabPage.PerformLayout();
            filesTabPage.ResumeLayout(false);
            filesTabPage.PerformLayout();
            bucketsTabPage.ResumeLayout(false);
            bucketsTabPage.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage uploadTabPage;
        private TabPage filesTabPage;
        private ComboBox targetBucketComboBox;
        private Button selectFileButton;
        private TextBox fileTextBox;
        private Button uploadButton;
        private Button deleteButton;
        private Button downloadButton;
        private ComboBox sourceBucketComboBox;
        private ListBox objectListBox;
        private TabPage bucketsTabPage;
        private Button createBucketButton;
        private Button deleteBucketButton;
        private TextBox bucketNameTextBox;
        private ComboBox bucketToDeleteComboBox;
        private TextBox objectNameTextBox;
        private Button moveObjectButton;
        private Button renameButton;
        private TextBox newObjectNameTextBox;
        private ComboBox moveToBucketComboBox;
    }
}
