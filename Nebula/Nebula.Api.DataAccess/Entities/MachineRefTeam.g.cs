using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace NebulaNS.Api.DataAccess
{
	[Table("MachineRefTeam", Schema="dbo")]
	public partial class MachineRefTeam : AbstractEntity
	{
		public MachineRefTeam()
		{
		}

		public virtual void SetProperties(
			int machineId,
			int teamId)
		{
			this.MachineId = machineId;
			this.TeamId = teamId;
		}

		[Key]
		[Column("machineId")]
		public virtual int MachineId { get; private set; }

		[Key]
		[Column("teamId")]
		public virtual int TeamId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>5150863930cd95d5ed81f9958944b28d</Hash>
</Codenesium>*/