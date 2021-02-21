using Rise.Assessment.Database.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rise.Assessment.Database.Entities
{
    public enum ContactType
    {
        PhoneNumber,
        Email,
        Location
    }

    public class ContactInfo : BaseEntity
    {
        public string Content { get; set; }
        public ContactType Type { get; set; }
    }
}
