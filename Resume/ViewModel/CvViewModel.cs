using Resume.Core.Models;
using System.Globalization;

namespace Resume.Web.ViewModel
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