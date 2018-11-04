using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Willezone.Azure.WebJobs.Extensions.DependencyInjection;

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