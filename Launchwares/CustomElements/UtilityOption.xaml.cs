﻿using Launchwares.Resources.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Launchwares.CustomElements
{
    /// <summary>
    /// LanguageOption.xaml etkileşim mantığı
    /// </summary>
    public partial class UtilityOption : UserControl
    {
        public UtilityOption()
        {
            InitializeComponent();
        }

        public static DependencyProperty CurrentTextProperty = DependencyProperty.Register("OptionText", typeof(string), typeof(UtilityOption), new PropertyMetadata(new PropertyChangedCallback(OnTextChanged)));

        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UtilityOption viewer = d as UtilityOption;
            viewer.OptionValue = ((string)e.NewValue);
        }

        public string OptionValue
        {
            get
            {
                return OptionText.Text;
            }
            set
            {
                if (OptionText.Text != value)
                    OptionText.Text = value;
            }
        }

        public bool? IsChecked
        {
            get
            {
                return Toggle.IsChecked;
            }
            set
            {
                if (Toggle.IsChecked != value) {
                    OptionContainer.Style = (Toggle.IsChecked == true) ? ThemeHelper.LanguageOptionStyle : ThemeHelper.LanguageOptionSelectedStyle;
                    Toggle.IsChecked = value;
                }
            }
        }

        public string Value
        {
            get
            {
                return Value;
            }
            set
            {
                if (Value != value)
                    Value = value;
            }
        }

        private void OptionContainer_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton != MouseButton.Left) return;
            this.IsChecked = !this.IsChecked;
        }
    }
}
