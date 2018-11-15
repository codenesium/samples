using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace NebulaNS.Api.Services
{
	public partial class ApiLinkServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiLinkServerRequestModel()
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
		public DateTime? DateCompleted { get; private set; } = null;

		[JsonProperty]
		public DateTime? DateStarted { get; private set; } = null;

		[JsonProperty]
		public string DynamicParameter { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public Guid ExternalId { get; private set; } = default(Guid);

		[Required]
		[JsonProperty]
		public int LinkStatusId { get; private set; }

		[Required]
		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public int Order { get; private set; } = default(int);

		[JsonProperty]
		public string Response { get; private set; } = default(string);

		[JsonProperty]
		public string StaticParameter { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public int TimeoutInSecond { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>ddaa9d8b06bb5dde209808c9696d4dfc</Hash>
</Codenesium>*/