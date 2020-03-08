using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS
{
	public class Program
	{
		public readonly static smsEntities entities =  new smsEntities();
		private static ObservableCollection<product> _products;
		private static ObservableCollection<productcategory> _categories;
		private static ObservableCollection<productbrand> _brands;
		private static ObservableCollection<producttype> _types;
		public static ObservableCollection<product> Products
		{
			get { return _products; }
			set { _products = value; }
		}
		public static  ObservableCollection<productcategory> Categories
		{
			get { return _categories; }
			set { _categories = value; }
		}
		public static ObservableCollection<productbrand> Brands
		{
			get { return _brands; }
			set { _brands = value; }
		}
		public static ObservableCollection<producttype> Types
		{
			get { return _types; }
			set { _types = value; }
		}
		public Program()
		{
			GetData();
		}
		public static ObservableCollection<product> GetProducts()
		{
			var items = from item in entities.products select item;
			if (items != null)
				return new ObservableCollection<product>(items.ToList());
			else
				return new ObservableCollection<product>();
		}
		private void GetData()
		{
			_products = GetProducts();
			var categories = from item in entities.productcategories select item;
			if (categories != null)
			{
				_categories = new ObservableCollection<productcategory>(categories.ToList());
			}

			var brands = from item in entities.productbrands select item;
			if (brands != null)
			{
				_brands = new ObservableCollection<productbrand>(brands.ToList());
			}

			var types = from item in entities.producttypes select item;
			if (types != null)
			{
				_types = new ObservableCollection<producttype>(types.ToList());
			}
		}
	}
}
