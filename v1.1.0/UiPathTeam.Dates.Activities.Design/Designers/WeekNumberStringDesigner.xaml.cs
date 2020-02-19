using System;
using System.Activities;
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
using UiPathTeam.Dates.Activities.Design.Dialogs;

namespace UiPathTeam.Dates.Activities.Design.Designers
{
    // Logique d'interaction pour WeekNumberStringDesigner.xaml
    public partial class WeekNumberStringDesigner
    {
        private ComboBox _cmb { get; set; }

        private Label _lblPreview { get; set; }

        private DateTime _today { get; set; }
        public WeekNumberStringDesigner()
        {
            InitializeComponent();
            _today = DateTime.Today;
            DateTime now = DateTime.Now;
            _today = _today.AddHours(now.Hour).AddMinutes(now.Minute).AddSeconds(now.Second).AddMilliseconds(now.Millisecond);
        }

        private void ComboBox_Initialized(object sender, EventArgs e)
        {
            this._cmb = sender as ComboBox;
            InArgument<String> dateFormat = ModelItem.Properties["Format"].Value.GetCurrentValue() as InArgument<String>;

            String comboBoxItem = dateFormat.Expression.ToString();

            int i = 0;
            foreach (var item in _cmb.Items.OfType<ComboBoxItem>())
            {
                if (item.Content.Equals(comboBoxItem))
                {
                    _cmb.SelectedIndex = i;
                    break;
                }
                i++;
            }
            if (i == _cmb.Items.Count)
                _cmb.SelectedIndex = _cmb.Items.Count - 1;
            _cmb.UpdateLayout();
        }

        private void ComboBox_DropDownClosed(object sender, EventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            ModelItem.Properties["SelectedComboItem"].SetValue(cmb.Text);


            if (cmb.Text.Equals("Custom..."))
            {
                CustomDateFormatDialog2 customDateformatDialog = new CustomDateFormatDialog2(ModelItem);
                if (customDateformatDialog.ShowOkCancel())
                    _cmb.SelectedItem = "Custom...";
            }
            else
            {
                ModelItem.Properties["Format"].SetValue(new InArgument<String>(cmb.Text));
            }
            InArgument<String> dateFormat = ModelItem.Properties["Format"].Value.GetCurrentValue() as InArgument<String>;

            if (!dateFormat.Expression.ToString().Contains("<"))
            {
                _lblPreview.Content = _today.ToString(dateFormat.Expression.ToString());
            }
            else
            {
                _lblPreview.Content = "Date Format provided as variable.";
            }
            _lblPreview.UpdateLayout();
        }

        private void Label_Initialized(object sender, EventArgs e)
        {
            _lblPreview = sender as Label;
            InArgument<String> dateFormat = ModelItem.Properties["Format"].Value.GetCurrentValue() as InArgument<String>;
            if (!dateFormat.Expression.ToString().Contains("<"))
            {
                _lblPreview.Content = _today.ToString(dateFormat.Expression.ToString());
            }
            else
            {
                _lblPreview.Content = "Date Format provided as variable.";
            }
            _lblPreview.UpdateLayout();
        }
    }
}
