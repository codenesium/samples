using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace NebulaNS.Api.Contracts
{
	public partial class ApiMachineRefTeamResponseModel : AbstractApiResponseModel
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
    <Hash>bb8d94fb43e5434cb334383743655c46</Hash>
</Codenesium>*/