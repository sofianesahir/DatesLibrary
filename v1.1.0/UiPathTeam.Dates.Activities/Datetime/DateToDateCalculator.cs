using System;
using System.Activities;
using System.Activities.Validation;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiPathTeam.Dates.Activities.Properties;

namespace UiPathTeam.Dates.Activities.Datetime
{
    public class DateToDateCalculator : CodeActivity
    {
        [LocalizedCategory(nameof(Resources.InputDatetime))]
        [LocalizedDescription(nameof(Resources.Date1DTDescription))]
        [LocalizedDisplayName(nameof(Resources.Date1DTDisplayName))]
        public InArgument<DateTime> Date1DT { get; set; }

        [LocalizedCategory(nameof(Resources.InputDatetime))]
        [LocalizedDescription(nameof(Resources.Date2DTDescription))]
        [LocalizedDisplayName(nameof(Resources.Date2DTDisplayName))]
        public InArgument<DateTime> Date2DT { get; set; }


        [LocalizedCategory(nameof(Resources.Output))]
        public OutArgument<Dictionary<String, Int32>> Difference { get; set; }

        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);

            if (Date1DT == null && Date2DT == null)
            {
                metadata.AddValidationError(new ValidationError("The date fields are empty. Please provide at least Date 1 and Date 2 Datetime objects."));
            }


            if (Date1DT == null && Date2DT != null)
            {
                metadata.AddValidationError(new ValidationError("The Date 1 (DateTime) field is empty."));
            }
            if (Date2DT == null && Date1DT != null)
            {
                metadata.AddValidationError(new ValidationError("The Date 2 (DateTime) field is empty."));
            }
        }


        protected override void Execute(CodeActivityContext context)
        {
            DateTime DT1 = Date1DT.Get(context);
            DateTime DT2 = Date2DT.Get(context);
          
            Dictionary<String, Int32> dict = new Dictionary<string, int>();

            if (DT1 == DateTime.MinValue && DT2 == DateTime.MinValue)
            {
                throw new ArgumentNullException("Input dates", "Input dates are null or have Minimum values.");
            }
            DateTimeSpan dateSpan = DateTimeSpan.CompareDates(DT1, DT2);

            dict["Years"] = dateSpan.Years; 
            dict["Months"] = dateSpan.Months; 
            dict["Days"] = dateSpan.Days; 
            dict["Hours"] = dateSpan.Hours; 
            dict["Minutes"] = dateSpan.Minutes;
            dict["Seconds"] = dateSpan.Seconds;
            dict["Milliseconds"] = dateSpan.Milliseconds;

            Difference.Set(context, dict);
        }
    }
}
