using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace NebulaNS.Api.DataAccess
{
	[Table("MachineRefTeam", Schema="dbo")]
	public partial class MachineRefTeam: AbstractEntityFrameworkDTO
	{
		public MachineRefTeam()
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
		public virtual Machine Machine { get; set; }

		[ForeignKey("TeamId")]
		public virtual Team Team { get; set; }
	}
}

/*<Codenesium>
    <Hash>3ed1cd01559486700ae58c6b533e65eb</Hash>
</Codenesium>*/