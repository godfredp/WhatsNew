using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsNew.Application.Models
{
	public class Announcement
	{
		public int Id { get; set; }
		public int AnnouncementType { get; set; }
		public bool IsPopup { get; set; }
		public bool IsPublished { get; set; }
		public DateTime AnnouncedDate { get; set; }
	}
}
