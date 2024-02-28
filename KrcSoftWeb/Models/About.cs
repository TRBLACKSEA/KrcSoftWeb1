using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KrcSoftWeb.Models
{
	public class About
	{
		private int _ID;

		public int ID
		{
			get { return _ID; }
			set { _ID = value; }
		}

		private string _Baslik;

		public string Baslik
		{
			get { return _Baslik; }
			set { _Baslik = value; }
		}

		private string _Icerik;

		public string Icerik
		{
			get { return _Icerik; }
			set { _Icerik = value; }
		}




	}
}