using System;

namespace eShiftApp.Models
{
    public class Job
    {
        public int JobID { get; set; }
        public int CustomerID { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public DateTime JobDate { get; set; }
        public string Status { get; set; }  // e.g., Pending, Accepted, Declined

        public string Description { get; set; }
    }
}
