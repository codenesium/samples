using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace NebulaNS.Api.Client
{
	public partial class ApiMachineRefTeamClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiMachineRefTeamClientRequestModel()
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
    <Hash>b6f4801965a4cc4a91644de2458a1c05</Hash>
</Codenesium>*/