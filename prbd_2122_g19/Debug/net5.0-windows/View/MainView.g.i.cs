﻿#pragma checksum "..\..\..\..\View\MainView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0DC86A6A533208CE2DF1C651FEDE9EFE4BBE5F28"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using PRBD_Framework;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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
using prbd_2122_g19;
using prbd_2122_g19.View;
using prbd_2122_g19.ViewModel;


namespace prbd_2122_g19.View {
    
    
    /// <summary>
    /// MainView
    /// </summary>
    public partial class MainView : PRBD_Framework.WindowBase, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\..\View\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal prbd_2122_g19.ViewModel.MainViewModel vm;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\View\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal PRBD_Framework.MyTabControl tabControl;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\View\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem AccountsTab;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.13.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/prbd_2122_g19;component/view/mainview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\MainView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.13.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 11 "..\..\..\..\View\MainView.xaml"
            ((prbd_2122_g19.View.MainView)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.WindowBase_KeyDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.vm = ((prbd_2122_g19.ViewModel.MainViewModel)(target));
            return;
            case 3:
            
            #line 28 "..\..\..\..\View\MainView.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuLogout_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.tabControl = ((PRBD_Framework.MyTabControl)(target));
            return;
            case 5:
            this.AccountsTab = ((System.Windows.Controls.TabItem)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
