using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace sample1NS.Api.Contracts
{
	[Table("MachineRefTeam", Schema="dbo")]
	public partial class MachineRefTeam
	{
		public MachineRefTeam()
		{}

		[Key]
		public int id {get; set;}
		public int machineId {get; set;}
		public int teamId {get; set;}

		[ForeignKey("machineId")]
		public virtual Machine Machine { get; set; }
		[ForeignKey("teamId")]
		public virtual Team Team { get; set; }
	}
}

/*<Codenesium>
    <Hash>e02dfc42ae248a6f839500d2f9619a59</Hash>
</Codenesium>*/