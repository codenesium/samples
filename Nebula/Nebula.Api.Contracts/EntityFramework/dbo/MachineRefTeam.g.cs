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
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id", TypeName="int")]
		public int Id {get; set;}
		[Column("machineId", TypeName="int")]
		public int MachineId {get; set;}
		[Column("teamId", TypeName="int")]
		public int TeamId {get; set;}

		[ForeignKey("MachineId")]
		public virtual EFMachine MachineRef { get; set; }
		[ForeignKey("TeamId")]
		public virtual EFTeam TeamRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>d4fa002f7dae6a3e8eb621d4b09e57f0</Hash>
</Codenesium>*/