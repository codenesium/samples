using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace NebulaNS.Api.Services
{
	public partial class ApiMachineRefTeamServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiMachineRefTeamServerRequestModel()
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
    <Hash>8b52be21f788f3e4652e32786904cf23</Hash>
</Codenesium>*/