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
		public int ExcerptPostId { get; private set; }

		[Required]
		[JsonProperty]
		public string TagName { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public int WikiPostId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>4d1cb37637c8464a3089733c1efdbc2d</Hash>
</Codenesium>*/