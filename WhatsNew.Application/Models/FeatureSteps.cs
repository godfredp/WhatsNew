using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsNew.Application.Models
{
	public class FeatureSteps
	{
		public int Id { get; set; }
		public int FeatureGuideId { get; set; }
		public string ComponentId { get; set; }
		public string ComponentGroupId { get; set; }
		public int Rank { get; set; }
		public string TextMessage { get; set; }
		public int ActionTypeId { get; set; }
	}
}
