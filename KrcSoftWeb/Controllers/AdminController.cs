using KrcSoftWeb.Models;
using KrcSoftWeb.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KrcSoftWeb.Controllers
{
	public class AdminController : Controller
	{
		private AdminContext db = new AdminContext();
		public static DataModel dm = new DataModel();
		[Authorize]
		[HttpGet]
		public ActionResult Index()
		{
			dm.gelenMailler = db.EMails.ToList();
			dm.gonderilenMailler = db.GonderilenMailler.ToList();
			dm.sliderItems = db.SliderItems.ToList();
			dm.servisFormlari = db.ServiceForms.ToList();
			GetAdmin();
			return View(dm);
		}
		[HttpGet]
		public ActionResult CreateNewPage()
		{
			GetAdmin();
			return View(dm);
		}
		[HttpPost]
		public ActionResult CreateNewPage(Sayfa sayfa)
		{
			if (!string.IsNullOrEmpty(sayfa.SayfaAdi))
			{
				sayfa.SayfaAdresi = "/Home/" + sayfa.SayfaAdi;
				string s = Request.Form["Kullanimdami"];
				if (s == "true")
				{
					sayfa.Kullanimdami = true;
				}
				else
				{
					sayfa.Kullanimdami = false;
				}
				db.Sayfalar.Add(sayfa);
				db.SaveChanges();
			}
			GetAdmin();
			return RedirectToAction("CreateNewPage", "Admin");
		}
		[HttpGet]
		public ActionResult UpdatePage(int ID)
		{
			Sayfa gunncellenecekpage = db.Sayfalar.FirstOrDefault(q => q.ID == ID);
			dm.guncellenecekSayfa = gunncellenecekpage;
			GetAdmin();
			return View(dm);
		}

		[HttpPost]
		public ActionResult UpdatePage(Sayfa page)
		{
			Sayfa sayfa = db.Sayfalar.Where(q => q.ID == page.ID).FirstOrDefault();
			sayfa.SayfaAdi = page.SayfaAdi;
			sayfa.Kullanimdami = page.Kullanimdami;
			db.SaveChanges();
			GetAdmin();
			return RedirectToAction("CreateNewPage", "Admin", dm);
		}
		[HttpPost]
		public ActionResult CreateNewSector(Sector sector)
		{
			if (!string.IsNullOrEmpty(sector.Adi))
			{
				sector.Filtre = "filter-" + sector.Adi.ToLower();
				GetAdmin();
				db.Sektor.Add(sector);
				db.SaveChanges();
				dm.Sektorler = db.Sektor.ToList();
			}
			return RedirectToAction("Sectors", "Admin", dm);
		}
		public ActionResult Sectors()
		{
			GetAdmin();
			dm.Sektorler = db.Sektor.ToList();
			return View(dm);
		}
		[HttpGet]
		public ActionResult UpdateSector(int ID)
		{
			Sector sector = db.Sektor.Where(q => q.ID == ID).FirstOrDefault();
			dm.guncellenecekSektor = sector;
			GetAdmin();
			return View(dm);
		}

		[HttpPost]
		public ActionResult UpdateSector(Sector sector)
		{
			Sector _sector = db.Sektor.Where(q => q.ID == sector.ID).FirstOrDefault();
			_sector.Adi = sector.Adi;
			_sector.Filtre = "filter-" + sector.Adi.Trim().ToLower();
			db.SaveChanges();
			return RedirectToAction("Sectors", "Admin");
		}

		[HttpGet]
		public ActionResult EditAbout()
		{
			dm.Hakkimizda = db.Hakkimizda.Where(q => q.ID == 1).FirstOrDefault();
			GetAdmin();
			return View(dm);
		}
		[HttpPost]
		public ActionResult EditAbout(About about)
		{
			About guncellencekAbout = db.Hakkimizda.Where(q => q.ID == 1).FirstOrDefault();
			guncellencekAbout.Baslik = about.Baslik;
			guncellencekAbout.Icerik = about.Icerik;
			db.SaveChanges();
			ViewBag.EditAboutMesaj = "Hakkımızda Sayfası Güncellendi";
			dm.Hakkimizda = db.Hakkimizda.Where(q => q.ID == 1).FirstOrDefault();
			GetAdmin();
			return View(dm);
		}

		[HttpGet]
		public ActionResult EditOurServices()
		{
			dm.Hizmetlerimiz = db.Hizmetlerimiz.ToList();
			GetAdmin();
			return View(dm);
		}
		[HttpPost]
		public ActionResult EditOurServices(OurServices ourServices)
		{
			if (Request.Files.Count > 0 && !string.IsNullOrEmpty(ourServices.ServiceTitle))
			{
				string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
				string uzanti = Path.GetExtension(Request.Files[0].FileName);
				string yol = "/OurServicesImages/" + dosyaAdi;
				//if (!System.IO.File.Exists(yol))
				//{
				//	Request.Files[0].SaveAs(Server.MapPath(yol));
				//}
				Request.Files[0].SaveAs(Server.MapPath(yol));
				ourServices.ServiceImage = yol;

				db.Hizmetlerimiz.Add(ourServices);
				db.SaveChanges();
				dm.Hizmetlerimiz = db.Hizmetlerimiz.ToList();

				ViewBag.EditOurServicesMesaj = "Hizmet Eklendi";
			}
			GetAdmin();
			return View(dm);
		}


		[HttpGet]
		public ActionResult EditReferences()
		{
			dm.Referanslar = db.Referanslar.ToList();
			dm.Sektorler = db.Sektor.ToList();
			GetAdmin();
			return View(dm);
		}

		[HttpPost]
		public ActionResult EditReferences(References reference)
		{
			if (Request.Files.Count > 0 && !string.IsNullOrEmpty(reference.AD))
			{
				string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
				string uzanti = Path.GetExtension(Request.Files[0].FileName);

				string yol = "/References/" + dosyaAdi;
				Request.Files[0].SaveAs(Server.MapPath(yol));
				reference.ResimAdres = yol;
				reference.sector = db.Sektor.Where(q => q.ID == reference.SectorID).FirstOrDefault();

				db.Referanslar.Add(reference);
				db.SaveChanges();
				dm.Referanslar = db.Referanslar.Where(q => q.Kullanimdami == true).ToList();
				dm.Sektorler = db.Sektor.ToList();
			}

			GetAdmin();
			return View(dm);
		}
		[HttpGet]
		public ActionResult UpdateOurServices(int ID)
		{

			dm.guncellenecekOurServices = db.Hizmetlerimiz.Where(q => q.ID == ID).FirstOrDefault();
			dm.guncellenecekOurServices.ID = ID;
			GetAdmin();
			return View(dm);
		}
		[HttpPost]
		public ActionResult UpdateOurServices(OurServices ourServices)
		{
			OurServices guncellenecekOurService = db.Hizmetlerimiz.Where(q => q.ID == ourServices.ID).FirstOrDefault();
			guncellenecekOurService.ServiceTitle = ourServices.ServiceTitle;
			guncellenecekOurService.ServiceDescription = ourServices.ServiceDescription;

			if (Request.Files.Count > 0 && string.IsNullOrEmpty(Path.GetFileName(Request.Files[0].FileName)))
			{
				string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
				string uzanti = Path.GetExtension(Request.Files[0].FileName);
				string yol = "/OurServicesImages/" + dosyaAdi;
				FileInfo file = new FileInfo(yol);

				if (!file.Exists && !string.IsNullOrEmpty(dosyaAdi))
				{
					Request.Files[0].SaveAs(Server.MapPath(yol));
				}
				else if (!string.IsNullOrEmpty(dosyaAdi))
				{
					ourServices.ServiceImage = yol;
				}

			}
			else
			{
				guncellenecekOurService.ServiceImage = ourServices.ServiceImage;
			}
			db.SaveChanges();
			dm.Hizmetlerimiz = db.Hizmetlerimiz.ToList();
			ViewBag.UpdateOurServiceMessage = "Hizmet Güncellendi";
			GetAdmin();
			return View(dm);
		}
		[HttpGet]
		public ActionResult OurServices()
		{
			dm.ServisFormKonulari = db.ServiceSubjects.ToList();
			GetAdmin();
			return View(dm);
		}
		[HttpPost]
		public ActionResult OurServices(ServiceSubjects subject)
		{
			subject.Durumu = true;
			db.ServiceSubjects.Add(subject);
			db.SaveChanges();
			dm.ServisFormKonulari = db.ServiceSubjects.ToList();
			GetAdmin();
			return View(dm);
		}
		[HttpGet]
		public ActionResult UpdateServiceSubjects(int ID)
		{
			dm.guncellenecekServisKonusu = db.ServiceSubjects.Where(q => q.ID == ID).FirstOrDefault();
			GetAdmin();
			return View(dm);
		}
		[HttpPost]
		public ActionResult UpdateServiceSubjects(ServiceSubjects serviceSubject)
		{
			ServiceSubjects _serviceSubjects = db.ServiceSubjects.Where(q => q.ID == serviceSubject.ID).FirstOrDefault();
			_serviceSubjects.KonuAdi = serviceSubject.KonuAdi;
			serviceSubject.Durumu = serviceSubject.Durumu;
			db.SaveChanges();
			ViewBag.UpdateServiceSubjectsMessage = "Servis Konusu Güncellendi";
			GetAdmin();
			return View(dm);
		}

		[HttpGet]
		public ActionResult UpdateReferences(int ID)
		{
			dm.guncellenecekReferans = db.Referanslar.Where(q => q.ID == ID).FirstOrDefault();
			dm.guncellenecekReferans.sector = db.Sektor.Where(q => q.ID == dm.guncellenecekReferans.SectorID).FirstOrDefault();
			GetAdmin();
			return View(dm);
		}
		[HttpPost]
		public ActionResult UpdateReferences(References reference)
		{
			References references1 = db.Referanslar.Where(q => q.ID == reference.ID).FirstOrDefault();
			if (Request.Files.Count > 0 && !string.IsNullOrEmpty(Request.Files[0].FileName))
			{
				string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
				string uzanti = Path.GetExtension(Request.Files[0].FileName);
				string yol = "/References/" + dosyaAdi;
				references1.ResimAdres = yol;
			}
			
			
			references1.Kullanimdami = reference.Kullanimdami;
			references1.sector = db.Sektor.Where(q => q.ID == reference.SectorID).FirstOrDefault();
			references1.SectorID = reference.SectorID;
			
			db.SaveChanges();
			return RedirectToAction("EditReferences", "Admin",dm);
		}
		[HttpGet]
		public ActionResult EditContact()
		{
			GetAdmin();
			return View(dm);
		}
		[HttpPost]
		public ActionResult EditContact(Contact contact)
		{
			Contact guncellenecekContact = db.Iletisim.Where(q => q.ID == 1).FirstOrDefault();
			guncellenecekContact.Telefon = contact.Telefon;
			guncellenecekContact.Mail = contact.Mail;
			guncellenecekContact.Adres = contact.Adres;
			guncellenecekContact.SeviceFormEmail = contact.SeviceFormEmail;
			guncellenecekContact.Twitter = contact.Twitter;
			guncellenecekContact.Facebook = contact.Facebook;
			guncellenecekContact.Instagram = contact.Instagram;
			guncellenecekContact.Linkdn = contact.Linkdn;
			db.SaveChanges();
			ViewBag.EditAboutMesaj = "İletişim Bilgileri Güncellendi";
			GetAdmin();
			return View(dm);
		}

		[HttpGet]
		public ActionResult IncomingMails()
		{
			dm.gelenMailler = db.EMails.ToList();
			GetAdmin();
			return View(dm);
		}

		[HttpGet]
		public ActionResult AnswerIncomingMails(int ID)
		{
			dm.cevaplanacakMail = db.EMails.Where(q => q.ID == ID).FirstOrDefault();
			GetAdmin();
			return View(dm);
		}
		[HttpPost]
		public ActionResult AnswerIncomingMails(EMail mail)
		{
			mail.GonderenMaili = db.Iletisim.Where(q => q.ID == 1).FirstOrDefault().Mail;
			mail.GonderimTarihi = DateTime.Now;
			CustomTool.SendMailFromUs(mail, dm, ViewBag);
			ViewBag.Mesaj = "Mesajınız İletildi";
			SendingMails sendingMail = new SendingMails()
			{
				GondereninAdi = mail.GondereninAdi,
				Baslik = mail.Baslik,
				Icerik = mail.Icerik,
				GonderenMaili = mail.GonderenMaili,
				GonderimTarihi = mail.GonderimTarihi
			};
			db.GonderilenMailler.Add(sendingMail);
			db.SaveChanges();
			GetAdmin();
			return View(dm);
		}

		[HttpGet]
		public ActionResult SendMailsFromUs()
		{
			dm.gonderilenMailler = db.GonderilenMailler.ToList();
			GetAdmin();
			return View(dm);
		}
		[HttpGet]
		public ActionResult ReadSendingMails(int ID)
		{
			dm.okunacakGonderilenMail = db.GonderilenMailler.Where(q => q.ID == ID).FirstOrDefault();
			GetAdmin();
			return View(dm);
		}
		[HttpGet]
		public ActionResult CommonSettings()
		{
			GetAdmin();
			return View(dm);
		}
		[HttpPost]
		public ActionResult CommonSettings(string _SiteTitle, string _Decription, string _Keywords, string _Author)
		{
			Contact contact = db.Iletisim.Where(q => q.ID == 1).FirstOrDefault();
			contact.SiteTitle = _SiteTitle;
			contact.Decription = _Decription;
			contact.Keywords = _Keywords;
			contact.Author = _Author;
			db.SaveChanges();
			ViewBag.CommonSettingsMesssage = "Genel Ayarlar Güncellendi";
			GetAdmin();
			return View(dm);
		}

		[HttpGet]
		public ActionResult ServiceForms()
		{
			dm.servisFormlari = db.ServiceForms.ToList();
			GetAdmin();
			return View(dm);
		}

		[HttpGet]
		public ActionResult ReadIncomingMails(int ID)
		{
			dm.okunacakMail = db.EMails.Where(q => q.ID == ID).FirstOrDefault();
			GetAdmin();
			return View(dm);
		}
		[HttpGet]
		public ActionResult ReadServiceForms(int ID)
		{
			dm.okunacakServisFormu = db.ServiceForms.Where(q => q.ID == ID).FirstOrDefault();
			GetAdmin();
			return View(dm);
		}

		[HttpGet]
		public ActionResult EditUsers()
		{
			dm.kullanıcılar = db.Users.ToList();
			GetAdmin();
			return View(dm);
		}
		[HttpGet]
		public ActionResult UpdateUser(int ID)
		{
			dm.guncellenecekUser = db.Users.Where(q => q.ID == ID).FirstOrDefault();

			GetAdmin();
			return View(dm);
		}
		[HttpPost]
		public ActionResult EditUsers(User user)
		{
			db.Users.Add(user);
			db.SaveChanges();
			dm.kullanıcılar = db.Users.ToList();


			GetAdmin();
			return View(dm);
		}
		[HttpPost]
		public ActionResult UpdateUser(User user)
		{
			User _user = db.Users.Where(q => q.ID == user.ID).FirstOrDefault();
			_user.UserName = user.UserName;
			_user.Password = user.Password;
			_user.UserPhoto = user.UserPhoto;
			_user.Kullanimdami = user.Kullanimdami;
			_user.IsAdmin = user.IsAdmin;
			db.SaveChanges();
			GetAdmin();
			return RedirectToAction("EditUsers", "Admin", dm);
		}

		[HttpGet]
		public ActionResult SliderEdit()
		{
			dm.sliderItems = db.SliderItems.ToList();
			GetAdmin();
			return View(dm);
		}	
		[HttpPost]
		public ActionResult SliderEdit(SliderItem sliderItem)
		{
			if (Request.Files.Count > 0)
			{
				string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
				string uzanti = Path.GetExtension(Request.Files[0].FileName);
				string yol = "/Slider/" + dosyaAdi;
				Request.Files[0].SaveAs(Server.MapPath(yol));
				sliderItem.SliderImage = yol;


			}
			//sliderItem.SliderImage = "/Slider/" + sliderItem.SliderImage;
			db.SliderItems.Add(sliderItem);
			db.SaveChanges();

			ViewBag.Mesaj = "Slider Eklendi";
			GetAdmin();
			return RedirectToAction("SliderEdit","Admin",dm);
		}

		[HttpGet]
		public ActionResult UpdateSliderItem(int ID)
		{
			dm.guncellencekSliderItem = db.SliderItems.Where(q => q.ID == ID).FirstOrDefault();
			GetAdmin();
			return View(dm);
		}
		[HttpPost]
		public ActionResult UpdateSliderItem(SliderItem sliderItem)
		{
			SliderItem guncellenecek = db.SliderItems.Where(q => q.ID == sliderItem.ID).FirstOrDefault();
			guncellenecek.SliderTitle = sliderItem.SliderTitle;
			guncellenecek.SliderDescription = sliderItem.SliderDescription;
			if (Request.Files.Count > 0 && !string.IsNullOrEmpty(Request.Files[0].FileName))
			{
				string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
				string uzanti = Path.GetExtension(Request.Files[0].FileName);
				string yol = "/Slider/" + dosyaAdi;
				Request.Files[0].SaveAs(Server.MapPath(yol));
				guncellenecek.SliderImage = yol;
			}

			db.SaveChanges();
			ViewBag.Mesaj = "Slider Güncellendi";
			GetAdmin();
			return View(dm);
		}
		
		public void GetAdmin()
		{
			dm.Sayfalar = db.Sayfalar.ToList();
			dm.IletisimBilgileri = db.Iletisim.FirstOrDefault();
		}
	}
}