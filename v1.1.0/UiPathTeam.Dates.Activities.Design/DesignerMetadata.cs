using System.Activities.Presentation.Metadata;
using System.ComponentModel;
using System.ComponentModel.Design;
using UiPathTeam.Dates.Activities.Datetime;
using UiPathTeam.Dates.Activities.Design.Designers;
using UiPathTeam.Dates.Activities.Design.Properties;
using UiPathTeam.Dates.Activities.Strings;

namespace UiPathTeam.Dates.Activities.Design
{
    public class DesignerMetadata : IRegisterMetadata
    {
        public void Register()
        {
            var builder = new AttributeTableBuilder();
            builder.ValidateTable();

            var categoryAttribute =  new CategoryAttribute($"{Resources.Category}");

            builder.AddCustomAttributes(typeof(IsLeapYear), new DesignerAttribute(typeof(IsLeapYearDesigner)));
            builder.AddCustomAttributes(typeof(CreateDate), new DesignerAttribute(typeof(CreateDateDesigner)));
            builder.AddCustomAttributes(typeof(DateToString), new DesignerAttribute(typeof(DateToStringDesigner)));
            builder.AddCustomAttributes(typeof(GetFirstOrLastBusinessDayOfMonth), new DesignerAttribute(typeof(GetFirstOrLastBusinessDayOfMonthDesigner)));
            builder.AddCustomAttributes(typeof(CompareDates), new DesignerAttribute(typeof(CompareDatesDesigner)));
            builder.AddCustomAttributes(typeof(CompareDatesString), new DesignerAttribute(typeof(CompareDatesStringDesigner)));
            builder.AddCustomAttributes(typeof(DateToDateCalculatorString), new DesignerAttribute(typeof(DateToDateCalculatorStringDesigner)));
            builder.AddCustomAttributes(typeof(AddToDate), new DesignerAttribute(typeof(AddToDateDesigner)));
            builder.AddCustomAttributes(typeof(DateToDateCalculator), new DesignerAttribute(typeof(DateToDateCalculatorDesigner)));
            builder.AddCustomAttributes(typeof(StringToDate), new DesignerAttribute(typeof(StringToDateDesigner)));
            builder.AddCustomAttributes(typeof(WeekNumber), new DesignerAttribute(typeof(WeekNumberDesigner)));
            builder.AddCustomAttributes(typeof(WeekNumberString), new DesignerAttribute(typeof(WeekNumberStringDesigner)));

            MetadataStore.AddAttributeTable(builder.CreateTable());
        }
    }
}
