using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiPathTeam.Dates.Activities.Properties;

namespace UiPathTeam.Dates.Activities
{
    public class DueDate : CodeActivity
    {
        [LocalizedCategory(nameof(Resources.Input))]
        public InArgument<DateTime> Date { get; set; }

        [LocalizedCategory(nameof(Resources.Input))]
        public InArgument<Int32> Offset { get; set; }

        [LocalizedCategory(nameof(Resources.Input))]
        public InArgument<MatType> Units { get; set; }


        [LocalizedCategory(nameof(Resources.Output))]
        public OutArgument<DateTime> NewDate { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            DateTime date = Date.Get<DateTime>(context);

            if (date == null)
                date = DateTime.Today;

            Int32 offset = Offset.Get(context);
            MatType unit = Units.Get(context);
            DateTime newDate = new DateTime();

            switch (unit)
            {
                case MatType.Days:
                    newDate = date.AddDays(offset);
                    break;
                case MatType.Months:
                    newDate = date.AddMonths(offset); 
                    break;
                case MatType.Years:
                    newDate = date.AddYears(offset);
                    break;
                default:
                    break;
            }

            NewDate.Set(context, newDate);
        }
    }
}
