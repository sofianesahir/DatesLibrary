using System;
using System.Activities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiPathTeam.Dates.Activities.Properties;

namespace UiPathTeam.Dates.Activities.Strings
{
    public class StringToDate : CodeActivity
    {
        [LocalizedCategory(nameof(Resources.Input))]
        [LocalizedDisplayName(nameof(Resources.DateDisplayName))]
        [LocalizedDescription(nameof(Resources.DateDescription))]
        public InArgument<String> Date { get; set; }

        [LocalizedCategory(nameof(Resources.Input))]
        [LocalizedDisplayName(nameof(Resources.DateFormatDisplayName))]
        [LocalizedDescription(nameof(Resources.DateFormatDescription))]
        public InArgument<String> Format { get; set; } = "dd/MM/yyyy";

        [Browsable(false)]
        public String PreviewFormat { get; set; }

        [Browsable(false)]
        public String SelectedComboItem { get; set; } = "dd/MM/yyyy";

        [LocalizedCategory(nameof(Resources.Output))]
        [LocalizedDisplayName(nameof(Resources.DateStringDisplayName))]
        [LocalizedDescription(nameof(Resources.DateStringDescription))]
        public OutArgument<DateTime> DateDT { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            String date_string = Date.Get(context);
            String format = Format.Get<String>(context);

            if (!String.IsNullOrEmpty(date_string))
            {
                if (String.IsNullOrEmpty(format))
                {
                    format = "dd/MM/yyyy";
                }

                try
                {
                    DateTime DT1 = DateTime.ParseExact(date_string, format, null);
                    DateDT.Set(context, DT1);
                }
                catch (Exception innerException)
                {
                    throw new SystemException("Error parsing date from string.", innerException);
                }
            }
        }
    }
}
