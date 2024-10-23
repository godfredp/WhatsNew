using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsNew.Application.DTOs;
using WhatsNew.Application.Models;

namespace WhatsNew.Application.Services.Interfaces
{
	public interface IAnnouncementService
	{
		Task<Announcement> GetAnnouncementAsync(int id);
		Task<Announcement> GetCurrentAnnouncementAsync();
		Task<Announcement> CreateAnnouncementAsync(AnnouncementDTO announcement);
		Task<Announcement> UpdateAnnouncementAsync(Announcement announcement);
	}
}
