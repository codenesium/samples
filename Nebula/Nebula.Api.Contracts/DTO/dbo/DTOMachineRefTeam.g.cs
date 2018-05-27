using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace NebulaNS.Api.Contracts
{
	public partial class DTOMachineRefTeam: AbstractDTO
	{
		public DTOMachineRefTeam() : base()
		{}

		public void SetProperties(int id,
		                          int machineId,
		                          int teamId)
		{
			this.Id = id.ToInt();
			this.MachineId = machineId.ToInt();
			this.TeamId = teamId.ToInt();
		}

		public int Id { get; set; }
		public int MachineId { get; set; }
		public int TeamId { get; set; }
	}
}

/*<Codenesium>
    <Hash>d230088b4374081dd74c6b79bbc7078f</Hash>
</Codenesium>*/