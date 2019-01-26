using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Willezone.Azure.WebJobs.Extensions.DependencyInjection;

using FunctionApp.DataContracts;
using System.Collections.Generic;
using FunctionApp.Models;
using System.Linq;

namespace FunctionApp.Functions
{
    public static class GetTopics
    {
        [FunctionName("GetTopics")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "topics")] HttpRequest req,
            // [Inject] IGraphClient graphClient,
            ILogger log)
        {
            log.LogInformation("Getting all Topics.");

            IEnumerable<Topic> topics = new List<Topic>().AsEnumerable();

            return new OkObjectResult(topics);
        }
    }
}