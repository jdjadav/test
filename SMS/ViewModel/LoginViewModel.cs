using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SMS
{
	class LoginViewModel : INotifyPropertyChanged
	{
		#region private members
		private string _UserName;
		private smsEntities  _smsEntities;
		private string _UserPassword;
		private string _Userlogin;
		#endregion

		#region properties
		public string UserName
		{
			get { return _UserName; }
			set
			{
				_UserName = value;
				OnPropertyChanged("UserName");
			}
		}

		public string UserPassword
		{
			get { return _UserPassword; }
			set
			{
				_UserPassword = value;
				OnPropertyChanged("UserPassword");
			}
		}

		public string Userlogin
		{
			get { return _Userlogin; }
			set
			{
				_Userlogin = value;
				OnPropertyChanged("Userlogin");
			}
		}

		#endregion

		#region Commands
		public ICommand LoginCommand;
		#endregion

		#region constructor
		public LoginViewModel()
		{
			_smsEntities = new smsEntities();
			LoginCommand = new RelayCommand(CanLogin, Login);
		}
		#endregion

		#region Methods

		public bool CanLogin(object p) => true;
		public void Login(object login)
		{
			
			try
			{
				LoginWindow window = login as LoginWindow;
				string strErrorMessage ="";
				if (string.IsNullOrWhiteSpace(UserName))
					strErrorMessage = "Please Enter Valid User Name.";
				else if (string.IsNullOrWhiteSpace(window.password.Password))
					strErrorMessage = "Please Enter Valid Password.";
				else
				{
					user _user = _smsEntities.users.Where(w => w.User_Name == UserName && window.password.Password == UserPassword).SingleOrDefault();
					if (_user != null)
						Userlogin = _user.User_Name;
					else
						strErrorMessage = "Incorrect UserName or Password.";
				}
				
				if(!string.IsNullOrWhiteSpace(strErrorMessage))
				{
					CustomDialogBox tempDB = new CustomDialogBox(strErrorMessage, DialogType.Information);
					tempDB.ShowDialog();
				}
			}
			catch (Exception ex)
			{
				System.Windows.MessageBox.Show(ex.ToString());
			}
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
