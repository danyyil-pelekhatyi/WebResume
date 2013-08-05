using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Resume.Models;
using System.Globalization;

namespace Resume.ViewModel
{
    public class CvViewModel
    {
        public Cv Cv { get; set; }
        public string FormattedStartDate { 
            get {
                return Cv.Start.ToString("dd MMM, yyyy", CultureInfo.InvariantCulture);
            } 
        }
        public string FormattedEndDate { 
            get {
                return Cv.End.ToString("dd MMM, yyyy", CultureInfo.InvariantCulture);
            } 
        }
    }
}