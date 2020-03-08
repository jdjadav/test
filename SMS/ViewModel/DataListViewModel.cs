using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS
{
	class DataListViewModel
	{
		public DataListViewModel()
		{
			FillData();
		}
		private List<DataListModel>_DataList;
		public List<DataListModel> DataList
		{
			get { return _DataList; }
			set { _DataList = value; }
		}
		void FillData()
		{
			DataList = new List<DataListModel>();
			DataList.Add(new DataListModel { Name = "Inventory", icon = "AccountBalanceWallet", Url = "InventoryView.xaml" });
			DataList.Add(new DataListModel { Name = "Order", icon = "AccountCardDetails", Url = "OrderView.xaml" });
		}
	}
}
