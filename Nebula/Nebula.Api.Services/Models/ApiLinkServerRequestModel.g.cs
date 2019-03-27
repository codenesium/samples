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

		[Required]
		[JsonProperty]
		public int ChainId { get; private set; }

		[JsonProperty]
		public DateTime? DateCompleted { get; private set; } = null;

		[JsonProperty]
		public DateTime? DateStarted { get; private set; } = null;

		[JsonProperty]
		public string DynamicParameters { get; private set; } = default(string);

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
		public string StaticParameters { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public int TimeoutInSeconds { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>76de11ac2ec0b52ff782007177c21d64</Hash>
</Codenesium>*/