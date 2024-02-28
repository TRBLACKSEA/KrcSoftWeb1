using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KrcSoftWeb.Models
{
	public class SendingMails
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

		private string _GondereninAdi;

		public string GondereninAdi
		{
			get { return _GondereninAdi; }
			set { _GondereninAdi = value; }
		}


		private string _GonderenMaili;

		public string GonderenMaili
		{
			get { return _GonderenMaili; }
			set { _GonderenMaili = value; }
		}
		private DateTime _GonderimTarihi;

		public DateTime GonderimTarihi
		{
			get { return _GonderimTarihi; }
			set { _GonderimTarihi = value; }
		}

	}
}
