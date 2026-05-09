using System;

namespace question3_AgeCalculator.Models
{
    public class AgeViewModel
    {
        public DateTime? DateOfBirth { get; set; }

        // Computed results
        public int Years { get; set; }
        public int Months { get; set; }
        public int Weeks { get; set; }
        public int Days { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }

        public string? Error { get; set; }
    }
}