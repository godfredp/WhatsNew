using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsNew.Application.DTOs
{
	public class UserDTO
	{
		public int Id { get; set; }
		public int RoleTagId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime? LastLoggedIn { get; set; }
		public bool IsNew { get; set; }
		public string ArcadeAuthentication { get; set; }
		public string? RoleTagName { get; set; } = string.Empty;
	}
}
