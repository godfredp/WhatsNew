using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsNew.Application.Models
{
	public class FeatureGuide
	{
		public int Id { get; set; }
		public int FeatureId { get; set; }
		public string Steps { get; set; }
	}
}
