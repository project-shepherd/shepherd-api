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
    public static class GetCommitments
    {
        [FunctionName("GetCommitments")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "commitments")] HttpRequest req,
            [Inject] IRepository repository,
            ILogger log)
        {
            log.LogInformation("Getting all Commitments");

            return new OkObjectResult(await repository.GetCommitments());
        }
    }
}