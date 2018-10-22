using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Contracts
{
	public partial class ApiTagRequestModel : AbstractApiRequestModel
	{
		public ApiTagRequestModel()
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

		[Required]
		[JsonProperty]
		public int Count { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public int ExcerptPostId { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public string TagName { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public int WikiPostId { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>9243b465a6ce65b73d75f2311561a34f</Hash>
</Codenesium>*/