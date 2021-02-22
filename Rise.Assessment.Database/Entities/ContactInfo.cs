﻿using Rise.Assessment.Common.Enums;
using Rise.Assessment.Database.Entities.Base;

namespace Rise.Assessment.Database.Entities
{

    public class ContactInfo : BaseEntity
    {
        public string Content { get; set; }
        public ContactType Type { get; set; }
    }
}
