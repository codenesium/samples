using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace NebulaNS.Api.Contracts
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
    <Hash>16ee1ebc10c603e220dae9df4b252a7b</Hash>
</Codenesium>*/