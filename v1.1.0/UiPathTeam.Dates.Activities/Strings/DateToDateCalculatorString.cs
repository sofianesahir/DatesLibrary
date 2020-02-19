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
    public class DateToDateCalculatorString : CodeActivity
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
        [Browsable(false)]
        public String SelectedComboItem { get; set; } = "dd/MM/yyyy";
        [Browsable(false)]
        public String PreviewFormat { get; set; }

        [LocalizedCategory(nameof(Resources.Output))]
        public OutArgument<Dictionary<String, Int32>> Difference { get; set; }

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
            String DateS1 = Date1String.Get(context);
            String DateS2 = Date2String.Get(context);
            Dictionary<String, Int32> dict = new Dictionary<string, int>();
            String format = Format.Get(context);

            if (String.IsNullOrEmpty(format))
            {
                format = "dd/MM/yyyy";
            }
            DateTime DT1 = DateTime.ParseExact(DateS1, format, null);
            DateTime DT2 = DateTime.ParseExact(DateS2, format, null);

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
