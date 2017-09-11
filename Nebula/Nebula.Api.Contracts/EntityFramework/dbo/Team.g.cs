using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace NebulaNS.Api.Contracts
{
	[Table("Team", Schema="dbo")]
	public partial class Team
	{
		public Team()
		{}

		[Key]
		public int id {get; set;}
		public string name {get; set;}
		public int organizationId {get; set;}

		[ForeignKey("organizationId")]
		public virtual Organization OrganizationRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>4d7779e75ae8cac564d91322b376f319</Hash>
</Codenesium>*/