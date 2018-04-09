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

		public virtual EFMachine Machine { get; set; }

		public virtual EFTeam Team { get; set; }
	}
}

/*<Codenesium>
    <Hash>cc7562890c455581dc57348cbc6dbffb</Hash>
</Codenesium>*/