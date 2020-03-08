using System;
using System.Data;
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
using System.Collections.ObjectModel;

namespace SMS.View
{
	/// <summary>
	/// Interaction logic for InventoryView.xaml
	/// </summary>
	public partial class InventoryView : Page
	{
		InventoryViewModel viewModel;
		public InventoryView()
		{
			InitializeComponent();
			viewModel = new InventoryViewModel();
			this.DataContext = viewModel;
		}

		private void BtEdit_Click(object sender, RoutedEventArgs e)
		{
			product p = grdProducts.SelectedItem as product;
			viewModel.EditCommand.Execute(p);
		}

		private void BtnDelete_Click(object sender, RoutedEventArgs e)
		{
			product p = grdProducts.SelectedItem as product;
			viewModel.DeleteCommand.Execute(p);
		}

		private void GrdProducts_Initialized(object sender, EventArgs e)
		{
			grdProducts.Items.Refresh();
		}
	}
}
