using SingleStone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SingleStone.Dtos.ContactDtos;

namespace SingleStone
{
    public static class Extensions
    {
        public static ContactDto AsDto(this Contact contact)
        {
            return new ContactDto(contact.Id, contact.First, contact.Middle, contact.Last, contact.Addresses , contact.Phones, contact.Email);
        }
    }
}
