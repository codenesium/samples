using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Services
{
	public partial class ApiTagsServerResponseModel : AbstractApiServerResponseModel
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

		[JsonProperty]
		public int Count { get; private set; }

		[JsonProperty]
		public int ExcerptPostId { get; private set; }

		[JsonProperty]
		public string ExcerptPostIdEntity { get; private set; } = RouteConstants.Posts;

		[JsonProperty]
		public ApiPostsServerResponseModel ExcerptPostIdNavigation { get; private set; }

		public void SetExcerptPostIdNavigation(ApiPostsServerResponseModel value)
		{
			this.ExcerptPostIdNavigation = value;
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string TagName { get; private set; }

		[JsonProperty]
		public int WikiPostId { get; private set; }

		[JsonProperty]
		public string WikiPostIdEntity { get; private set; } = RouteConstants.Posts;

		[JsonProperty]
		public ApiPostsServerResponseModel WikiPostIdNavigation { get; private set; }

		public void SetWikiPostIdNavigation(ApiPostsServerResponseModel value)
		{
			this.WikiPostIdNavigation = value;
		}
	}
}

/*<Codenesium>
    <Hash>c73d75c10221a058252590c4572fc153</Hash>
</Codenesium>*/