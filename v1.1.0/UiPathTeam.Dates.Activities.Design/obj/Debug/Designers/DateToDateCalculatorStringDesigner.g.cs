﻿#pragma checksum "..\..\..\Designers\DateToDateCalculatorStringDesigner.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "102AB120B007DFC562588169648CA366B41B1FDC91811F15F9BB31AA242E031A"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Activities.Presentation;
using System.Activities.Presentation.Converters;
using System.Activities.Presentation.View;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace UiPathTeam.Dates.Activities.Design.Designers {
    
    
    /// <summary>
    /// DateToDateCalculatorStringDesigner
    /// </summary>
    public partial class DateToDateCalculatorStringDesigner : System.Activities.Presentation.ActivityDesigner, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/UiPathTeam.Dates.Activities.Design;component/designers/datetodatecalculatorstrin" +
                    "gdesigner.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Designers\DateToDateCalculatorStringDesigner.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 19 "..\..\..\Designers\DateToDateCalculatorStringDesigner.xaml"
            ((System.Windows.Controls.RowDefinition)(target)).Initialized += new System.EventHandler(this.rowToHide_Initialized);
            
            #line default
            #line hidden
            break;
            case 2:
            
            #line 58 "..\..\..\Designers\DateToDateCalculatorStringDesigner.xaml"
            ((System.Windows.Controls.ComboBox)(target)).Initialized += new System.EventHandler(this.ComboBox_Initialized);
            
            #line default
            #line hidden
            
            #line 59 "..\..\..\Designers\DateToDateCalculatorStringDesigner.xaml"
            ((System.Windows.Controls.ComboBox)(target)).DropDownClosed += new System.EventHandler(this.ComboBox_DropDownClosed);
            
            #line default
            #line hidden
            break;
            case 3:
            
            #line 80 "..\..\..\Designers\DateToDateCalculatorStringDesigner.xaml"
            ((System.Windows.Controls.Label)(target)).Initialized += new System.EventHandler(this.PreviewField_Initialized);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

