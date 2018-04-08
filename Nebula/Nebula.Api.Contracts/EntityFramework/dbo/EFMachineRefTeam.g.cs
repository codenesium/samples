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

		[ForeignKey("machineId")]
		public virtual EFMachine Machine { get; set; }
		[ForeignKey("teamId")]
		public virtual EFTeam Team { get; set; }
	}
}

/*<Codenesium>
    <Hash>2bef72ac4a634feb0947608db8702c78</Hash>
</Codenesium>*/