using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace NebulaNS.Api.Contracts
{
	public partial class ApiMachineRefTeamResponseModel: AbstractApiResponseModel
	{
		public ApiMachineRefTeamResponseModel() : base()
		{}

		public void SetProperties(
			int id,
			int machineId,
			int teamId)
		{
			this.Id = id.ToInt();
			this.MachineId = machineId.ToInt();
			this.TeamId = teamId.ToInt();

			this.MachineIdEntity = nameof(ApiResponse.Machines);
			this.TeamIdEntity = nameof(ApiResponse.Teams);
		}

		public int Id { get; private set; }
		public int MachineId { get; private set; }
		public string MachineIdEntity { get; set; }
		public int TeamId { get; private set; }
		public string TeamIdEntity { get; set; }

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
    <Hash>716c0743d91e50e6ec93d64635384197</Hash>
</Codenesium>*/