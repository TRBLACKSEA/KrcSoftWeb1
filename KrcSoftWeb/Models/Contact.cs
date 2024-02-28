using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KrcSoftWeb.Models
{
	public class Contact
	{
		private int _ID;

		public int ID
		{
			get { return _ID; }
			set { _ID = value; }
		}

		private string _Telefon;

		public string Telefon
		{
			get { return _Telefon; }
			set { _Telefon = value; }
		}
		private string _Mail;

		public string Mail
		{
			get { return _Mail; }
			set { _Mail = value; }
		}
		private string _Adres;

		public string Adres
		{
			get { return _Adres; }
			set { _Adres = value; }
		}

		private string _Twitter;

		public string Twitter
		{
			get { return _Twitter; }
			set { _Twitter = value; }
		}
		private string _Instagram;

		public string Instagram
		{
			get { return _Instagram; }
			set { _Instagram = value; }
		}

		private string _Facebook;

		public string Facebook
		{
			get { return _Facebook; }
			set { _Facebook = value; }
		}

		private string _Linkdn;

		public string Linkdn
		{
			get { return _Linkdn; }
			set { _Linkdn = value; }
		}

		private string _ServiceFormEmail;

		public string SeviceFormEmail
		{
			get { return _ServiceFormEmail; }
			set { _ServiceFormEmail = value; }
		}

		private string _MailAuthCode;

		public string MailAuthCode
		{
			get { return _MailAuthCode; }
			set { _MailAuthCode = value; }
		}

		private string _SiteTitle;

		public string SiteTitle
		{
			get { return _SiteTitle; }
			set { _SiteTitle = value; }
		}

		private string _Decription;

		public string Decription
		{
			get { return _Decription; }
			set { _Decription = value; }
		}

		private string _Keywords;

		public string Keywords
		{
			get { return _Keywords; }
			set { _Keywords = value; }
		}
		private string _Author;

		public string Author
		{
			get { return _Author; }
			set { _Author = value; }
		}


	}
}