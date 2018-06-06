using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace NebulaNS.Api.DataAccess
{
	[Table("MachineRefTeam", Schema="dbo")]
	public partial class MachineRefTeam: AbstractEntity
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
		public int Id { get; private set; }

		[Column("machineId", TypeName="int")]
		public int MachineId { get; private set; }

		[Column("teamId", TypeName="int")]
		public int TeamId { get; private set; }

		[ForeignKey("MachineId")]
		public virtual Machine Machine { get; set; }

		[ForeignKey("TeamId")]
		public virtual Team Team { get; set; }
	}
}

/*<Codenesium>
    <Hash>af611120380f79a4f73eba87b3babbe9</Hash>
</Codenesium>*/