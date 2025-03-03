using System.Diagnostics;

namespace s3apidemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
        }

        private void CreateBucketButton_Click(object sender, EventArgs e)
        {
            Debug.WriteLine($"Create bucket `{bucketNameTextBox.Text}`.");
        }

        private void DeleteBucketButton_Click(object sender, EventArgs e)
        {
            Debug.WriteLine($"Delete bucket `{bucketToDeleteComboBox.Text}`.");
        }

        private void SourceBucketComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Debug.WriteLine($"Query objects from bucket `{sourceBucketComboBox.Text}`.");
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            if (objectListBox.SelectedIndex != -1)
            {
                using SaveFileDialog dialog = new();

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Debug.WriteLine("Save the selected object content.");
                }
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (objectListBox.SelectedIndex != -1)
            {
                Debug.WriteLine("Delete the selected object.");
            }
        }

        private void RenameButton_Click(object sender, EventArgs e)
        {
            if (objectListBox.SelectedIndex != -1)
            {
                Debug.WriteLine($"Rename the selected object to `{newObjectNameTextBox.Text}`.");
            }
        }

        private void MoveObjectButton_Click(object sender, EventArgs e)
        {
            if (objectListBox.SelectedIndex != -1)
            {
                Debug.WriteLine($"Move the selected object from `{sourceBucketComboBox.Text}` to `{moveToBucketComboBox.Text}`.");
            }
        }
    }
}
