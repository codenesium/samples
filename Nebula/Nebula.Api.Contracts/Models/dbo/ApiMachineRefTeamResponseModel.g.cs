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
    <Hash>44ee9fa91fa526b10a6f2d39f614a00a</Hash>
</Codenesium>*/