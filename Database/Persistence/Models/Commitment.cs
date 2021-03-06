using System;

namespace FunctionApp.Persistence.Models
{
    public class Commitment : DbModelBase
    {
        public DateTime Date { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }

        public Guid TypeId { get; set; }

        public CommitmentType Type { get; set; }

        public Guid TopicId { get; set; }

        public Topic Topic { get; set; }
    }
}