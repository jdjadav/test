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
	/// Interaction logic for LoginWindow.xaml
	/// </summary>
	public partial class LoginWindow : Window
	{
		LoginViewModel viewModel;
		public LoginWindow()
		{
			InitializeComponent();
			viewModel = new LoginViewModel();
			this.DataContext = viewModel;
		}

		private void Login_Click(object sender, RoutedEventArgs e)
		{
			viewModel.LoginCommand.Execute(this);
			if (!string.IsNullOrWhiteSpace(viewModel.Userlogin))
			{
				MainWindow m = new MainWindow();
				m.Show();
				Close();
			}
		}

		private void Close_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}
	}
}
