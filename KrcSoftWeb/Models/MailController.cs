using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KrcSoftWeb.Models
{
    public class MailController : Controller
    {
        AdminContext db = new AdminContext();
        DataModel dm = new DataModel();

        [HttpGet]
        public ActionResult MailSender()
        {
            GetDataModel();
            return View(dm);
        }

        [HttpPost]
        public ActionResult MailSender(EMail mail)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailFrom = new MailboxAddress(mail.GonderenMaili, mail.GonderenMaili);
            
            mimeMessage.From.Add(mailFrom);
			//MailboxAddress mailTo = new MailboxAddress("User", "sabri@krcsoft.net");
			MailboxAddress mailTo = new MailboxAddress("User", "kursat_sokmen@outlook.com");
			mimeMessage.To.Add(mailTo);
			mimeMessage.Subject = mail.Baslik;
            BodyBuilder bodyBuilder = new BodyBuilder();
            //bodyBuilder.TextBody = mail.Icerik;
            bodyBuilder.HtmlBody = mail.Icerik;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            //Burası Web sitesini kullanacak firmanın kurumsal mail ayarlarının yapıldığı yer
            //burada firmanın gmail adres yapılandırılması yapılıyor
            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("kursattsokmenn@gmail.com", "nnpvyjkvejbylnrw");
            client.Send(mimeMessage);
            client.Disconnect(true);

            mail.GonderimTarihi = DateTime.Now;
            db.EMails.Add(mail);
            db.SaveChanges();
            GetDataModel();
            return View(dm);
        }

        public void GetDataModel()
        {
            dm.Sayfalar = db.Sayfalar.Where(q => q.Kullanimdami == true).ToList();
            dm.IletisimBilgileri = db.Iletisim.FirstOrDefault();
        }
    }
}