using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KrcSoftWeb.Models
{
	public class Sayfa
	{
		private int _ID;

		public int ID
		{
			get { return _ID; }
			set { _ID = value; }
		}

		private string _SayfaAdi;

		public string SayfaAdi
		{
			get { return _SayfaAdi; }
			set { _SayfaAdi = value; }
		}
		private string _SayfaAdresi;

		public string SayfaAdresi
		{
			get { return _SayfaAdresi; }
			set { _SayfaAdresi = value; }
		}

		private bool _Kullanimdami;

		public bool Kullanimdami
		{
			get { return _Kullanimdami; }
			set { _Kullanimdami = value; }
		}

		private string _AdminPanelLink;

		public string  AdminPanelLink
		{
			get { return _AdminPanelLink; }
			set { _AdminPanelLink = value; }
		}

	}
}