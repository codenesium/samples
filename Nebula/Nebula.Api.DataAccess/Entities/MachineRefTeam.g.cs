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
	}
}

/*<Codenesium>
    <Hash>1cde35c029ca965fc54af116430bcd37</Hash>
</Codenesium>*/