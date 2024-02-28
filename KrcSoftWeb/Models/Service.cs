using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KrcSoftWeb.Models
{
	public class Service
	{
		private int _ID;

		public int ID
		{
			get { return _ID; }
			set { _ID = value; }
		}
		private string _Isim;

		public string Isim
		{
			get { return _Isim; }
			set { _Isim = value; }
		}
		private string _ServisTalepEdenMail;

		public string ServisTalepEdenMail
		{
			get { return _ServisTalepEdenMail; }
			set { _ServisTalepEdenMail = value; }
		}
		private string _ServisTalepEdenTelefon;

		public string ServisTalepEdenTelefon
		{
			get { return _ServisTalepEdenTelefon; }
			set { _ServisTalepEdenTelefon = value; }
		}

		private string _ServisKonu;

		public string ServisKonu
		{
			get { return _ServisKonu; }
			set { _ServisKonu = value; }
		}
		private string _ServisIcerik;

		public string ServisIcerik
		{
			get { return _ServisIcerik; }
			set { _ServisIcerik = value; }
		}

		private DateTime _OlusturulmaTarihi;

		public DateTime OlusturulmaTarihi
		{
			get { return _OlusturulmaTarihi; }
			set { _OlusturulmaTarihi = value; }
		}

		private bool _Durum;

		public bool Durum
		{
			get { return _Durum; }
			set { _Durum = value; }
		}
		public Service()
		{
			this.Durum = true;
		}

	}
}