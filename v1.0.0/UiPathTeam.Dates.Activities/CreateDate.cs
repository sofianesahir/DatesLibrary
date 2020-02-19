using System;
using System.Activities;
using System.Activities.Validation;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiPathTeam.Dates.Activities.Properties;

namespace UiPathTeam.Dates.Activities
{
    public class CreateDate : CodeActivity
    {
        [LocalizedCategory(nameof(Resources.Input))]
        [LocalizedDisplayName(nameof(Resources.DayDisplayName))]
        [LocalizedDescription(nameof(Resources.DayDescription))]
        public InArgument<Int32> Day { get; set; }

        [LocalizedCategory(nameof(Resources.Input))]
        [LocalizedDisplayName(nameof(Resources.MonthDisplayName))]
        [LocalizedDescription(nameof(Resources.MonthDescription))]
        public InArgument<Int32> Month { get; set; }

        [LocalizedCategory(nameof(Resources.Input))]
        [LocalizedDisplayName(nameof(Resources.YearDisplayName))]
        [LocalizedDescription(nameof(Resources.YearDescription))]
        public InArgument<Int32> Year { get; set; }

        [LocalizedCategory(nameof(Resources.Input))]
        [LocalizedDisplayName(nameof(Resources.HoursDisplayName))]
        [LocalizedDescription(nameof(Resources.HoursDescription))]
        public InArgument<Int32> Hours { get; set; }

        [LocalizedCategory(nameof(Resources.Input))]
        [LocalizedDisplayName(nameof(Resources.MinutesDisplayName))]
        [LocalizedDescription(nameof(Resources.MinutesDescription))]
        public InArgument<Int32> Minutes { get; set; }

        [LocalizedCategory(nameof(Resources.Input))]
        [LocalizedDisplayName(nameof(Resources.SecondsDisplayName))]
        [LocalizedDescription(nameof(Resources.SecondsDescription))]
        public InArgument<Int32> Seconds { get; set; }

        [LocalizedCategory(nameof(Resources.Output))]
        [LocalizedDisplayName(nameof(Resources.DateDisplayName))]
        [LocalizedDescription(nameof(Resources.DateDescription))]
        public OutArgument<DateTime> Date { get; set; }

       

        protected override void Execute(CodeActivityContext context)
        {
            Int32 day = Day.Get(context);
            Int32 month = Month.Get(context);
            Int32 year = Year.Get(context);

            Int32 hours = Hours.Get(context);
            Int32 minutes = Minutes.Get(context);
            Int32 seconds = Seconds.Get(context);

            Boolean IsLeapYear = DateTime.IsLeapYear(year);

            if (day < 1 || day > 31)
                throw new System.ArgumentOutOfRangeException(nameof(day), "Day out of range (1 - 31");
            if (month < 1 || month > 12)
                throw new System.ArgumentOutOfRangeException(nameof(month), "Month out of range (1 - 12)");
            if (hours < 0 || hours > 23)
                throw new System.ArgumentOutOfRangeException(nameof(hours), "Hours out of range (0 - 23)");
            if (minutes < 0 || minutes > 59)
                throw new System.ArgumentOutOfRangeException(nameof(minutes), "Minutes out of range (0 - 23)");
            if (seconds < 0 || seconds > 59)
                throw new System.ArgumentOutOfRangeException(nameof(minutes), "Secondes out of range (0 - 23)");

            if ((month == 2 && day == 29) && !IsLeapYear)
                throw new System.ArgumentOutOfRangeException(nameof(year),  "year is not a leap year.");

            Date.Set(context, new DateTime(year, month, day, hours, minutes, seconds));
        }
    }
}
