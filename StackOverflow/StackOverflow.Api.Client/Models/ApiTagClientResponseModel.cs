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

			this.ExcerptPostIdEntity = nameof(ApiResponse.Posts);

			this.WikiPostIdEntity = nameof(ApiResponse.Posts);
		}

		[JsonProperty]
		public ApiPostClientResponseModel ExcerptPostIdNavigation { get; private set; }

		public void SetExcerptPostIdNavigation(ApiPostClientResponseModel value)
		{
			this.ExcerptPostIdNavigation = value;
		}

		[JsonProperty]
		public ApiPostClientResponseModel WikiPostIdNavigation { get; private set; }

		public void SetWikiPostIdNavigation(ApiPostClientResponseModel value)
		{
			this.WikiPostIdNavigation = value;
		}

		[JsonProperty]
		public int Count { get; private set; }

		[JsonProperty]
		public int ExcerptPostId { get; private set; }

		[JsonProperty]
		public string ExcerptPostIdEntity { get; set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string TagName { get; private set; }

		[JsonProperty]
		public int WikiPostId { get; private set; }

		[JsonProperty]
		public string WikiPostIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>4e9b38531a1e3305dce89d10edc2ae9a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/