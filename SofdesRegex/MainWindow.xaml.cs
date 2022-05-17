using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace SofdesRegex
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            nameInput.Text = string.Empty;
            Reset(nameFeedback);
            mobileNumberInput.Text = string.Empty;
            Reset(mobileNumberFeedback);
            emailAddressInput.Text = string.Empty;
            Reset(emailAddressFeedback);
            urlInput.Text = string.Empty;
            Reset(urlFeedback);
        }

        private void Validate(object sender, RoutedEventArgs e)
        {
            if (new Regex(@"^[a-zA-Z. ]+$").IsMatch(nameInput.Text))
            {
                Correct(nameFeedback);
            }
            else
            {
                Incorrect(nameFeedback);
            }

            if (new Regex(@"^[0-9]{4}-[0-9]{3}-[0-9]{4}$").IsMatch(mobileNumberInput.Text))
            {
                Correct(mobileNumberFeedback);
            }
            else
            {
                Incorrect(mobileNumberFeedback);
            }

            if (new Regex(@"^\w{1,64}@[a-z]{1,253}\.(com|org)$").IsMatch(emailAddressInput.Text))
            {
                Correct(emailAddressFeedback);
            }
            else
            {
                Incorrect(emailAddressFeedback);
            }

            if (new Regex(@"^https?://([\w-]+\.)+(com|net)$").IsMatch(urlInput.Text))
            {
                Correct(urlFeedback);
            }
            else
            {
                Incorrect(urlFeedback);
            }
        }

        private void Correct(TextBlock feedback)
        {
            feedback.Foreground = new SolidColorBrush(Colors.DarkGreen);
            feedback.Text = "Format is correct";
            feedback.Visibility = Visibility.Visible;
        }
        private void Incorrect(TextBlock feedback)
        {
            feedback.Foreground = new SolidColorBrush(Colors.Red);
            feedback.Text = "Format is incorrect";
            feedback.Visibility = Visibility.Visible;
        }
        private void Reset(TextBlock feedback)
        {
            feedback.Visibility = Visibility.Collapsed;
        }

    }
}
