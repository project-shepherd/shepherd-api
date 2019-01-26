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
using System.Linq;
using FunctionApp.Models;

namespace FunctionApp.Functions
{
    public static class GetPersonById
    {
        [FunctionName("GetPersonById")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "people/{id}")] HttpRequest req,
            string id,
            // [Inject] IGraphClient graphClient,
            ILogger log)
        {
            log.LogInformation($"Getting Person by ID: {id}");

            User user = new User();

            return new OkObjectResult(user);
        }
    }
}
