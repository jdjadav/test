using MahApps.Metro.Controls;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SMS
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : MetroWindow
	{
		DataListViewModel viewModel;
		public MainWindow()
		{
			InitializeComponent();
			viewModel = new DataListViewModel();
			this.DataContext = viewModel;
		}

		private void DemoItemsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			DataListModel dataList = DemoItemsListBox.SelectedItem as DataListModel;
			if (!string.IsNullOrEmpty(dataList.Url))
			{
				Uri pageFunctionUri = new Uri("View/" + dataList.Url, UriKind.Relative);
				this.MainFrame.Navigate(pageFunctionUri);
			}
		}

		private void btnMinimized_Click(object sender, RoutedEventArgs e)
		{
			this.WindowState = WindowState.Minimized;
		}

		private void btnClose_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}

		private void UIElement_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			MenuToggleButton.IsChecked = false;
		}

	}
}
