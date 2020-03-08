using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SMS
{
	class InventoryViewModel : INotifyPropertyChanged
	{
		#region private member
		private ObservableCollection<product> _products;
		private ObservableCollection<productcategory> _categories;
		private ObservableCollection<productbrand> _brands;
		private ObservableCollection<producttype> _types;
		private string _FrmVis = "Hidden";
		private string _name;
		private int _id;
		private string _upc;
		private productcategory _category;
		private productbrand _brand;
		private producttype _type;
		private string _qty;
		private string _uom;
		private int _price;
		private int _listprice;
		private bool EditMode;
		private product EditabelProduct;
		private stock Editabelstock;
		#endregion

		#region properties
		public ObservableCollection<product> Products
		{
			get { return _products; }
			set {
				_products = value;
				OnPropertyChanged("Products");
			}
		}
		public ObservableCollection<productcategory> Categories
		{
			get { return _categories; }
			set { _categories = value; OnPropertyChanged("Categories"); }
		}
		public ObservableCollection<productbrand> Brands
		{
			get { return _brands; }
			set { _brands = value; }
		}
		public ObservableCollection<producttype> Types
		{
			get { return _types; }
			set { _types = value; }
		}
		public string FrmVis
		{
			get { return _FrmVis; }
			set { _FrmVis = value; OnPropertyChanged("FrmVis"); }
		}
		public string Name
		{
			get { return _name; }
			set { _name = value; OnPropertyChanged("Name"); }
		}
		public string UPC
		{
			get { return _upc; }
			set { _upc = value; OnPropertyChanged("UPC"); }
		}
		public productcategory Category
		{
			get { return _category; }
			set { _category = value; OnPropertyChanged("Category"); }
		}
		public productbrand Brand
		{
			get { return _brand; }
			set { _brand = value; OnPropertyChanged("Brand"); }
		}
		public producttype Type
		{
			get { return _type; }
			set { _type = value; OnPropertyChanged("Type"); }
		}
		public string Qty
		{
			get { return _qty; }
			set { _qty = value; OnPropertyChanged("Qty"); }
		}
		public string UOM
		{
			get { return _uom; }
			set { _uom = value; OnPropertyChanged("Qty"); }
		}
		public int Price
		{
			get { return _price; }
			set { _price = value; OnPropertyChanged("Qty"); }
		}
		public int ListPrice
		{
			get { return _listprice; }
			set { _listprice = value; OnPropertyChanged("Qty"); }
		}
		#endregion

		#region Commands
		public ICommand AddFromCommand { get; set; }
		public ICommand SaveCommand { get; set; }
		public ICommand ClearCommand { get; set; }
		public ICommand DeleteCommand { get; set; }
		public ICommand EditCommand { get; set; }
		#endregion

		#region ctor
		public InventoryViewModel()
		{
			AddFromCommand = new RelayCommand(CanAddFrom, AddFrom);
			SaveCommand = new RelayCommand(CanAddFrom, Save);
			ClearCommand = new RelayCommand(CanAddFrom, Clear);
			EditCommand = new RelayCommand(CanAddFrom, Edit);
			DeleteCommand = new RelayCommand(CanAddFrom, Delete);
			GetInitialData();
		}
		#endregion

		#region Methods

		private void Save(object p)
		{
			if(EditMode)
			{
				Modify(p);
			}
			product pd = new product
			{
				Name = _name,
				UPC = _upc,
				productcategory = _category,
				productbrand = _brand,
				producttype =  _type,
				Price = _price,
				Qty = double.Parse(_qty)
			};
			stock s = new stock
			{
				product1 = pd,
				Qty = double.Parse(_qty),
				Price = _listprice,
				UOM = _uom
			};

			Program.entities.stocks.Add(s);
			Program.entities.products.Add(pd);
			Program.entities.SaveChanges();
			AddFrom("1");
			RefreshProduct();
			Clear();
		}

		private void Modify(object P)
		{
			EditabelProduct.Name = Name;
			EditabelProduct.UPC = UPC;
			EditabelProduct.productcategory = Category;
			EditabelProduct.productbrand = Brand;
			EditabelProduct.producttype = Type;
			EditabelProduct.Price = Price;
			Editabelstock.Price = _listprice;
			Editabelstock.UOM = _uom;
			Editabelstock.Qty = double.Parse(_qty);
			Program.entities.Entry(EditabelProduct).State = EntityState.Modified;
			Program.entities.Entry(Editabelstock).State = EntityState.Modified;
			Program.entities.SaveChanges();
			ExitModifyMode();
		}

		private void ExitModifyMode()
		{
			EditabelProduct = null;
			EditMode = false;
		}

		private void Clear(object p = null)
		{
			Name = "";
			Qty = "";
			UPC = "";
			Category = null;
			Brand = null;
			Type = null;
			Price = 0;
			ListPrice = 0;
			ExitModifyMode();
		}

		private void Edit(object p)
		{
			EditMode = true;
			EditabelProduct = p as product;
			Name = EditabelProduct.Name;
			UPC = EditabelProduct.UPC;
			Category = EditabelProduct.productcategory;
			Brand = EditabelProduct.productbrand;
			Type = EditabelProduct.producttype;
			Price = EditabelProduct.Price;
			Editabelstock = EditabelProduct.stocks;
			AddFrom("0");
		}

		private void RefreshProduct() => Products = Program.GetProducts();

		private void Delete(object p)
		{
			product pd = p as product;
			CustomDialogBox tempDB = new CustomDialogBox("Are you sure ?", DialogType.Question);
			bool? result = tempDB.ShowDialog();
			if (result == true)
			{
				Program.entities.products.Remove(pd);
				Program.entities.SaveChanges();
				RefreshProduct();
				Clear();
			}
		}

		private void GetInitialData()
		{
			_products = Program.GetProducts();
			_categories =Program.Categories;
			_brands = Program.Brands;
			_types = Program.Types;
		}

		private bool CanAddFrom(object p) => true;

		private void AddFrom(object pp)
		{
			string visibility = pp as string;
			FrmVis = visibility;
			if (visibility != "0")
				ExitModifyMode();
		}
		#endregion

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
