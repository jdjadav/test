using MahApps.Metro.Controls;
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
using System.Windows.Shapes;

namespace SMS
{
    /// <summary>
    /// Interaction logic for CustomDialogBox.xaml
    /// </summary>
    public partial class CustomDialogBox : MetroWindow
    {
        public CustomDialogBox(String CustomDialogContent,  DialogType CustomDialogType)
        {
            InitializeComponent();
            this.WindowState = System.Windows.WindowState.Normal;
            this.ShowInTaskbar = false;
            this.ShowTitleBar = false;
            this.ShowCloseButton = false;
            this.IsCloseButtonEnabled = true;
            this.ShowMinButton = false;
            this.WindowTransitionsEnabled = false;
            this.Topmost = false;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.ResizeMode = ResizeMode.NoResize;

            if (CustomDialogType == DialogType.Question)
            {
                QuestionDialogBox.Visibility = Visibility.Visible;
                InformationDialogBox.Visibility = Visibility.Collapsed;
                ErrorDialogBox.Visibility = Visibility.Collapsed;

                QuestionText.Text = CustomDialogContent;
                QuestionYesButton.Focus();
            }

            if (CustomDialogType == DialogType.Information)
            {
                QuestionDialogBox.Visibility = Visibility.Collapsed;
                InformationDialogBox.Visibility = Visibility.Visible;
                ErrorDialogBox.Visibility = Visibility.Collapsed;

                InformationText.Text = CustomDialogContent;
                InformationOKButton.Focus();
            }

            if (CustomDialogType == DialogType.Error)
            {
                QuestionDialogBox.Visibility = Visibility.Collapsed;
                InformationDialogBox.Visibility = Visibility.Collapsed;
                ErrorDialogBox.Visibility = Visibility.Visible;

                ErrorText.Text = CustomDialogContent;
                ErrorOKButton.Focus();
            }

        }

        private void Close_Window(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        

        

        private void QuestionYesButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void QuestionNoButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ErrorOKButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void InformationOKButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
    public enum DialogType
    {
        Information = 0,
        Question = 1,
        Error = 2


    }
}
