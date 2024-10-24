using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.Features;

namespace WhatsNew.Application.Models
{
	public class Feature
	{
		public int Id { get; set; }
		public int? AnnouncementId { get; set; }
		public int RoleTagId { get; set; }
		public int TopicTagId { get; set; }
		public bool IsMajor { get; set; }
		public DateTime? CreatedDate { get; set; }
		public DateTime? UpdatedDate { get;set; }
		public string Author { get; set; }
		public string Title { get; set; }

		[ForeignKey(nameof(RoleTagId))]
		public virtual RoleTag RoleTag { get; set; }

		public virtual ICollection<SubFeature> SubFeatures { get; set; }
		public virtual ICollection<FeatureGuide> FeatureGuides { get; set; } = new HashSet<FeatureGuide>();
	}
}
