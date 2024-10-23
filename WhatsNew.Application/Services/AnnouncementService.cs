using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WhatsNew.Application.DTOs;
using WhatsNew.Application.Models;
using WhatsNew.Application.Services.Interfaces;

namespace WhatsNew.Application.Services
{
	public class AnnouncementService : IAnnouncementService
	{
		private readonly ApplicationDbContext context;
		private readonly IMapper mapper;

		public AnnouncementService(ApplicationDbContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}
		public async Task<Announcement> CreateAnnouncementAsync(AnnouncementDTO announcement)
		{
			var mappedAnnouncement = mapper.Map<Announcement>(announcement);
			await context.Announcements.AddAsync(mappedAnnouncement);
			await context.SaveChangesAsync();

			return mappedAnnouncement;
		}

		public async Task<Announcement> GetAnnouncementAsync(int id)
		{
			var announcement = await context.Announcements.FindAsync(id);
			if (announcement == null) {
				return null;
			}
			return announcement;
		}

		public async Task<Announcement> GetCurrentAnnouncementAsync()
		{
			var announcement = await context.Announcements
			.Where(x => x.AnnouncedDate <= DateTime.Now)
			.OrderByDescending(x => x.AnnouncedDate)
			.FirstOrDefaultAsync();

			//Create Filtering here

			if (announcement == null) {
				return null;
			}
			return announcement;
		}

		public async Task<Announcement> UpdateAnnouncementAsync(Announcement announcement)
		{
			var existingAnnouncement = await context.Announcements
							.Where(x => x.Id == announcement.Id)
							.FirstOrDefaultAsync();
			if (existingAnnouncement == null) {
				return null;
			}
			existingAnnouncement.AnnouncedDate = announcement.AnnouncedDate;
			existingAnnouncement.IsPopup = announcement.IsPopup;
			existingAnnouncement.IsPublished = false;

			//Add update on features

			context.Announcements.Update(existingAnnouncement);
			await context.SaveChangesAsync();
			return existingAnnouncement;
		}
	}
}
