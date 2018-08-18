using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiFeedResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			string id,
			string feedType,
			string feedUri,
			string jSON,
			string name)
		{
			this.Id = id;
			this.FeedType = feedType;
			this.FeedUri = feedUri;
			this.JSON = jSON;
			this.Name = name;
		}

		[Required]
		[JsonProperty]
		public string FeedType { get; private set; }

		[Required]
		[JsonProperty]
		public string FeedUri { get; private set; }

		[Required]
		[JsonProperty]
		public string Id { get; private set; }

		[Required]
		[JsonProperty]
		public string JSON { get; private set; }

		[Required]
		[JsonProperty]
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>286f4d5221868fa38713593ceafaf5fa</Hash>
</Codenesium>*/