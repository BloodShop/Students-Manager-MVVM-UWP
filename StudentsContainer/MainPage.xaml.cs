using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace StudentsContainer
{
    public sealed partial class MainPage : Page
    {
        public MainPage() => this.InitializeComponent();
        void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            ID_TB.Text = String.Empty;
            FirstNameTB.Text = string.Empty;
            LastNameTB.Text = string.Empty;
            EmailTB.Text = string.Empty;
            FinalGradeTB.Text = string.Empty;
            PersonalPhoneNumTB.Text = string.Empty;
            HomePhoneNumTB.Text = string.Empty;
            SearchEmailTB.Text = string.Empty;
            SpecificStudentPhone.Text = string.Empty;
            SearchBtn.IsEnabled = false;
            AddBtn.IsEnabled = false;
        }
    }
}