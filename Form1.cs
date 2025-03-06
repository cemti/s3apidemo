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

    private static async void TryExecute(Func<Task> action)
    {
        try
        {
            await action();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        var source = (BindingSource)sourceBucketComboBox.DataSource!;

        source.CurrentItemChanged +=
            (_, _) => TryExecute(async () => PopulateList(_currentObjects, await QueryObjects((string)source.Current!)));
    }    

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        InitializeClient();
        TryExecute(async () => PopulateList(_buckets, await QueryBuckets()));
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
        TryExecute(async () =>
        {
            await AddObject(objectNameTextBox.Text, targetBucketComboBox.Text, fileTextBox.Text);
            _currentObjects.Add(objectNameTextBox.Text);
        });
    }

    private void CreateBucketButton_Click(object sender, EventArgs e)
    {
        TryExecute(async () =>
        {
            await AddBucket(bucketNameTextBox.Text);
            _buckets.Add(bucketNameTextBox.Text);
        });
    }

    private void DeleteBucketButton_Click(object sender, EventArgs e)
    {
        TryExecute(async () =>
        {
            await DeleteBucket(bucketToDeleteComboBox.Text);
            _buckets.RemoveAt(bucketToDeleteComboBox.SelectedIndex);
        });
    }

    private void DownloadButton_Click(object sender, EventArgs e)
    {
        if (objectListBox.SelectedValue is string selectedObject)
        {
            using SaveFileDialog dialog = new();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                TryExecute(async () => await DownloadObject(selectedObject, sourceBucketComboBox.Text, dialog.FileName));
            }
        }
    }

    private void DeleteButton_Click(object sender, EventArgs e)
    {
        if (objectListBox is { SelectedValue: string selectedObject, SelectedIndex: var selectedIndex })
        {
            TryExecute(async () =>
            {
                await DeleteObject(selectedObject, sourceBucketComboBox.Text);
                _currentObjects.RemoveAt(selectedIndex);
            });
        }
    }

    private void RenameButton_Click(object sender, EventArgs e)
    {
        if (objectListBox is { SelectedValue: string selectedObject, SelectedIndex: var selectedIndex })
        {
            TryExecute(async () =>
            {
                await RenameObject(selectedObject, newObjectNameTextBox.Text, sourceBucketComboBox.Text);
                _currentObjects[selectedIndex] = newObjectNameTextBox.Text;
            });
        }
    }

    private void MoveObjectButton_Click(object sender, EventArgs e)
    {
        if (objectListBox is { SelectedValue: string selectedObject, SelectedIndex: var selectedIndex })
        {
            TryExecute(async () =>
            {
                await MoveObject(selectedObject, sourceBucketComboBox.Text, moveToBucketComboBox.Text);

                if (sourceBucketComboBox.Text != moveToBucketComboBox.Text)
                {
                    _currentObjects.RemoveAt(selectedIndex);
                }
            });
        }
    }

    private void CopyObjectButton_Click(object sender, EventArgs e)
    {
        if (objectListBox is { SelectedValue: string selectedObject, SelectedIndex: var selectedIndex })
        {
            TryExecute(async () => await CopyObject(selectedObject, sourceBucketComboBox.Text, moveToBucketComboBox.Text));
        }
    }
}
