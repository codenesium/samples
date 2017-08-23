using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace sample1NS.Api.Contracts
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
    <Hash>18d058683a44e1560946fc2696d9b629</Hash>
</Codenesium>*/