using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Gremlin.Net.CosmosDb;
using Willezone.Azure.WebJobs.Extensions.DependencyInjection;

using FunctionApp.DataContracts;
using FunctionApp.DataAccess;
using FunctionApp.Models;
using FunctionApp.DataAccess.GraphSchema;

namespace FunctionApp.Functions
{
    public static class GetTopicById
    {
        [FunctionName("GetTopicById")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "topics/{id}")] HttpRequest req,
            string id,
            [Inject] IRepository repository,
            ILogger log)
        {
            log.LogInformation($"Getting Topic by ID: {id}");

            try
            {
                Topic topic = await repository.GetTopicById(id);

                return new OkObjectResult(topic);
            }
            catch (ObjectNotFoundException e)
            {
                return new NotFoundResult();
            }
        }
    }
}