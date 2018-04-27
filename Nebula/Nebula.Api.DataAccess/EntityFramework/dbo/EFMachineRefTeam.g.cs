using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace NebulaNS.Api.DataAccess
{
	[Table("MachineRefTeam", Schema="dbo")]
	public partial class EFMachineRefTeam: AbstractEntityFrameworkPOCO
	{
		public EFMachineRefTeam()
		{}

		public void SetProperties(
			int id,
			int machineId,
			int teamId)
		{
			this.Id = id.ToInt();
			this.MachineId = machineId.ToInt();
			this.TeamId = teamId.ToInt();
		}

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("machineId", TypeName="int")]
		public int MachineId { get; set; }

		[Column("teamId", TypeName="int")]
		public int TeamId { get; set; }

		[ForeignKey("MachineId")]
		public virtual EFMachine Machine { get; set; }

		[ForeignKey("TeamId")]
		public virtual EFTeam Team { get; set; }
	}
}

/*<Codenesium>
    <Hash>1c5ebd080f7edad7c6d614a1cf783416</Hash>
</Codenesium>*/