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
		public int ExcerptPostId { get; private set; }

		[JsonProperty]
		public string TagName { get; private set; } = default(string);

		[JsonProperty]
		public int WikiPostId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>8e9f4feb4956313d61c935c52136d89c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/