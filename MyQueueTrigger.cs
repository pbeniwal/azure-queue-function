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
/*

in portal below needs to be written in trigger run.csx

-------------------------------------------------------------------------

using System;

public static void Run(string myQueueItem, ICollector<string> outputQueueItem, ILogger log)
{
    outputQueueItem.Add(myQueueItem);
    log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
}
------------------------------------------------------------------------------

function.json has below content
-----------------------------------------------------------------------------
{
  "bindings": [
    {
      "name": "myQueueItem",
      "queueName": "myqueue-out",
      "connection": "AzureWebJobsStorage",
      "direction": "in",
      "type": "queueTrigger"
    },
    {
      "name": "outputQueueItem",
      "direction": "out",
      "type": "queue",
      "connection": "AzureWebJobsStorage",
      "queueName": "myqueue"
    }
  ]
}
----------------------------------------------------------------------------

*/
