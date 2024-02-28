using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KrcSoftWeb.Models
{
	public class SliderItem
	{
		private int _ID;

		public int ID
		{
			get { return _ID; }
			set { _ID = value; }
		}
		private string _SliderTitle;

		public string SliderTitle
		{
			get { return _SliderTitle; }
			set { _SliderTitle = value; }
		}
		private string _SliderDescription;

		public string SliderDescription
		{
			get { return _SliderDescription; }
			set { _SliderDescription = value; }
		}
		private string _SliderImage;

		public string SliderImage
		{
			get { return _SliderImage; }
			set { _SliderImage = value; }
		}

	}
}