using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Services
{
	public partial class ApiTagServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiTagServerRequestModel()
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
    <Hash>8a4a628f5dad11f7d4a2509c942113ad</Hash>
</Codenesium>*/