using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using System;
using System.IO;
using System.Threading.Tasks;

namespace OODProjectServer.Helpers
{
    public class S3Helper
    {
        public S3Helper()
        {
        }

        private const string bucketName = "oodprojectapp";
        // Example creates two objects (for simplicity, we upload same file twice).
        // You specify key names for these objects.
        private static readonly RegionEndpoint bucketRegion = RegionEndpoint.USWest1;

        private static IAmazonS3 client;

        public void Main()
        {
            client = new AmazonS3Client(bucketRegion);
        }

        public async Task WritingAnObjectAsync(string key, string value)
        {
            try
            {
                // 1. Put object-specify only key name for the new object.
                var putRequest1 = new PutObjectRequest
                {
                    BucketName = bucketName,
                    Key = key,
                    ContentBody = value
                };

                PutObjectResponse response1 = await client.PutObjectAsync(putRequest1);
            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine(
                        "Error encountered ***. Message:'{0}' when writing an object"
                        , e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(
                    "Unknown encountered on server. Message:'{0}' when writing an object"
                    , e.Message);
            }
        }
    }
}
