using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SMS.ViewModel
{
	class OrderViewModel : INotifyPropertyChanged
	{
		
		public string UPC { get; set; }
		public string Name { get; set; }
		public double Price { get; set; }

		#region Commands
		public ICommand SearchCommand { get; set; }
		public ICommand SaveCommand { get; set; }
		public ICommand ClearCommand { get; set; }
		public ICommand DeleteCommand { get; set; }
		public ICommand EditCommand { get; set; }
		#endregion

		public OrderViewModel()
		{
			SearchCommand = new RelayCommand(CanSearch, Search);
		}

		public bool CanSearch(object p) => true;

		public void Search(object p)
		{
			product Product = Program.Products.First(X => X.UPC == UPC);
			Name = Product.Name;
			Price = Product.Price;
		}

		#region PropertyChanged
		public event PropertyChangedEventHandler PropertyChanged;
		void OnPropertyChanged(String PropertyName)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
		}
		private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		#endregion
	}
}
