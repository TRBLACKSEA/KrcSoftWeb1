using KrcSoftWeb.Models;
using KrcSoftWeb.Tools;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace KrcSoftWeb.Controllers
{
    
    public class HomeController : Controller
    {
        private static AdminContext db = new AdminContext();
        public static DataModel dataModel = new DataModel();
        public HomeController()
		{
            db.Database.CreateIfNotExists();
            GetDataModel();

		}
		public static void GetDataModel()
		{
            dataModel.Sayfalar = db.Sayfalar.Where(q => q.Kullanimdami == true).ToList();
            dataModel.IletisimBilgileri = db.Iletisim.FirstOrDefault();
        }
        public ActionResult Index()
        {
            dataModel.sliderItems = db.SliderItems.ToList();
            GetDataModel();
            dataModel.ShowFooter = false;
            return View(dataModel);
        }

        public ActionResult About()
		{
            GetDataModel();
            dataModel.Hakkimizda  = db.Hakkimizda.FirstOrDefault();
            dataModel.ShowFooter = true;
            return View(dataModel);
		}
        [HttpGet]
        public ActionResult Services()
		{
            dataModel.Hizmetlerimiz = db.Hizmetlerimiz.ToList();
            GetDataModel();
            dataModel.ShowFooter = true;
            return View(dataModel);
		}
        [HttpPost]
        public ActionResult Services(OurServices ourServices)
		{
            
            GetDataModel();
            dataModel.ShowFooter = true;
            return View(dataModel);
		}

        public ActionResult References()
		{
            GetDataModel();
            dataModel.Sektorler = db.Sektor.ToList();
            dataModel.Referanslar = db.Referanslar.Where(q => q.Kullanimdami == true).ToList();
			foreach (var item in dataModel.Referanslar)
			{
                Sector sector = dataModel.Sektorler.Where(q => q.ID == item.SectorID).FirstOrDefault();
                string filtreAdi = sector.Filtre;
                dataModel.SektorFiltreAdlari.Add(filtreAdi);
			}
            dataModel.ShowFooter = true;
            return View(dataModel);
		}
        [HttpGet]
        public ActionResult Contact()
		{
            GetDataModel();
            dataModel.ShowFooter = true;
            return View(dataModel);
		}
        [HttpPost]
        public ActionResult Contact(EMail mail)
		{
            CustomTool.SendMail(mail, dataModel, ViewBag);
            
            
            GetDataModel();
            return View(dataModel);
        }

        [HttpGet]
        public ActionResult ServiceForm()
		{
            dataModel.ServisFormKonulari = db.ServiceSubjects.Where(q => q.Durumu == true).ToList();
            GetDataModel();
            return View(dataModel);
		}
        [HttpPost]
        public ActionResult ServiceForm(Service service)
        {
            CustomTool.SendServiceForm(service, dataModel, ViewBag);
            GetDataModel();
            return View(dataModel);
        }
    }
}