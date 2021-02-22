using AutoMapper;
using Rise.Assessment.Business.Services.Base;
using Rise.Assessment.Common.Models;
using Rise.Assessment.Database.Entities;
using Rise.Assessment.Database.Repositories;
using System;
using System.Threading.Tasks;

namespace Rise.Assessment.Business.Services
{
    public class PersonService : BaseService<Person>
    {
        public PersonService(PersonRepository personRepository, IMapper mapper) : base(personRepository, mapper)
        {

        }

        public async Task<Person> AddContactInfo(ContactInfoModel contactModel, Guid id)
        {
            var contactEntity = _mapper.Map<ContactInfo>(contactModel);
            var personEntity = await Repository.Get(id);
            personEntity.ContactInfo.Add(contactEntity);

            var result = await Repository.UpdateAsync(personEntity);
            return result;
        }

        public async Task<Person> RemoveContactInfo(Guid id, Guid contactId)
        {
            var personEntity = await Repository.Get(id);
            var contactEntity = personEntity.ContactInfo.Find(x => x.Id == contactId);
            personEntity.ContactInfo.Remove(contactEntity);

            var result = await Repository.UpdateAsync(personEntity);
            return result;
        }
    }
}
