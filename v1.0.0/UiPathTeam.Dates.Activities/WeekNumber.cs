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

namespace UiPathTeam.Dates.Activities
{
    public class WeekNumber : CodeActivity
    {
        [LocalizedDisplayName(nameof(Resources.DateDisplayName))]
        [LocalizedDescription(nameof(Resources.DateDescription))]
        [LocalizedCategory(nameof(Resources.Input))]
        public InArgument<DateTime> Date { get; set; }

        [LocalizedDisplayName(nameof(Resources.DateStringDisplayName))]
        [LocalizedDescription(nameof(Resources.DateStringDescription))]
        [LocalizedCategory(nameof(Resources.Input))]
        public InArgument<String> DateString { get; set; }

        [LocalizedDisplayName(nameof(Resources.WeekNbDisplayName))]
        [LocalizedDescription(nameof(Resources.WeekNbDescription))]
        [LocalizedCategory(nameof(Resources.Output))]
        public OutArgument<Int32> WeekNb { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            DateTime date = Date.Get(context);
            String date_string = DateString.Get(context);

            if (date_string != null)
                date = DateTime.Parse(date_string);

            if (date != null)
            {
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
