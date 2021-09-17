using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Company.Function
{
    public static class MyQueueTrigger
    {
        [FunctionName("MyQueueTrigger")]
        public static void Run(
            [QueueTrigger("myqueue", Connection = "AzureWebJobsStorage")]string myQueueItem,
            [Queue("myqueue-out", Connection = "AzureWebJobsStorage")] out string myQueueItemCopy, 
            ILogger log)            
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
            myQueueItemCopy = myQueueItem;
        }
    }
}
