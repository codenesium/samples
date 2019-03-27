using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace NebulaNS.Api.Services
{
	public partial class ApiMachineRefTeamServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int id,
			int machineId,
			int teamId)
		{
			this.Id = id;
			this.MachineId = machineId;
			this.TeamId = teamId;
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public int MachineId { get; private set; }

		[JsonProperty]
		public string MachineIdEntity { get; private set; } = RouteConstants.Machines;

		[JsonProperty]
		public ApiMachineServerResponseModel MachineIdNavigation { get; private set; }

		public void SetMachineIdNavigation(ApiMachineServerResponseModel value)
		{
			this.MachineIdNavigation = value;
		}

		[JsonProperty]
		public int TeamId { get; private set; }

		[JsonProperty]
		public string TeamIdEntity { get; private set; } = RouteConstants.Teams;

		[JsonProperty]
		public ApiTeamServerResponseModel TeamIdNavigation { get; private set; }

		public void SetTeamIdNavigation(ApiTeamServerResponseModel value)
		{
			this.TeamIdNavigation = value;
		}
	}
}

/*<Codenesium>
    <Hash>0dad689893ecde83511b779cd2f11758</Hash>
</Codenesium>*/