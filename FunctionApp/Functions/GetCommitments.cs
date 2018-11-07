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
using FunctionApp.DataAccess.GraphSchema;
using System.Collections.Generic;

namespace FunctionApp.Functions
{
    public static class GetCommitments
    {
        [FunctionName("GetCommitments")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "commitments")] HttpRequest req,
            [Inject] IGraphClient graphClient,
            ILogger log)
        {
            log.LogInformation("Getting all Commitments");

            var g = graphClient.CreateTraversalSource();
            var query = g.V<CommitmentEdge>();

            log.LogInformation($"Query: {query.ToGremlinQuery()}");

            IEnumerable<TopicVertex> topicResults = await graphClient.QueryAsync<TopicVertex>(query);

            return new OkObjectResult(topicResults);
        }
    }
}