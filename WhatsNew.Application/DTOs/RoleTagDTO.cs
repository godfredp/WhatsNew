using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsNew.Application.DTOs
{
	public class RoleTagDTO
	{
		public int Id { get; set; }
		public int RoleGroupId { get; set; }
		public string Name { get; set; }
		public string RoleGroupName { get; set; }
	}
}
