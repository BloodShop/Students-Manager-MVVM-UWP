using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Networking;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace StudentsContainer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            FirstNameTB.Text = string.Empty;
            LastNameTB.Text = string.Empty;
            EmailTB.Text = string.Empty;
            FinalGradeTB.Text = string.Empty;
            PersonalPhoneNumTB.Text = string.Empty;
            HomePhoneNumTB.Text = string.Empty;
            SearchEmailTB.Text = string.Empty;
            SpecificStudentPhone.Text = string.Empty;
        }
    }
}
