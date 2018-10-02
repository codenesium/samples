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
			string dynamicParameter,
			Guid externalId,
			int linkStatusId,
			string name,
			int order,
			string response,
			string staticParameter,
			int timeoutInSecond)
		{
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

		[JsonProperty]
		public int? AssignedMachineId { get; private set; }

		[Required]
		[JsonProperty]
		public int ChainId { get; private set; }

		[JsonProperty]
		public DateTime? DateCompleted { get; private set; }

		[JsonProperty]
		public DateTime? DateStarted { get; private set; }

		[JsonProperty]
		public string DynamicParameter { get; private set; }

		[Required]
		[JsonProperty]
		public Guid ExternalId { get; private set; }

		[Required]
		[JsonProperty]
		public int LinkStatusId { get; private set; }

		[Required]
		[JsonProperty]
		public string Name { get; private set; }

		[Required]
		[JsonProperty]
		public int Order { get; private set; }

		[JsonProperty]
		public string Response { get; private set; }

		[JsonProperty]
		public string StaticParameter { get; private set; }

		[Required]
		[JsonProperty]
		public int TimeoutInSecond { get; private set; }
	}
}

/*<Codenesium>
    <Hash>ffd508e7c13fde5d9007ed439ee72c43</Hash>
</Codenesium>*/