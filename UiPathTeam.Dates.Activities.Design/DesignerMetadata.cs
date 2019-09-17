using System.Activities.Presentation.Metadata;
using System.ComponentModel;
using System.ComponentModel.Design;
using UiPathTeam.Dates.Activities.Design.Designers;
using UiPathTeam.Dates.Activities.Design.Properties;

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

            MetadataStore.AddAttributeTable(builder.CreateTable());
        }
    }
}
