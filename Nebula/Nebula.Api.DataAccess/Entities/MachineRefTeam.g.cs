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
		public int MachineId { get; private set; }

		[Key]
		[Column("teamId")]
		public int TeamId { get; private set; }

		[ForeignKey("MachineId")]
		public virtual Machine MachineNavigation { get; private set; }

		[ForeignKey("TeamId")]
		public virtual Team TeamNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>6fdd852f9eac1a5f78001901b7b8a87d</Hash>
</Codenesium>*/