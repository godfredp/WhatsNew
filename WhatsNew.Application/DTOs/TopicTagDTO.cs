using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsNew.Application.DTOs
{
	public class TopicTagDTO
	{
		public int Id { get; set; }
		public int TopicGroupId { get; set; }
		public string Name { get; set; }
		public string TopicGroupName { get; set; }
	}
}
