using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace NebulaNS.Api.Contracts
{
	public partial class ApiMachineRefTeamRequestModel : AbstractApiRequestModel
	{
		public ApiMachineRefTeamRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int machineId,
			int teamId)
		{
			this.MachineId = machineId;
			this.TeamId = teamId;
		}

		[JsonProperty]
		public int MachineId { get; private set; }

		[JsonProperty]
		public int TeamId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>49a6df98c97c854d1825a0a440cf3aa2</Hash>
</Codenesium>*/