using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.Features;

namespace WhatsNew.Application.Models
{
	public class RoleTag
	{
		public int Id { get; set; }
		public int RoleGroupId { get; set; }
		public string Name { get; set; }
		[ForeignKey(nameof(RoleGroupId))]
		public virtual RoleGroup RoleGroup { get; set; }
	}
}
