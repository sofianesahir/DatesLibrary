using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using UiPathTeam.Dates.Activities.Properties;

namespace UiPathTeam.Dates.Activities
{
    public class IsLeapYear : CodeActivity
    {
        [LocalizedDisplayName(nameof(Resources.YearDisplayName))]
        [LocalizedDescription(nameof(Resources.YearDescription))]
        [LocalizedCategory(nameof(Resources.Input))]
        public InArgument<String> Year { get; set; }

        [LocalizedDisplayName(nameof(Resources.IsLeapDisplayName))]
        [LocalizedDescription(nameof(Resources.IsLeapDescription))]
        [LocalizedCategory(nameof(Resources.Output))]
        public OutArgument<Boolean> IsLeap { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
           IsLeap.Set(context, (Int32.Parse(Year.Get(context)) % 4 == 0) ? true : false);
        }
    }
}
