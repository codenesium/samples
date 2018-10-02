using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
		public int Count { get; private set; }

		[Required]
		[JsonProperty]
		public int ExcerptPostId { get; private set; }

		[Required]
		[JsonProperty]
		public string TagName { get; private set; }

		[Required]
		[JsonProperty]
		public int WikiPostId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>35652d6aae8edeb5fd44c00bd20681a1</Hash>
</Codenesium>*/