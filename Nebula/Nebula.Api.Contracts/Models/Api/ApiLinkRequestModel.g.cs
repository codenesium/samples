using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace NebulaNS.Api.Contracts
{
	public partial class ApiLinkRequestModel : AbstractApiRequestModel
	{
		public ApiLinkRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
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

		[JsonProperty]
		public int? AssignedMachineId { get; private set; }

		[JsonProperty]
		public int ChainId { get; private set; }

		[JsonProperty]
		public DateTime? DateCompleted { get; private set; }

		[JsonProperty]
		public DateTime? DateStarted { get; private set; }

		[JsonProperty]
		public string DynamicParameters { get; private set; }

		[JsonProperty]
		public Guid ExternalId { get; private set; }

		[JsonProperty]
		public int LinkStatusId { get; private set; }

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
    <Hash>6db1788201ba57b02d520b668f4cd6f1</Hash>
</Codenesium>*/