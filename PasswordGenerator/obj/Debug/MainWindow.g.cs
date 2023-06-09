﻿#pragma checksum "..\..\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6974A3CB2584FA0CA3B4F205D30B2A27246A31F4387D706CAFB033C26C87F75A"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using AutoGrid;
using MatrixRain;
using MatrixRainWpfApp;
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


namespace MatrixRainWpfApp {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 43 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MatrixRain.MatrixRain MRain;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PasswordTextbox;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button GeneratePasswordButton;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CopyPasswordButton;
        
        #line default
        #line hidden
        
        
        #line 112 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox SymbolsCheckbox;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox NumbersCheckbox;
        
        #line default
        #line hidden
        
        
        #line 141 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox BigLettersCheckbox;
        
        #line default
        #line hidden
        
        
        #line 151 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox SmallLettersCheckbox;
        
        #line default
        #line hidden
        
        
        #line 167 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox LengthTextBox;
        
        #line default
        #line hidden
        
        
        #line 187 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MinusLengthButton;
        
        #line default
        #line hidden
        
        
        #line 198 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PlusLengthButton;
        
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
            System.Uri resourceLocater = new System.Uri("/PasswordGenerator;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
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
            this.MRain = ((MatrixRain.MatrixRain)(target));
            return;
            case 2:
            this.PasswordTextbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.GeneratePasswordButton = ((System.Windows.Controls.Button)(target));
            
            #line 77 "..\..\MainWindow.xaml"
            this.GeneratePasswordButton.Click += new System.Windows.RoutedEventHandler(this.GeneratePasswordButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.CopyPasswordButton = ((System.Windows.Controls.Button)(target));
            
            #line 91 "..\..\MainWindow.xaml"
            this.CopyPasswordButton.Click += new System.Windows.RoutedEventHandler(this.CopyPasswordButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.SymbolsCheckbox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 112 "..\..\MainWindow.xaml"
            this.SymbolsCheckbox.Checked += new System.Windows.RoutedEventHandler(this.SymbolsCheckbox_Checked);
            
            #line default
            #line hidden
            
            #line 112 "..\..\MainWindow.xaml"
            this.SymbolsCheckbox.Unchecked += new System.Windows.RoutedEventHandler(this.SymbolsCheckbox_Unchecked);
            
            #line default
            #line hidden
            return;
            case 6:
            this.NumbersCheckbox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 122 "..\..\MainWindow.xaml"
            this.NumbersCheckbox.Checked += new System.Windows.RoutedEventHandler(this.NumbersCheckbox_Checked);
            
            #line default
            #line hidden
            
            #line 122 "..\..\MainWindow.xaml"
            this.NumbersCheckbox.Unchecked += new System.Windows.RoutedEventHandler(this.NumbersCheckbox_Unchecked);
            
            #line default
            #line hidden
            return;
            case 7:
            this.BigLettersCheckbox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 141 "..\..\MainWindow.xaml"
            this.BigLettersCheckbox.Checked += new System.Windows.RoutedEventHandler(this.BigLettersCheckbox_Checked);
            
            #line default
            #line hidden
            
            #line 141 "..\..\MainWindow.xaml"
            this.BigLettersCheckbox.Unchecked += new System.Windows.RoutedEventHandler(this.BigLettersCheckbox_Unchecked);
            
            #line default
            #line hidden
            return;
            case 8:
            this.SmallLettersCheckbox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 151 "..\..\MainWindow.xaml"
            this.SmallLettersCheckbox.Checked += new System.Windows.RoutedEventHandler(this.SmallLettersCheckbox_Checked);
            
            #line default
            #line hidden
            
            #line 151 "..\..\MainWindow.xaml"
            this.SmallLettersCheckbox.Unchecked += new System.Windows.RoutedEventHandler(this.SmallLettersCheckbox_Unchecked);
            
            #line default
            #line hidden
            return;
            case 9:
            this.LengthTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.MinusLengthButton = ((System.Windows.Controls.Button)(target));
            
            #line 190 "..\..\MainWindow.xaml"
            this.MinusLengthButton.Click += new System.Windows.RoutedEventHandler(this.MinusLengthButton_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.PlusLengthButton = ((System.Windows.Controls.Button)(target));
            
            #line 200 "..\..\MainWindow.xaml"
            this.PlusLengthButton.Click += new System.Windows.RoutedEventHandler(this.PlusLengthButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

