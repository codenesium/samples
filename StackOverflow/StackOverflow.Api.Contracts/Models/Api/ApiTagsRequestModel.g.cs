using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Contracts
{
	public partial class ApiTagsRequestModel : AbstractApiRequestModel
	{
		public ApiTagsRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int count,
			int excerptPostId,
			string tagName,
			int wikiPostId)
		{
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
		public string TagName { get; private set; }

		[JsonProperty]
		public int WikiPostId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>27bb189cb6f5e207870c6220b8ede8e9</Hash>
</Codenesium>*/