using Microsoft.VisualBasic;
using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using System.Net;

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
        if (bucketName == "")
        {
            return [];
        }

        var objects = await _client.ListObjectsAsync(bucketName);
        return objects.S3Objects.Select(x => x.Key);
    }

    private async Task<bool> AddObject(string objectName, string bucketName, string filePath)
    {
        var response = await _client.PutObjectAsync(new()
        {
            BucketName = bucketName,
            Key = objectName,
            FilePath = filePath
        });

        return response.HttpStatusCode == HttpStatusCode.OK;
    }

    private async Task<bool> RenameObject(string oldObjectName, string newObjectName, string bucketName)
    {
        var response = await _client.CopyObjectAsync(bucketName, oldObjectName, bucketName, newObjectName);

        if (response.HttpStatusCode != HttpStatusCode.OK)
        {
            return false;
        }

        _ = await _client.DeleteObjectAsync(bucketName, oldObjectName);
        return true;
    }

    private async Task DownloadObject(string objectName, string bucketName, string filePath)
    {
        var response = await _client.GetObjectAsync(bucketName, objectName);
        await response.WriteResponseStreamToFileAsync(filePath, false, CancellationToken.None);
    }

    private async Task<bool> DeleteObject(string objectName, string bucketName)
    {
        _ = await _client.DeleteObjectAsync(bucketName, objectName);
        return true;
    }

    private async Task<bool> MoveObject(string objectName, string sourceBucketName, string destinationBucketName)
    {
        var response = await _client.CopyObjectAsync(sourceBucketName, objectName, destinationBucketName, objectName);

        if (response.HttpStatusCode != HttpStatusCode.OK)
        {
            return false;
        }

        _ = await _client.DeleteObjectAsync(sourceBucketName, objectName);
        return true;
    }

    private async Task<bool> AddBucket(string bucketName)
    {
        var response = await _client.PutBucketAsync(bucketName);
        return response.HttpStatusCode == HttpStatusCode.OK;
    }

    private async Task<bool> DeleteBucket(string bucketName)
    {
        _ = await _client.DeleteBucketAsync(bucketName);
        return true;
    }
}
