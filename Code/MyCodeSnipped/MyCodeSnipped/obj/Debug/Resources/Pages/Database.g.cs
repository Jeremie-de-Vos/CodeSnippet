﻿#pragma checksum "..\..\..\..\Resources\Pages\Database.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B40B38070EB8841D588D746A380AE1B59CF67A7A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MyCodeSnipped.Resources.Pages;
using System;
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


namespace MyCodeSnipped.Resources.Pages {
    
    
    /// <summary>
    /// Database
    /// </summary>
    public partial class Database : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\..\Resources\Pages\Database.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button refresh_btn;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\Resources\Pages\Database.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox DB_Databases_Filter_cmb;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\Resources\Pages\Database.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox DB_filterType_cmb;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\Resources\Pages\Database.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox DB_TableFilter_cmb;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\Resources\Pages\Database.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel Db_status_container;
        
        #line default
        #line hidden
        
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
            System.Uri resourceLocater = new System.Uri("/MyCodeSnipped;component/resources/pages/database.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Resources\Pages\Database.xaml"
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
            switch (connectionId)
            {
            case 1:
            this.refresh_btn = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\..\Resources\Pages\Database.xaml"
            this.refresh_btn.Click += new System.Windows.RoutedEventHandler(this.refresh_btn_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 18 "..\..\..\..\Resources\Pages\Database.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.DB_Databases_Filter_cmb = ((System.Windows.Controls.ComboBox)(target));
            
            #line 20 "..\..\..\..\Resources\Pages\Database.xaml"
            this.DB_Databases_Filter_cmb.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DB_Databases_Filter_cmb_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.DB_filterType_cmb = ((System.Windows.Controls.ComboBox)(target));
            
            #line 21 "..\..\..\..\Resources\Pages\Database.xaml"
            this.DB_filterType_cmb.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DB_filterType_cmb_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.DB_TableFilter_cmb = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.Db_status_container = ((System.Windows.Controls.StackPanel)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

