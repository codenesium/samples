using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace NebulaNS.Api.Services
{
	public partial class ApiLinkServerResponseModel : AbstractApiServerResponseModel
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
		}

		[Required]
		[JsonProperty]
		public int? AssignedMachineId { get; private set; }

		[JsonProperty]
		public string AssignedMachineIdEntity { get; private set; } = RouteConstants.Machines;

		[JsonProperty]
		public int ChainId { get; private set; }

		[JsonProperty]
		public string ChainIdEntity { get; private set; } = RouteConstants.Chains;

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
		public string LinkStatusIdEntity { get; private set; } = RouteConstants.LinkStatuses;

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
    <Hash>90d6fd3a78196dc7a89416457dc8cda4</Hash>
</Codenesium>*/