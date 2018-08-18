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
    <Hash>ce51e4ad96e90c869444392ae4bd2183</Hash>
</Codenesium>*/