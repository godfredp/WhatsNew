using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsNew.Application.Models
{
    public class User
    {
        public int Id { get; set; }
        public int RoleTagId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? LastLoggedIn { get; set; }
        public bool IsNew { get; set; }
        public string ArcadeAuthentication { get; set; }
		[ForeignKey(nameof(RoleTagId))]
		public virtual RoleTag RoleTag { get; set; }
    }
}
