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
			string dynamicParameters,
			Guid externalId,
			int linkStatusId,
			string name,
			int order,
			string response,
			string staticParameters,
			int timeoutInSeconds)
		{
			this.Id = id;
			this.AssignedMachineId = assignedMachineId;
			this.ChainId = chainId;
			this.DateCompleted = dateCompleted;
			this.DateStarted = dateStarted;
			this.DynamicParameters = dynamicParameters;
			this.ExternalId = externalId;
			this.LinkStatusId = linkStatusId;
			this.Name = name;
			this.Order = order;
			this.Response = response;
			this.StaticParameters = staticParameters;
			this.TimeoutInSeconds = timeoutInSeconds;
		}

		[Required]
		[JsonProperty]
		public int? AssignedMachineId { get; private set; }

		[JsonProperty]
		public string AssignedMachineIdEntity { get; private set; } = RouteConstants.Machines;

		[JsonProperty]
		public ApiMachineServerResponseModel AssignedMachineIdNavigation { get; private set; }

		public void SetAssignedMachineIdNavigation(ApiMachineServerResponseModel value)
		{
			this.AssignedMachineIdNavigation = value;
		}

		[JsonProperty]
		public int ChainId { get; private set; }

		[JsonProperty]
		public string ChainIdEntity { get; private set; } = RouteConstants.Chains;

		[JsonProperty]
		public ApiChainServerResponseModel ChainIdNavigation { get; private set; }

		public void SetChainIdNavigation(ApiChainServerResponseModel value)
		{
			this.ChainIdNavigation = value;
		}

		[Required]
		[JsonProperty]
		public DateTime? DateCompleted { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime? DateStarted { get; private set; }

		[Required]
		[JsonProperty]
		public string DynamicParameters { get; private set; }

		[JsonProperty]
		public Guid ExternalId { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public int LinkStatusId { get; private set; }

		[JsonProperty]
		public string LinkStatusIdEntity { get; private set; } = RouteConstants.LinkStatus;

		[JsonProperty]
		public ApiLinkStatusServerResponseModel LinkStatusIdNavigation { get; private set; }

		public void SetLinkStatusIdNavigation(ApiLinkStatusServerResponseModel value)
		{
			this.LinkStatusIdNavigation = value;
		}

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public int Order { get; private set; }

		[Required]
		[JsonProperty]
		public string Response { get; private set; }

		[Required]
		[JsonProperty]
		public string StaticParameters { get; private set; }

		[JsonProperty]
		public int TimeoutInSeconds { get; private set; }
	}
}

/*<Codenesium>
    <Hash>85f00242ff661349986067f3bfd1555d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/