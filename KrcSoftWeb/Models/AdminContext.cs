using KrcSoftWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KrcSoftWeb.Models
{
	public class AdminContext : DbContext
	{
		public AdminContext() : base("AdminDB")
		{

		}
		public DbSet<Sayfa> Sayfalar { get; set; }
		public DbSet<Contact> Iletisim { get; set; }
		public DbSet<About> Hakkimizda { get; set; }
		public DbSet<References> Referanslar { get; set; }
		public DbSet<Sector> Sektor { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<EMail> EMails { get; set; }
		public DbSet<Service> ServiceForms { get; set; }
		public DbSet<ServiceSubjects> ServiceSubjects { get; set; }
		public DbSet<OurServices> Hizmetlerimiz { get; set; }
		public DbSet<SliderItem> SliderItems { get; set; }
		public DbSet<SendingMails> GonderilenMailler { get; set; }
		
	}
}