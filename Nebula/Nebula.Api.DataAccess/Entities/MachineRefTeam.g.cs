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
			int id,
			int machineId,
			int teamId)
		{
			this.Id = id;
			this.MachineId = machineId;
			this.TeamId = teamId;
		}

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[Column("machineId")]
		public virtual int MachineId { get; private set; }

		[Column("teamId")]
		public virtual int TeamId { get; private set; }

		[ForeignKey("MachineId")]
		public virtual Machine MachineIdNavigation { get; private set; }

		public void SetMachineIdNavigation(Machine item)
		{
			this.MachineIdNavigation = item;
		}

		[ForeignKey("TeamId")]
		public virtual Team TeamIdNavigation { get; private set; }

		public void SetTeamIdNavigation(Team item)
		{
			this.TeamIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>138994bfbbf76c4b9379f25f05aad3e1</Hash>
</Codenesium>*/