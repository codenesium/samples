using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace NebulaNS.Api.Contracts
{
	[Table("MachineRefTeam", Schema="dbo")]
	public partial class EFMachineRefTeam
	{
		public EFMachineRefTeam()
		{}

		[Key]
		public int id {get; set;}
		public int machineId {get; set;}
		public int teamId {get; set;}

		[ForeignKey("machineId")]
		public virtual EFMachine MachineRef { get; set; }
		[ForeignKey("teamId")]
		public virtual EFTeam TeamRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>ec6bf85463663afd8a508b556eabba1d</Hash>
</Codenesium>*/