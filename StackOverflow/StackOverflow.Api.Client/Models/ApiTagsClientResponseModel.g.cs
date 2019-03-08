using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Client
{
	public partial class ApiTagsClientResponseModel : AbstractApiClientResponseModel
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
		public ApiPostsClientResponseModel ExcerptPostIdNavigation { get; private set; }

		public void SetExcerptPostIdNavigation(ApiPostsClientResponseModel value)
		{
			this.ExcerptPostIdNavigation = value;
		}

		[JsonProperty]
		public ApiPostsClientResponseModel WikiPostIdNavigation { get; private set; }

		public void SetWikiPostIdNavigation(ApiPostsClientResponseModel value)
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
    <Hash>86aa09fa06c5e58b0ebc5c53e198ac27</Hash>
</Codenesium>*/