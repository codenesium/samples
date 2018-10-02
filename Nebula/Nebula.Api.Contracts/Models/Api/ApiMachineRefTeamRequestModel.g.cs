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

		[Required]
		[JsonProperty]
		public int MachineId { get; private set; }

		[Required]
		[JsonProperty]
		public int TeamId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>e4326e1cac0dd6138a1a255c2c3798ea</Hash>
</Codenesium>*/