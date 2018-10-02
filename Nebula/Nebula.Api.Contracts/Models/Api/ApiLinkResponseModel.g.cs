using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace NebulaNS.Api.Contracts
{
	public partial class ApiLinkResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int id,
			int? assignedMachineId,
			int chainId,
			DateTime? dateCompleted,
			DateTime? dateStarted,
			string dynamicParameter,
			Guid externalId,
			int linkStatusId,
			string name,
			int order,
			string response,
			string staticParameter,
			int timeoutInSecond)
		{
			this.Id = id;
			this.AssignedMachineId = assignedMachineId;
			this.ChainId = chainId;
			this.DateCompleted = dateCompleted;
			this.DateStarted = dateStarted;
			this.DynamicParameter = dynamicParameter;
			this.ExternalId = externalId;
			this.LinkStatusId = linkStatusId;
			this.Name = name;
			this.Order = order;
			this.Response = response;
			this.StaticParameter = staticParameter;
			this.TimeoutInSecond = timeoutInSecond;

			this.AssignedMachineIdEntity = nameof(ApiResponse.Machines);
			this.ChainIdEntity = nameof(ApiResponse.Chains);
			this.LinkStatusIdEntity = nameof(ApiResponse.LinkStatus);
		}

		[Required]
		[JsonProperty]
		public int? AssignedMachineId { get; private set; }

		[JsonProperty]
		public string AssignedMachineIdEntity { get; set; }

		[JsonProperty]
		public int ChainId { get; private set; }

		[JsonProperty]
		public string ChainIdEntity { get; set; }

		[Required]
		[JsonProperty]
		public DateTime? DateCompleted { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime? DateStarted { get; private set; }

		[Required]
		[JsonProperty]
		public string DynamicParameter { get; private set; }

		[JsonProperty]
		public Guid ExternalId { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public int LinkStatusId { get; private set; }

		[JsonProperty]
		public string LinkStatusIdEntity { get; set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public int Order { get; private set; }

		[Required]
		[JsonProperty]
		public string Response { get; private set; }

		[Required]
		[JsonProperty]
		public string StaticParameter { get; private set; }

		[JsonProperty]
		public int TimeoutInSecond { get; private set; }
	}
}

/*<Codenesium>
    <Hash>384effc5f150989bc66754d974c71357</Hash>
</Codenesium>*/