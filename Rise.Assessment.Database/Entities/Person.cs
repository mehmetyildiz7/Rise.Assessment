using Rise.Assessment.Database.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rise.Assessment.Database.Entities
{
    public class Person : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
        public List<ContactInfo> ContactInfo { get; set; }
    }
}
