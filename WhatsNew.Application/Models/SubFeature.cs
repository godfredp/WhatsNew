using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsNew.Application.Models
{
	public class SubFeature
	{
		public int Id { get; set; }
		public int FeatureId { get; set; }
		public string Text { get; set; }
		public string VideoUrl { get; set; }
		[ForeignKey(nameof(FeatureId))]
		public virtual Feature Feature { get; set; }
	}
}
