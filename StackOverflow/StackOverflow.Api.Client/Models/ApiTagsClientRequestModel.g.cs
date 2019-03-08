using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Client
{
	public partial class ApiTagsClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiTagsClientRequestModel()
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
		public int Count { get; private set; } = default(int);

		[JsonProperty]
		public int ExcerptPostId { get; private set; }

		[JsonProperty]
		public string TagName { get; private set; } = default(string);

		[JsonProperty]
		public int WikiPostId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>59ffa7b922a097f20f6c4b9d464e9eab</Hash>
</Codenesium>*/