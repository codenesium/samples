using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiCommunityActionTemplateRequestModel : AbstractApiRequestModel
	{
		public ApiCommunityActionTemplateRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			Guid externalId,
			string jSON,
			string name)
		{
			this.ExternalId = externalId;
			this.JSON = jSON;
			this.Name = name;
		}

		[JsonProperty]
		public Guid ExternalId { get; private set; }

		[JsonProperty]
		public string JSON { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>ab7e2bc1d2ecd73d62f6aa12dfa313fb</Hash>
</Codenesium>*/