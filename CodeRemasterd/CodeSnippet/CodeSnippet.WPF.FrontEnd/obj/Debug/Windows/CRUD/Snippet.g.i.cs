﻿#pragma checksum "..\..\..\..\Windows\CRUD\Snippet.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C2E0C2255500F9A518145AEC2ADA92509FB95D84"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using CodeSnippet.WPF.FrontEnd.Windows.CRUD;
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


namespace CodeSnippet.WPF.FrontEnd.Windows.CRUD {
    
    
    /// <summary>
    /// Snippet
    /// </summary>
    public partial class Snippet : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\..\Windows\CRUD\Snippet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Name;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\Windows\CRUD\Snippet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Language;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\Windows\CRUD\Snippet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RichTextBox Code;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\Windows\CRUD\Snippet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RichTextBox Usage;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\Windows\CRUD\Snippet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RichTextBox Description;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\Windows\CRUD\Snippet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Submit_btn;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\Windows\CRUD\Snippet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Back_btn;
        
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
            System.Uri resourceLocater = new System.Uri("/CodeSnippet.WPF.FrontEnd;component/windows/crud/snippet.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Windows\CRUD\Snippet.xaml"
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
            this.Name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.Language = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.Code = ((System.Windows.Controls.RichTextBox)(target));
            return;
            case 4:
            this.Usage = ((System.Windows.Controls.RichTextBox)(target));
            return;
            case 5:
            this.Description = ((System.Windows.Controls.RichTextBox)(target));
            return;
            case 6:
            this.Submit_btn = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\..\..\Windows\CRUD\Snippet.xaml"
            this.Submit_btn.Click += new System.Windows.RoutedEventHandler(this.Submit_btn_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Back_btn = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\..\Windows\CRUD\Snippet.xaml"
            this.Back_btn.Click += new System.Windows.RoutedEventHandler(this.Back_btn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

