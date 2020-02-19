using System;
using System.Activities;
using System.Activities.Validation;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiPathTeam.Dates.Activities.Properties;

namespace UiPathTeam.Dates.Activities.Datetime
{
    public class CompareDates : CodeActivity
    {
        
        [LocalizedCategory(nameof(Resources.InputDatetime))]
        [LocalizedDescription(nameof(Resources.Date1DTDescription))]
        [LocalizedDisplayName(nameof(Resources.Date1DTDisplayName))]
        public InArgument<DateTime> Date1DT { get; set; }

        [LocalizedCategory(nameof(Resources.InputDatetime))]
        [LocalizedDescription(nameof(Resources.Date2DTDescription))]
        [LocalizedDisplayName(nameof(Resources.Date2DTDisplayName))]
        public InArgument<DateTime> Date2DT { get; set; }


        [LocalizedCategory(nameof(Resources.Options))]
        public Boolean CheckDay { get; set; }
        [LocalizedCategory(nameof(Resources.Options))]
        public Boolean CheckMonth { get; set; }
        [LocalizedCategory(nameof(Resources.Options))]
        public Boolean CheckYear { get; set; }

        [LocalizedCategory(nameof(Resources.Options))]
        public Boolean CheckHours { get; set; }
        [LocalizedCategory(nameof(Resources.Options))]
        public Boolean CheckMinutes { get; set; }
        [LocalizedCategory(nameof(Resources.Options))]
        public Boolean CheckSecondes{ get; set; }


        [LocalizedCategory(nameof(Resources.Output))]
        public TimeBins OutputDateDifferenceUnits { get; set; }

        [LocalizedCategory(nameof(Resources.Output))]
        public OutArgument<Boolean> Result { get; set; }

        [LocalizedCategory(nameof(Resources.Output))]
        public OutArgument<Double> DateDifference { get; set; }


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
            Boolean result = true;
            DateTime DT1 = Date1DT.Get(context);
            DateTime DT2 = Date2DT.Get(context);


            if (DT1 == DateTime.MinValue && DT2 == DateTime.MinValue)
            {
                throw new ArgumentNullException("Input dates", "Input dates are null or have Minimum values.");
            }

            TimeSpan dt = DT2 - DT1;
            
            if (CheckDay)
                result &= DT1.Day == DT2.Day;
            if (CheckMonth)
                result &= DT1.Month == DT2.Month;
            if (CheckYear)
                result &= DT1.Year == DT2.Year;
            if (CheckHours)
                result &= ((dt.TotalHours < 1) || ((dt.TotalHours > 1) && (dt.TotalHours % 24 == 0)));
            if (CheckMinutes)
                result &= ((dt.TotalMinutes < 1) || ((dt.TotalMinutes > 1) && (dt.TotalMinutes % 60 == 0)));
            if (CheckSecondes)
                result &= ((dt.TotalMilliseconds % 60000) == 0);

            Result.Set(context, result);
            switch (OutputDateDifferenceUnits)
            {
                case TimeBins.Milliseconds:
                    DateDifference.Set(context, dt.TotalMilliseconds);
                    break;
                case TimeBins.Seconds:
                    DateDifference.Set(context, dt.TotalSeconds);
                    break;
                case TimeBins.Minutes:
                    DateDifference.Set(context, dt.TotalMinutes);
                    break;
                case TimeBins.Hours:
                    DateDifference.Set(context, dt.TotalHours);
                    break;
                case TimeBins.Days:
                    DateDifference.Set(context, dt.TotalDays );
                    break;
                default:
                    DateDifference.Set(context, dt.TotalMilliseconds);
                    break;
            }
        }
    }
}
