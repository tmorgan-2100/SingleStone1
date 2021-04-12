using System;

namespace SingleStone.Models
{
    public class Phone : IEntity
    {

        public Int64 Id { get; set; }

        public Int64 ContactId { get; set; }

        public string Number { get; set; }

        public string Type { get; set; }

        public Contact Contact { get; set; }
    }
}
