using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KrcSoftWeb.Models
{
	public class References
	{
		private int _ID;

		public int ID
		{
			get { return _ID; }
			set { _ID = value; }
		}

		private string _AD;

		public string AD
		{
			get { return _AD; }
			set { _AD = value; }
		}
		private string _ResimAdres;

		public string ResimAdres
		{
			get { return _ResimAdres; }
			set { _ResimAdres = value; }
		}
		private int _SektorID;

		public int SectorID
		{
			get { return _SektorID; }
			set { _SektorID = value; }
		}

		public Sector sector;

		private bool _Kullanimdami;

		public bool Kullanimdami
		{
			get { return _Kullanimdami; }
			set { _Kullanimdami = value; }
		}

	}
}