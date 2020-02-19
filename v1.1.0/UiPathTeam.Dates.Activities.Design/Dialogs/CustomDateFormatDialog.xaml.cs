using System;
using System.Activities.Presentation.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UiPathTeam.Dates.Activities.Design.Dialogs
{
    // Logique d'interaction pour CustomDateFormatDialog.xaml
    public partial class CustomDateFormatDialog
    {
        public CustomDateFormatDialog(ModelItem modelItem)
        {
            InitializeComponent();
            this.ModelItem = modelItem;
            this.Context = modelItem.GetEditingContext();
        }
    }
}
