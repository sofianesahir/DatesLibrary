using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Activities;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Activities.Validation;
using UiPathTeam.Dates.Activities.Properties;

namespace UiPathTeam.Dates.Activities.Strings
{
    public class WeekNumberString : CodeActivity
    {
        [LocalizedDisplayName(nameof(Resources.DateStringDisplayName))]
        [LocalizedDescription(nameof(Resources.DateStringDescription))]
        [LocalizedCategory(nameof(Resources.InputString))]
        public InArgument<String> DateString { get; set; }

        [LocalizedCategory(nameof(Resources.InputString))]
        public InArgument<String> Format { get; set; } = "dd/MM/yyyy";

        [Browsable(false)]
        public String PreviewFormat { get; set; }

        [Browsable(false)]
        public String SelectedComboItem { get; set; } = "dd/MM/yyyy";

        [LocalizedDisplayName(nameof(Resources.WeekNbDisplayName))]
        [LocalizedDescription(nameof(Resources.WeekNbDescription))]
        [LocalizedCategory(nameof(Resources.Output))]
        public OutArgument<Int32> WeekNb { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            DateTime date;
            String date_string = DateString.Get(context);

            if (date_string != null)
            { 
                date = DateTime.Parse(date_string);

                DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(date);
                if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
                {
                    date = date.AddDays(3);
                }

                WeekNb.Set(context, CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday));
            }
        }
    }
}
