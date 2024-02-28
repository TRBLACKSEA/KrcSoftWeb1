using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KrcSoftWeb.Models
{
	public class DataModel
	{
		public bool ShowFooter = false;
		public List<Sayfa> Sayfalar = new List<Sayfa>();
		public Contact IletisimBilgileri = new Contact();
		public About Hakkimizda = new About();
		public List<References> Referanslar = new List<References>();
		public List<Sector> Sektorler = new List<Sector>();
		public List<string> SektorFiltreAdlari = new List<string>();
		public User user = new User();
		public Sayfa guncellenecekSayfa;
		public Sector guncellenecekSektor;
		public References guncellenecekReferans;
		public List<Service> servisFormlari;
		public List<ServiceSubjects> ServisFormKonulari;
		public List<EMail> gelenMailler;
		public List<OurServices> Hizmetlerimiz;
		public OurServices guncellenecekOurServices;
		public EMail okunacakMail;
		public Service okunacakServisFormu;
		public ServiceSubjects guncellenecekServisKonusu;
		public List<User> kullanıcılar;
		public User guncellenecekUser;
		public SliderItem guncellencekSliderItem;
		public List<SliderItem> sliderItems;
		public EMail cevaplanacakMail;
		public List<SendingMails> gonderilenMailler;
		public SendingMails okunacakGonderilenMail;
	}
}


