using System.ComponentModel;

namespace s3apidemo
{
    partial class Form1
    {
        private readonly BindingList<KeyValuePair<string, BindingList<string>>> _buckets =
        [
            new("sample1", ["s1-object1"]),
            new("sample2", ["s2-object1"])
        ];

        private void InitializeClient()
        {
            void PrepareComboBox(ComboBox comboBox)
            {
                comboBox.DataSource = new BindingSource(_buckets, null!);
                comboBox.DisplayMember = "Key";
            }

            PrepareComboBox(sourceBucketComboBox);
            PrepareComboBox(targetBucketComboBox);
            PrepareComboBox(bucketToDeleteComboBox);
            PrepareComboBox(moveToBucketComboBox);

            objectListBox.DataSource = new BindingSource(sourceBucketComboBox.DataSource, "Value");
        }

        private void FinalizeClient()
        { 
        }

        private IList<string> GetBucket(string bucketName)
        {
            return _buckets.First(x => x.Key == bucketName).Value;
        }

        private void AddObject(string objectName, string bucketName, string filePath)
        {
            var bucket = GetBucket(bucketName);

            if (bucket.Contains(bucketName))
            {
                MessageBox.Show($"Object '{objectName}' already exists in bucket '{bucketName}'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bucket.Add(objectName);
        }

        private void RenameObject(string oldObjectName, string newObjectName, string bucketName)
        {
            var bucket = GetBucket(bucketName);

            if (bucket.Contains(newObjectName))
            {
                MessageBox.Show($"Object '{newObjectName}' already exists in bucket '{bucketName}'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (bucket.IndexOf(oldObjectName) is not -1 and var index)
            {
                bucket[index] = newObjectName;
            }
        }

        private void DownloadObject(string objectName, string bucketname, string filePath)
        {

        }
        
        private void DeleteObject(string objectName, string bucketName)
        {
            GetBucket(bucketName).Remove(objectName);
        }

        private void MoveObject(string objectName, string sourceBucketName, string destinationBucketName)
        {
            if (GetBucket(destinationBucketName).Contains(objectName))
            {
                MessageBox.Show($"Object '{objectName}' already exists in '{destinationBucketName}'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            DeleteObject(objectName, sourceBucketName);
            AddObject(objectName, destinationBucketName, "");
        }

        private void AddBucket(string bucketName)
        {
            if (_buckets.Any(x => x.Key == bucketName))
            {
                MessageBox.Show($"Bucket '{bucketName}' already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _buckets.Add(new(bucketName, []));
        }

        private void DeleteBucket(string bucketName)
        {
            if (_buckets.Index().FirstOrDefault(x => x.Item.Key == bucketName) is { Index: var index, Item: ({ }, { }) })
            {
                _buckets.RemoveAt(index);
            }
        }
    }
}
