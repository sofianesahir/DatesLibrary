using System;
using System.Activities;
using System.Activities.Validation;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiPathTeam.Dates.Activities.Properties;

namespace UiPathTeam.Dates.Activities.Strings
{
    public class CompareDatesString : CodeActivity
    {
        [LocalizedCategory(nameof(Resources.InputString))]
        [LocalizedDescription(nameof(Resources.Date1StringDescription))]
        [LocalizedDisplayName(nameof(Resources.Date1StringDisplayName))]
        public InArgument<String> Date1String { get; set; }

        [LocalizedCategory(nameof(Resources.InputString))]
        [LocalizedDescription(nameof(Resources.Date2StringDescription))]
        [LocalizedDisplayName(nameof(Resources.Date2StringDisplayName))]
        public InArgument<String> Date2String { get; set; }


        [LocalizedCategory(nameof(Resources.InputString))]
        public InArgument<String> Format { get; set; } = "dd/MM/yyyy";


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
        public Boolean CheckSecondes { get; set; }


        [Browsable(false)]
        public String SelectedComboItem { get; set; } = "dd/MM/yyyy";
        [Browsable(false)]
        public String PreviewFormat { get; set; }


        [LocalizedCategory(nameof(Resources.Output))]
        public TimeBins OutputDateDifferenceUnits { get; set; }

        [LocalizedCategory(nameof(Resources.Output))]
        public OutArgument<Boolean> Result { get; set; }

        [LocalizedCategory(nameof(Resources.Output))]
        public OutArgument<Double> DateDifference { get; set; }


        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);

            if (Date1String == null && Date2String == null)
            {
                metadata.AddValidationError(new ValidationError("The date fields are empty. Please provide at least Date 1 and Date 2 as Strings or Datetime objects."));
            }
            if (Date1String == null && Date2String != null)
            {
                metadata.AddValidationError(new ValidationError("The Date 1 (String) field is empty."));
            }
            if (Date2String == null && Date1String != null)
            {
                metadata.AddValidationError(new ValidationError("The Date 2 (String) field is empty."));
            }
        }

        protected override void Execute(CodeActivityContext context)
        {
            Boolean result = true;

            String DateS1 = Date1String.Get(context);
            String DateS2 = Date2String.Get(context);
            String format = Format.Get(context);

            if (String.IsNullOrEmpty(format))
            {
                format = "dd/MM/yyyy";
            }

            DateTime DT1 = DateTime.ParseExact(DateS1, format, null);
            DateTime DT2 = DateTime.ParseExact(DateS2, format, null);

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
                    DateDifference.Set(context, dt.TotalDays);
                    break;
                case TimeBins.Months:
                    DateDifference.Set(context, dt.TotalDays / 30.4375);
                    break;
                case TimeBins.Years:
                    DateDifference.Set(context, dt.TotalDays / 365.25);
                    break;
                default:
                    DateDifference.Set(context, dt.TotalMilliseconds);
                    break;
            }
        }
    }
}
