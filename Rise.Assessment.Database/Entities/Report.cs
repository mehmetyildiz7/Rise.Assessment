using System;
using System.Collections.Generic;
using System.Text;

namespace Rise.Assessment.Database.Entities
{
    public enum ReportStatus
    {
        InProgress,
        Completed
    }

    public class Report
    {
        public string Location { get; set; }
        public int RegisteredPersonCount { get; set; }
        public int RegisteredPhoneNumberCount { get; set; }
    }
}
