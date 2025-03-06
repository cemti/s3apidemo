using System.Diagnostics;

namespace s3apidemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitializeClient();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            FinalizeClient();
        }

        private void SelectFileButton_Click(object sender, EventArgs e)
        {
            using OpenFileDialog dialog = new();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                fileTextBox.Text = dialog.FileName;
            }
        }

        private void UploadButton_Click(object sender, EventArgs e)
        {
            Debug.WriteLine($"Upload file `{fileTextBox.Text}` to bucket `{targetBucketComboBox.Text}` as object `{objectNameTextBox.Text}`.");
            AddObject(objectNameTextBox.Text, targetBucketComboBox.Text, fileTextBox.Text);
        }

        private void CreateBucketButton_Click(object sender, EventArgs e)
        {
            Debug.WriteLine($"Create bucket `{bucketNameTextBox.Text}`.");
            AddBucket(bucketNameTextBox.Text);
        }

        private void DeleteBucketButton_Click(object sender, EventArgs e)
        {
            Debug.WriteLine($"Delete bucket `{bucketToDeleteComboBox.Text}`.");
            DeleteBucket(bucketToDeleteComboBox.Text);
        }

        private void SourceBucketComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Debug.WriteLine($"Query objects from bucket `{sourceBucketComboBox.Text}`.");
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            if (objectListBox.SelectedValue is string selectedValue)
            {
                using SaveFileDialog dialog = new();

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Debug.WriteLine("Save the selected object content.");
                    DownloadObject(selectedValue, sourceBucketComboBox.Text, dialog.FileName);
                }
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (objectListBox.SelectedValue is string selectedValue)
            {
                Debug.WriteLine("Delete the selected object.");
                DeleteObject(selectedValue, sourceBucketComboBox.Text);
            }
        }

        private void RenameButton_Click(object sender, EventArgs e)
        {
            if (objectListBox.SelectedValue is string selectedValue)
            {
                Debug.WriteLine($"Rename the selected object to `{newObjectNameTextBox.Text}`.");
                RenameObject(selectedValue, newObjectNameTextBox.Text, sourceBucketComboBox.Text);
            }
        }

        private void MoveObjectButton_Click(object sender, EventArgs e)
        {
            if (objectListBox.SelectedValue is string selectedValue)
            {                
                Debug.WriteLine($"Move the selected object from `{sourceBucketComboBox.Text}` to `{moveToBucketComboBox.Text}`.");
                MoveObject(selectedValue, sourceBucketComboBox.Text, moveToBucketComboBox.Text);
            }
        }
    }
}
