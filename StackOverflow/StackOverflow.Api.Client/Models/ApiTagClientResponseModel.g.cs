using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Client
{
	public partial class ApiTagClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			int count,
			int excerptPostId,
			string tagName,
			int wikiPostId)
		{
			this.Id = id;
			this.Count = count;
			this.ExcerptPostId = excerptPostId;
			this.TagName = tagName;
			this.WikiPostId = wikiPostId;
		}

		[JsonProperty]
		public int Count { get; private set; }

		[JsonProperty]
		public int ExcerptPostId { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string TagName { get; private set; }

		[JsonProperty]
		public int WikiPostId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>6877cbf8db0fbbc5521c2613553c699d</Hash>
</Codenesium>*/