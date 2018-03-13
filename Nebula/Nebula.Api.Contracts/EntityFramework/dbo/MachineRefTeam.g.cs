using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
    <Hash>466ce537aa67546de75d48af1cd87378</Hash>
</Codenesium>*/