using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Resume.Models
{
    public class Cv
    {
        public int Id { get; set; }
        public string Activity { get; set; }
        public string Description { get; set; }
        [ScriptIgnore]
        public DateTime Start { get; set; }
        [ScriptIgnore]
        public DateTime End { get; set; }
        public string flag { get; set; }
    }
}