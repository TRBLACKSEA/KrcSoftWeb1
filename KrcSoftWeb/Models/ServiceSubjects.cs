using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KrcSoftWeb.Models
{
	public class ServiceSubjects
	{
		private int _ID;

		public int ID
		{
			get { return _ID; }
			set { _ID = value; }
		}
		private string _KonuAdi;

		public string KonuAdi
		{
			get { return _KonuAdi; }
			set { _KonuAdi = value; }
		}

		private bool _Durumu;

		public bool Durumu
		{
			get { return _Durumu; }
			set { _Durumu = value; }
		}

	}
}