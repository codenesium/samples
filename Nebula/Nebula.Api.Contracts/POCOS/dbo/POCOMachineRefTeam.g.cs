using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace NebulaNS.Api.Contracts
{
	public partial class POCOMachineRefTeam
	{
		public POCOMachineRefTeam()
		{}

		public POCOMachineRefTeam(
			int id,
			int machineId,
			int teamId)
		{
			this.Id = id.ToInt();

			this.MachineId = new ReferenceEntity<int>(machineId,
			                                          nameof(ApiResponse.Machines));
			this.TeamId = new ReferenceEntity<int>(teamId,
			                                       nameof(ApiResponse.Teams));
		}

		public int Id { get; set; }
		public ReferenceEntity<int> MachineId { get; set; }
		public ReferenceEntity<int> TeamId { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeIdValue { get; set; } = true;

		public bool ShouldSerializeId()
		{
			return this.ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeMachineIdValue { get; set; } = true;

		public bool ShouldSerializeMachineId()
		{
			return this.ShouldSerializeMachineIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeTeamIdValue { get; set; } = true;

		public bool ShouldSerializeTeamId()
		{
			return this.ShouldSerializeTeamIdValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializeMachineIdValue = false;
			this.ShouldSerializeTeamIdValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>589dd5a9df45a57bdaa4425eec7f7554</Hash>
</Codenesium>*/