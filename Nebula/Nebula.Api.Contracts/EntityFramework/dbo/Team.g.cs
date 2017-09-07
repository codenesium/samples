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
		public virtual Organization Organization { get; set; }
	}
}

/*<Codenesium>
    <Hash>734392fcf7facbd73b04612d65502767</Hash>
</Codenesium>*/