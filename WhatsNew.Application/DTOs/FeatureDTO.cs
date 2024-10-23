using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsNew.Application.Models;

namespace WhatsNew.Application.DTOs
{
	public class FeatureDTO
	{
		public int? Id { get; set; }
		public int? AnnouncementId { get; set; }
		public int RoleTagId { get; set; }
		public int TopicTagId { get; set; }
		public bool IsMajor { get; set; }
		public DateTime? CreatedDate { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public string Author { get; set; }

		public string RoleTagName { get; set; }
		public string TopicTagName { get; set; }

		public List<SubFeatureDTO> SubFeatures { get; set; }
		public List<FeatureGuideDTO> FeatureGuides { get; set; }

		public FeatureDTO()
		{
			SubFeatures = new List<SubFeatureDTO>();
			FeatureGuides = new List<FeatureGuideDTO>();
		}
	}
}
