using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Willezone.Azure.WebJobs.Extensions.DependencyInjection;

using FunctionApp.DataContracts;
using FunctionApp.DataAccess;
using FunctionApp.Models;

namespace FunctionApp.Functions
{
    public static class GetCommitmentsByTopicId
    {
        [FunctionName("GetCommitmentsByTopicId")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "topics/{id}/commitments")] HttpRequest req,
            string id,
            [Inject] IRepository repository,
            ILogger log)
        {
            log.LogInformation($"Getting all Commitments for Topic: {id}");

            return new OkObjectResult(await repository.GetCommitmentsByTopicId(id));
        }
    }
}