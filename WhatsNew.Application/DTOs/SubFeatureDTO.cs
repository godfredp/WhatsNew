using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsNew.Application.DTOs
{
	public class SubFeatureDTO
	{
		public int? Id { get; set; }
		public int? FeatureId { get; set; }
		public string Text { get; set; }
		public string VideoUrl { get; set; }
	}
}
