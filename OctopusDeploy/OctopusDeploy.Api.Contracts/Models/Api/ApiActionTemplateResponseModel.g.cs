using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiActionTemplateResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			string id,
			string actionType,
			string communityActionTemplateId,
			string jSON,
			string name,
			int version)
		{
			this.Id = id;
			this.ActionType = actionType;
			this.CommunityActionTemplateId = communityActionTemplateId;
			this.JSON = jSON;
			this.Name = name;
			this.Version = version;
		}

		[Required]
		[JsonProperty]
		public string ActionType { get; private set; }

		[Required]
		[JsonProperty]
		public string CommunityActionTemplateId { get; private set; }

		[Required]
		[JsonProperty]
		public string Id { get; private set; }

		[Required]
		[JsonProperty]
		public string JSON { get; private set; }

		[Required]
		[JsonProperty]
		public string Name { get; private set; }

		[Required]
		[JsonProperty]
		public int Version { get; private set; }
	}
}

/*<Codenesium>
    <Hash>9fe3eebb2beb703eb540116124bf6a53</Hash>
</Codenesium>*/