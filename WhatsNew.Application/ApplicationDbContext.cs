using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WhatsNew.Application.Models;

namespace WhatsNew.Application
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}

		public DbSet<Announcement> Announcements { get; set; }
		public DbSet<ActionType> ActionTypes { get; set; }
		public DbSet<Feature> Features { get; set; }
		public DbSet<FeatureGuide> FeatureGuides { get; set; }
		public DbSet<FeatureSteps> FeatureSteps { get; set; }
		public DbSet<RoleGroup> RoleGroups { get; set; }
		public DbSet<RoleTag> RoleTags { get; set; }
		public DbSet<SubFeature> SubFeatures { get; set; }
		public DbSet<TopicGroup> TopicGroup { get; set; }
		public DbSet<TopicTag> TopicTags { get; set; }
		public DbSet<User> Users { get; set; }
	}
}
