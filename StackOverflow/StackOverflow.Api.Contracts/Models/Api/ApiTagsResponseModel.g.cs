using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Contracts
{
	public partial class ApiTagsResponseModel : AbstractApiResponseModel
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

		[Required]
		[JsonProperty]
		public int Count { get; private set; }

		[Required]
		[JsonProperty]
		public int ExcerptPostId { get; private set; }

		[Required]
		[JsonProperty]
		public int Id { get; private set; }

		[Required]
		[JsonProperty]
		public string TagName { get; private set; }

		[Required]
		[JsonProperty]
		public int WikiPostId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>b8ed08309070e5ebaf7428454b571be9</Hash>
</Codenesium>*/