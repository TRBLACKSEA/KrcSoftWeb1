using KrcSoftWeb.Models;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KrcSoftWeb.Tools
{
	public static class CustomTool
	{
		public static void SendMail(EMail mail, DataModel dataModel, dynamic _ViewBag)
		{

			AdminContext context = new AdminContext();

			MimeMessage mimeMessage = new MimeMessage();
			MailboxAddress mailFrom = new MailboxAddress(mail.GondereninAdi, mail.GonderenMaili);

			mimeMessage.From.Add(mailFrom);
			//MailboxAddress mailTo = new MailboxAddress("User", "sabri@krcsoft.net");
			MailboxAddress mailTo = new MailboxAddress("User", dataModel.IletisimBilgileri.Mail);
			mimeMessage.To.Add(mailTo);
			mimeMessage.Subject = mail.Baslik;
			BodyBuilder bodyBuilder = new BodyBuilder();
			//bodyBuilder.TextBody = mail.Icerik;
			bodyBuilder.HtmlBody = mail.Icerik;
			mimeMessage.Body = bodyBuilder.ToMessageBody();

			//Burası Web sitesini kullanacak firmanın kurumsal mail ayarlarının yapıldığı yer
			//burada firmanın gmail adres yapılandırılması yapılıyor
			SmtpClient client = new SmtpClient();
			client.Connect("smtp.gmail.com", 465, true);

			client.Authenticate("mailadress", dataModel.IletisimBilgileri.MailAuthCode);
			try
			{
				client.Send(mimeMessage);
				_ViewBag.Mesaj = "Mesajınız İletilmiştir,En Kısa Zamanda Size Dönüş Yapacağız.";
				mail.GonderimTarihi = DateTime.Now;
				context.EMails.Add(mail);
				context.SaveChanges();
			}
			catch (Exception ex)
			{
				_ViewBag.Mesaj = "Mesajınız Gönderilemedi:" + ex.ToString();
			}
			client.Disconnect(true);
		}
		public static void SendServiceForm(Service service, DataModel dataModel, dynamic _ViewBag)
		{

			AdminContext context = new AdminContext();

			MimeMessage mimeMessage = new MimeMessage();
			MailboxAddress mailFrom = new MailboxAddress(service.Isim, service.ServisTalepEdenMail);

			//mailFrom.Address = service.ServisTalepEdenMail;
			mimeMessage.Sender = mailFrom;
			mimeMessage.From.Add(mailFrom);
			//MailboxAddress mailTo = new MailboxAddress("User", "sabri@krcsoft.net");
			MailboxAddress mailTo = new MailboxAddress(dataModel.IletisimBilgileri.SeviceFormEmail, dataModel.IletisimBilgileri.SeviceFormEmail);
			mimeMessage.To.Add(mailTo);
			mimeMessage.Subject = service.ServisKonu;

			BodyBuilder bodyBuilder = new BodyBuilder();
			//bodyBuilder.TextBody = service.ServisIcerik;
			bodyBuilder.HtmlBody = service.ServisIcerik;
			mimeMessage.Body = bodyBuilder.ToMessageBody();

			//Burası Web sitesini kullanacak firmanın kurumsal mail ayarlarının yapıldığı yer
			//burada firmanın gmail adres yapılandırılması yapılıyor
			SmtpClient client = new SmtpClient();
			//client.Connect("smtp.gmail.com", 587, false);
			client.Connect("smtp.gmail.com", 465, true);

			client.Authenticate("mailadress", dataModel.IletisimBilgileri.MailAuthCode);
			try
			{
				client.Send(mimeMessage);
				_ViewBag.Mesaj = "Servis Talebiniz İletilmiştir,En Kısa Zamanda Size Dönüş Yapacağız.";
				service.OlusturulmaTarihi = DateTime.Now;
				context.ServiceForms.Add(service);
				context.SaveChanges();
			}
			catch (Exception ex)
			{
				_ViewBag.Mesaj = "Servis Talebi Oluşturulamadı:" + ex.ToString();
			}
			client.Disconnect(true);
		}
		public static void SendMailFromUs(EMail mail, DataModel dataModel, dynamic _ViewBag)
		{

			AdminContext context = new AdminContext();

			MimeMessage mimeMessage = new MimeMessage();
			MailboxAddress mailFrom = new MailboxAddress(dataModel.IletisimBilgileri.SiteTitle.ToUpper(), dataModel.IletisimBilgileri.Mail);

			mimeMessage.From.Add(mailFrom);
			//MailboxAddress mailTo = new MailboxAddress("User", "sabri@krcsoft.net");
			MailboxAddress mailTo = new MailboxAddress("User", mail.GonderenMaili);
			mimeMessage.To.Add(mailTo);
			mimeMessage.Subject = mail.Baslik;
			BodyBuilder bodyBuilder = new BodyBuilder();
			//bodyBuilder.TextBody = mail.Icerik;
			bodyBuilder.HtmlBody = mail.Icerik;
			mimeMessage.Body = bodyBuilder.ToMessageBody();

			//Burası Web sitesini kullanacak firmanın kurumsal mail ayarlarının yapıldığı yer
			//burada firmanın gmail adres yapılandırılması yapılıyor
			SmtpClient client = new SmtpClient();
			client.Connect("smtp.gmail.com", 465, true);

			client.Authenticate("mailadress", dataModel.IletisimBilgileri.MailAuthCode);
			try
			{
				client.Send(mimeMessage);
				_ViewBag.Mesaj = "Mesajınız İletilmiştir,En Kısa Zamanda Size Dönüş Yapacağız.";
				mail.GonderimTarihi = DateTime.Now;
			}
			catch (Exception ex)
			{
				_ViewBag.Mesaj = "Mesajınız Gönderilemedi:" + ex.ToString();
			}
			client.Disconnect(true);
		}
	}
}