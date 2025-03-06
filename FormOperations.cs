using Microsoft.VisualBasic;
using Amazon;
using Amazon.Runtime;
using Amazon.S3;

namespace S3ApiDemo;

partial class Form1
{
    private AmazonS3Client _client = null!;

    private void InitializeClient()
    {
        var accessKey = Interaction.InputBox("Access key", "AWS IAM");
        var secretKey = Interaction.InputBox("Secret access key", "AWS IAM");
        _client = new(new BasicAWSCredentials(accessKey, secretKey), RegionEndpoint.USEast1);
    }

    private void FinalizeClient()
    {
        _client.Dispose();
    }

    private async Task<IEnumerable<string>> QueryBuckets()
    {
        var buckets = await _client.ListBucketsAsync();
        return buckets.Buckets.Select(x => x.BucketName);
    }

    private async Task<IEnumerable<string>> QueryObjects(string bucketName)
    {
        if (bucketName is null or "")
        {
            return [];
        }

        var objects = await _client.ListObjectsAsync(bucketName);
        return objects.S3Objects.Select(x => x.Key);
    }

    private async Task AddObject(string objectName, string bucketName, string filePath)
    {
        _ = await _client.PutObjectAsync(new()
        {
            BucketName = bucketName,
            Key = objectName,
            FilePath = filePath
        });
    }

    private async Task RenameObject(string oldObjectName, string newObjectName, string bucketName)
    {
        _ = await _client.CopyObjectAsync(bucketName, oldObjectName, bucketName, newObjectName);
        _ = await _client.DeleteObjectAsync(bucketName, oldObjectName);
    }

    private async Task DownloadObject(string objectName, string bucketName, string filePath)
    {
        var response = await _client.GetObjectAsync(bucketName, objectName);
        await response.WriteResponseStreamToFileAsync(filePath, false, CancellationToken.None);
    }

    private async Task DeleteObject(string objectName, string bucketName)
    {
        _ = await _client.DeleteObjectAsync(bucketName, objectName);
    }

    private async Task MoveObject(string objectName, string sourceBucketName, string destinationBucketName)
    {
        _ = await _client.CopyObjectAsync(sourceBucketName, objectName, destinationBucketName, objectName);
        _ = await _client.DeleteObjectAsync(sourceBucketName, objectName);
    }

    private async Task CopyObject(string objectName, string sourceBucketName, string destinationBucketName)
    {
        _ = await _client.CopyObjectAsync(sourceBucketName, objectName, destinationBucketName, objectName);
    }

    private async Task AddBucket(string bucketName)
    {
        _ = await _client.PutBucketAsync(bucketName);
    }

    private async Task DeleteBucket(string bucketName)
    {
        _ = await _client.DeleteBucketAsync(bucketName);
    }
}
