using AutoMapper;
using Rise.Assessment.Common.Models;
using Rise.Assessment.Database.Entities;

namespace Rise.Assessment.Api.MapperConfigurations
{
    public class ContactInfoMapProfile : Profile
    {
        public ContactInfoMapProfile()
        {
            CreateMap<ContactInfoModel, ContactInfo>();
        }
    }
}
