namespace FunctionApp.Contracts
{
    public class CreateTopicRequest
    {
        public string Title { get; set; }

        public string SuccessCriteria { get; set; }

        public string PersonId { get; set; }
    }
}