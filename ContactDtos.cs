using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SingleStone.Models;

namespace SingleStone.Dtos
{
    public class ContactDtos
    {
        public record ContactDto(Int64 id, string first, string middle, string last, Address address, List<Phone> phone, string email);
        
        public record CreateContactDto([Required] string first, string middle, [Required] string last, Address address, [Required] Phone phone, string email);

        public record UpdateContactDto([Required] string first, string middle, [Required] string last, Address address, [Required] Phone phone, string email);
    }
}
