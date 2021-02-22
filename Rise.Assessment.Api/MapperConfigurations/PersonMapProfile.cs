using AutoMapper;
using Rise.Assessment.Common.Models;
using Rise.Assessment.Database.Entities;

namespace Rise.Assessment.Common.MapperConfigurations
{
    public class PersonMapProfile : Profile
    {
        public PersonMapProfile()
        {
            CreateMap<PersonModel, Person>();
        }
    }
}
