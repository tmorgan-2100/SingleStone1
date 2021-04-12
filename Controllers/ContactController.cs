using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SingleStone.Models;
using static SingleStone.Dtos.ContactDtos;


namespace SingleStone.Controllers
{
    [Route("api/contacts")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IRepository<Contact> contactsRepository;

        public ContactController(IRepository<Contact> contactsRepository)
        {
            this.contactsRepository = contactsRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<ContactDto>> GetAsync()
        {
            var contacts = (await contactsRepository.Get<Contact>()).Select(contact => contact.AsDto());
            return contacts;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ContactDto>> GetByIdAsync(Int64 id)
        {
            var contact = await contactsRepository.Get<Contact>(x => x.Id == id);
            if (contact == null)
            {
                return NotFound();
            }
            return contact.FirstOrDefault().AsDto();
        }

        [HttpPost]
        public async Task<ActionResult<ContactDto>> PostAsync(CreateContactDto createContactDto)
        {
            var contact = new Contact
            {
             First = createContactDto.first,
             Middle = createContactDto.middle,
             Last = createContactDto.last,
             Addresses = createContactDto.address,
             Phones = new List<Phone> { createContactDto.phone },
             Email = createContactDto.email
            };

            await contactsRepository.Insert(contact);
            return CreatedAtAction(nameof(GetByIdAsync), new
            {
                id = contact.Id
            }, contact);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Int64 id, UpdateContactDto updateContactDto)
        {
            var existingContact = await contactsRepository.Get<Contact>(x => x.Id == id);
            if (existingContact == null)
            {
                return NotFound();
            }
            //existingContact.First = updateContactDto.first;
            //existingContact.Middle = updateContactDto.middle;
            //existingContact.Last = updateContactDto.last;
            //existingContact.Addresses = updateContactDto.address;

            //if (!existingContact.Phones.Any(x => x.Number == updateContactDto.phone.Number))
            //{
            //    existingContact.Phones.Add(updateContactDto.phone);
            //}
            //else
            //{
            //    var updateNumber = existingContact.Phones.FirstOrDefault(x => x.Number == updateContactDto.phone.Number);
            //    if (updateNumber != null) updateNumber.Type = updateContactDto.phone.Type;
            //}

            //await contactsRepository.UpdateAsync(existingContact);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Int64 id)
        {
            //var contact = await contactsRepository.GetAsync(id);
            //if (contact == null)
            //{
            //    return NotFound();
            //}
            //await contactsRepository.RemoveAsync(contact.Id);
            return NoContent();
        }
    }
}
