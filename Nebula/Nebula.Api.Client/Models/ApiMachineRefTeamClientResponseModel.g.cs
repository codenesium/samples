using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NebulaNS.Api.Client
{
	public partial class ApiMachineRefTeamClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			int machineId,
			int teamId)
		{
			this.Id = id;
			this.MachineId = machineId;
			this.TeamId = teamId;

			this.MachineIdEntity = nameof(ApiResponse.Machines);

			this.TeamIdEntity = nameof(ApiResponse.Teams);
		}

		[JsonProperty]
		public ApiMachineClientResponseModel MachineIdNavigation { get; private set; }

		public void SetMachineIdNavigation(ApiMachineClientResponseModel value)
		{
			this.MachineIdNavigation = value;
		}

		[JsonProperty]
		public ApiTeamClientResponseModel TeamIdNavigation { get; private set; }

		public void SetTeamIdNavigation(ApiTeamClientResponseModel value)
		{
			this.TeamIdNavigation = value;
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public int MachineId { get; private set; }

		[JsonProperty]
		public string MachineIdEntity { get; set; }

		[JsonProperty]
		public int TeamId { get; private set; }

		[JsonProperty]
		public string TeamIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>0206dc758785c535b95f357773a37699</Hash>
</Codenesium>*/