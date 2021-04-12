using System;
using System.Collections.Generic;

namespace SingleStone.Models
{
   
        public class Contact : IEntity { 
            public Int64 Id { get; set; }
            public string First { get; set; }

            public string Middle { get; set; }

            public string Last { get; set; }

            //For purposes of the assignment a contact is going to have 1 address, but in the future we may want 
            // additional addresses, such as a vacation home
            public Address Addresses { get; set; }

            public List<Phone>  Phones { get; set; }

            public string Email { get; set; }
        }
        
}
