using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsNew.Application.Models
{
	public class TopicTag
	{
		public int Id { get; set; }
		public int TopicGroupId { get; set; }
		public string Name { get; set; }
		[ForeignKey(nameof(TopicGroupId))]
		public virtual TopicGroup TopicGroup { get; set; }
	}
}
