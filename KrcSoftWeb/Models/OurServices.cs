using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KrcSoftWeb.Models
{
	public class OurServices
	{
		private int _ID;

		public int ID
		{
			get { return _ID; }
			set { _ID = value; }
		}
		private string _ServiceTitle;

		public string ServiceTitle
		{
			get { return _ServiceTitle; }
			set { _ServiceTitle = value; }
		}
		private string _ServiceImage;

		public string ServiceImage
		{
			get { return _ServiceImage; }
			set { _ServiceImage = value; }
		}
		private string _ServiceDescription;

		public string ServiceDescription
		{
			get { return _ServiceDescription; }
			set { _ServiceDescription = value; }
		}

	}
}