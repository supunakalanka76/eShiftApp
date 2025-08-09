using System;

namespace eShiftApp.Models
{
    public class Load
    {
        public int LoadID { get; set; }
        public int JobID { get; set; }
        public string Description { get; set; }
        public double Weight { get; set; }
        public int TransportID { get; set; }
    }
}
