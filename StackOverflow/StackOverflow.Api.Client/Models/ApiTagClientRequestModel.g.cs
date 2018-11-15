using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Client
{
	public partial class ApiTagClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiTagClientRequestModel()
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
		public int ExcerptPostId { get; private set; } = default(int);

		[JsonProperty]
		public string TagName { get; private set; } = default(string);

		[JsonProperty]
		public int WikiPostId { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>7a0ff73061d78551ba7d9caf8fda6e0a</Hash>
</Codenesium>*/