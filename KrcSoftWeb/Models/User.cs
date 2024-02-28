using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KrcSoftWeb.Models
{
	public class User
	{
		private int _ID;

		public int ID
		{
			get { return _ID; }
			set { _ID = value; }
		}
		private string _UserName;

		public string UserName
		{
			get { return _UserName; }
			set { _UserName = value; }
		}


		private string _Password;

		public string Password
		{
			get { return _Password; }
			set { _Password = value; }
		}
		private string _UserPhoto;

		public string UserPhoto
		{
			get { return _UserPhoto; }
			set { _UserPhoto = value; }
		}

		private bool _IsAdmin;

		public bool IsAdmin
		{
			get { return _IsAdmin; }
			set { _IsAdmin = value; }
		}

		private bool _Kullanimdami;

		public bool Kullanimdami
		{
			get { return _Kullanimdami; }
			set { _Kullanimdami = value; }
		}


	}
}