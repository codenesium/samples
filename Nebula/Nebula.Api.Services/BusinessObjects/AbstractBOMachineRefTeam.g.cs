using Codenesium.DataConversionExtensions;
using System;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractBOMachineRefTeam : AbstractBusinessObject
	{
		public AbstractBOMachineRefTeam()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  int machineId,
		                                  int teamId)
		{
			this.Id = id;
			this.MachineId = machineId;
			this.TeamId = teamId;
		}

		public int Id { get; private set; }

		public int MachineId { get; private set; }

		public int TeamId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>8091fa75a64cba14e31ab0a07e68814f</Hash>
</Codenesium>*/