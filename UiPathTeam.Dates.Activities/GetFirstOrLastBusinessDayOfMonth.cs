using System;
using System.Activities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiPathTeam.Dates.Activities.Properties;

namespace UiPathTeam.Dates.Activities
{
    public class GetFirstOrLastBusinessDayOfMonth : CodeActivity
    {

        [LocalizedCategory(nameof(Resources.Input))]
        [LocalizedDisplayName(nameof(Resources.PositionDisplayName))]
        [LocalizedDescription(nameof(Resources.PositionDescription))]
        public FirstOrLast Position { get; set; }

        [LocalizedCategory(nameof(Resources.Input))]
        [LocalizedDisplayName(nameof(Resources.MonthDisplayName))]
        [LocalizedDescription(nameof(Resources.MonthDescription))]
        public Months Month { get; set; }

        [LocalizedCategory(nameof(Resources.Input))]
        [LocalizedDisplayName(nameof(Resources.YearDisplayName))]
        [LocalizedDescription(nameof(Resources.YearDescription))]
        public InArgument<Int32> Year { get; set; }

        [Category("Output String")]
        [LocalizedDisplayName(nameof(Resources.DateFormatDisplayName))]
        [LocalizedDescription(nameof(Resources.DateFormatDescription))]
        public InArgument<String> DateFormat { get; set; }

        [Category("Output as DateTime")]
        [LocalizedDisplayName(nameof(Resources.BDotMDisplayName))]
        [LocalizedDescription(nameof(Resources.BDotMDescription))]
        public OutArgument<DateTime> BusinessDayOfMonth { get; set; }

        [Category("Output as String")]
        [LocalizedDisplayName(nameof(Resources.BDotMDisplayName))]
        [LocalizedDescription(nameof(Resources.BDotMDescription))]
        public OutArgument<String> BusinessDayOfMonthString { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            String position = Position.ToString();
            Int32 month = (Int32) Month;
            Int32 year = Year.Get(context);
            Int32 day;
            Int32 offsetDays = 0;

            DateTime dt = new DateTime(year, month, 1);

            if (position.Equals("Last"))
                dt = dt.AddMonths(1).AddDays(-1);

            day = (Int32) dt.DayOfWeek;


            switch (position)
            {
                case "First":
                    if (day == 0)
                        offsetDays = 1;    
                    if (day == 6)
                        offsetDays = 2;
                    break;
                case "Last":
                    if (day == 0)
                        offsetDays = -2;
                    if (day == 6)
                        offsetDays = -1;
                    break;

                default:
                    break;
            }

            if (offsetDays != 0)
                dt = dt.AddDays(offsetDays);

            BusinessDayOfMonth.Set(context, dt);
            BusinessDayOfMonthString.Set(context, dt.ToString(DateFormat.Get(context)));

        }
    }
}
