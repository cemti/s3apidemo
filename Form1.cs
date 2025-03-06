using System.ComponentModel;

namespace S3ApiDemo;

public partial class Form1 : Form
{
    private readonly BindingList<string> _buckets = [], _currentObjects = [];

    private static void PopulateList<T>(BindingList<T> list, IEnumerable<T> contents)
    {
        list.Clear();

        foreach (var content in contents)
        {
            list.Add(content);
        }
    }

    public Form1()
    {
        InitializeComponent();

        void PrepareComboBox(ComboBox comboBox)
        {
            comboBox.DataSource = new BindingSource(_buckets, null!);
        }

        PrepareComboBox(sourceBucketComboBox);
        PrepareComboBox(targetBucketComboBox);
        PrepareComboBox(bucketToDeleteComboBox);
        PrepareComboBox(moveToBucketComboBox);

        objectListBox.DataSource = new BindingSource(_currentObjects, null!);
    }    

    protected override async void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        InitializeClient();
        PopulateList(_buckets, await QueryBuckets());
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

    private async void UploadButton_Click(object sender, EventArgs e)
    {
        if (await AddObject(objectNameTextBox.Text, targetBucketComboBox.Text, fileTextBox.Text))
        {
            _currentObjects.Add(objectNameTextBox.Text);
            return;
        }

        MessageBox.Show($"Error adding '{objectNameTextBox.Text}' to bucket '{targetBucketComboBox.Text}'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    private async void CreateBucketButton_Click(object sender, EventArgs e)
    {
        if (await AddBucket(bucketNameTextBox.Text))
        {
            _buckets.Add(bucketNameTextBox.Text);
            return;
        }

        MessageBox.Show($"Error adding bucket '{bucketNameTextBox.Text}'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    private async void DeleteBucketButton_Click(object sender, EventArgs e)
    {
        if (await DeleteBucket(bucketToDeleteComboBox.Text))
        {
            _buckets.RemoveAt(bucketToDeleteComboBox.SelectedIndex);
            return;
        }

        MessageBox.Show($"Error deleting bucket '{bucketToDeleteComboBox.Text}'. Make sure it's empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    private async void SourceBucketComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        PopulateList(_currentObjects, await QueryObjects(sourceBucketComboBox.Text));
    }

    private async void DownloadButton_Click(object sender, EventArgs e)
    {
        if (objectListBox.SelectedValue is string selectedObject)
        {
            using SaveFileDialog dialog = new();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                await DownloadObject(selectedObject, sourceBucketComboBox.Text, dialog.FileName);
            }
        }
    }

    private async void DeleteButton_Click(object sender, EventArgs e)
    {
        if (objectListBox is { SelectedValue: string selectedObject, SelectedIndex: var selectedIndex }
            && await DeleteObject(selectedObject, sourceBucketComboBox.Text))
        {
            _currentObjects.RemoveAt(selectedIndex);
        }
    }

    private async void RenameButton_Click(object sender, EventArgs e)
    {
        if (objectListBox is { SelectedValue: string selectedObject, SelectedIndex: var selectedIndex })
        {
            if (await RenameObject(selectedObject, newObjectNameTextBox.Text, sourceBucketComboBox.Text))
            {
                _currentObjects[selectedIndex] = newObjectNameTextBox.Text;
                return;
            }

            MessageBox.Show($"Error adding '{newObjectNameTextBox.Text}' to bucket '{sourceBucketComboBox.Text}'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void MoveObjectButton_Click(object sender, EventArgs e)
    {
        if (objectListBox is { SelectedValue: string selectedObject, SelectedIndex: var selectedIndex }
            && await MoveObject(selectedObject, sourceBucketComboBox.Text, moveToBucketComboBox.Text)
            && sourceBucketComboBox.Text != moveToBucketComboBox.Text)
        {
            _currentObjects.RemoveAt(selectedIndex);
        }
    }
}
