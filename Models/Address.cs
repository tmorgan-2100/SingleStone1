using System;

namespace SingleStone.Models
{
    public class Address : IEntity
    {

        public Int64 Id { get; set; }

        public Int64 ContactId { get; set; }

        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public Contact Contact { get; set; }
    }
}
