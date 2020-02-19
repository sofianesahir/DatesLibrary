using System;
using System.Activities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiPathTeam.Dates.Activities.Properties;

namespace UiPathTeam.Dates.Activities.Datetime
{
    public class DateToString : CodeActivity
    {
        [LocalizedCategory(nameof(Resources.Input))]
        [LocalizedDisplayName(nameof(Resources.DateDisplayName))]
        [LocalizedDescription(nameof(Resources.DateDescription))]
        public InArgument<DateTime> Date { get; set; }

        [LocalizedCategory(nameof(Resources.Input))]
        [LocalizedDisplayName(nameof(Resources.DateFormatDisplayName))]
        [LocalizedDescription(nameof(Resources.DateFormatDescription))]
        public InArgument<String> DateFormat { get; set; } = "dd/MM/yyyy";

        [Browsable(false)]
        public String PreviewFormat { get; set; }

        [Browsable(false)]
        public String SelectedComboItem { get; set; } = "dd/MM/yyyy";

        [LocalizedCategory(nameof(Resources.Output))]
        [LocalizedDisplayName(nameof(Resources.DateStringDisplayName))]
        [LocalizedDescription(nameof(Resources.DateStringDescription))]
        public OutArgument<String> DateString { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            DateTime dt = Date.Get<DateTime>(context);
            String format = DateFormat.Get<String>(context);
            try
            {
                if (Date == null)
                    dt = new DateTime();

                if (format == null || format.Equals(""))
                    format = "dd/MM/yyyy";

                DateString.Set(context, dt.ToString(format));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
