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

		[ForeignKey("MachineId")]
		public virtual Machine MachineNavigation { get; private set; }

		public void SetMachineNavigation(Machine item)
		{
			this.MachineNavigation = item;
		}

		[ForeignKey("TeamId")]
		public virtual Team TeamNavigation { get; private set; }

		public void SetTeamNavigation(Team item)
		{
			this.TeamNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>76188a1b7785838e0bf8b8be3c7d54fe</Hash>
</Codenesium>*/