using System;

namespace Resume.Core.Models
{
    public class Cv
    {
        public int Id { get; set; }
        public string Activity { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Flag { get; set; }
    }
}