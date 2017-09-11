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
		public virtual Machine MachineRef { get; set; }
		[ForeignKey("teamId")]
		public virtual Team TeamRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>4759edf1644231a58611cf9c1440ea2c</Hash>
</Codenesium>*/