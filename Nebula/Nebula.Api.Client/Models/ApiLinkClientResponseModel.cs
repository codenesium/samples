using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NebulaNS.Api.Client
{
	public partial class ApiLinkClientResponseModel : AbstractApiClientResponseModel
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

			this.AssignedMachineIdEntity = nameof(ApiResponse.Machines);

			this.ChainIdEntity = nameof(ApiResponse.Chains);

			this.LinkStatusIdEntity = nameof(ApiResponse.LinkStatus);
		}

		[JsonProperty]
		public ApiMachineClientResponseModel AssignedMachineIdNavigation { get; private set; }

		public void SetAssignedMachineIdNavigation(ApiMachineClientResponseModel value)
		{
			this.AssignedMachineIdNavigation = value;
		}

		[JsonProperty]
		public ApiChainClientResponseModel ChainIdNavigation { get; private set; }

		public void SetChainIdNavigation(ApiChainClientResponseModel value)
		{
			this.ChainIdNavigation = value;
		}

		[JsonProperty]
		public ApiLinkStatusClientResponseModel LinkStatusIdNavigation { get; private set; }

		public void SetLinkStatusIdNavigation(ApiLinkStatusClientResponseModel value)
		{
			this.LinkStatusIdNavigation = value;
		}

		[JsonProperty]
		public int? AssignedMachineId { get; private set; }

		[JsonProperty]
		public string AssignedMachineIdEntity { get; set; }

		[JsonProperty]
		public int ChainId { get; private set; }

		[JsonProperty]
		public string ChainIdEntity { get; set; }

		[JsonProperty]
		public DateTime? DateCompleted { get; private set; }

		[JsonProperty]
		public DateTime? DateStarted { get; private set; }

		[JsonProperty]
		public string DynamicParameters { get; private set; }

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

		[JsonProperty]
		public string Response { get; private set; }

		[JsonProperty]
		public string StaticParameters { get; private set; }

		[JsonProperty]
		public int TimeoutInSeconds { get; private set; }
	}
}

/*<Codenesium>
    <Hash>8c54818aea6db5d7cb0a61da19cc1abe</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/