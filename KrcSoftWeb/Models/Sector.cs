using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KrcSoftWeb.Models
{
	public class Sector
	{
		private int _ID;

		public int ID
		{
			get { return _ID; }
			set { _ID = value; }
		}

		private string _Adi;

		public string Adi
		{
			get { return _Adi; }
			set { _Adi = value; }
		}

		private string _Filtre;

		public string Filtre
		{
			get { return _Filtre; }
			set { _Filtre = value; }
		}

	}
}