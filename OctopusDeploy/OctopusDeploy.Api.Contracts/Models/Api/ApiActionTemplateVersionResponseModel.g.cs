using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiActionTemplateVersionResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			string id,
			string actionType,
			string jSON,
			string latestActionTemplateId,
			string name,
			int version)
		{
			this.Id = id;
			this.ActionType = actionType;
			this.JSON = jSON;
			this.LatestActionTemplateId = latestActionTemplateId;
			this.Name = name;
			this.Version = version;
		}

		[Required]
		[JsonProperty]
		public string ActionType { get; private set; }

		[Required]
		[JsonProperty]
		public string Id { get; private set; }

		[Required]
		[JsonProperty]
		public string JSON { get; private set; }

		[Required]
		[JsonProperty]
		public string LatestActionTemplateId { get; private set; }

		[Required]
		[JsonProperty]
		public string Name { get; private set; }

		[Required]
		[JsonProperty]
		public int Version { get; private set; }
	}
}

/*<Codenesium>
    <Hash>ee9230cda951896584ff9232bddf12e8</Hash>
</Codenesium>*/