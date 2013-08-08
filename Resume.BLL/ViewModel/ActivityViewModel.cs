using Resume.Core.Models;
using System.Globalization;

namespace Resume.Infrastructure.ViewModel
{
    public class ActivityViewModel
    {
        public Activity Activity { get; set; }
        public string FormattedStartDate { 
            get {
                return Activity.Start.ToString("dd MMM, yyyy", CultureInfo.InvariantCulture);
            } 
        }
        public string FormattedEndDate { 
            get {
                return Activity.End.ToString("dd MMM, yyyy", CultureInfo.InvariantCulture);
            } 
        }
    }
}