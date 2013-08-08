using System;
using System.Collections.Generic;

namespace Resume.Core.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public string ActivityName { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public ActivityType ActivityType { get; set; }
    }
}