using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Services
{
	public partial class ApiTagServerResponseModel : AbstractApiServerResponseModel
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
		public ApiPostServerResponseModel ExcerptPostIdNavigation { get; private set; }

		public void SetExcerptPostIdNavigation(ApiPostServerResponseModel value)
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
		public ApiPostServerResponseModel WikiPostIdNavigation { get; private set; }

		public void SetWikiPostIdNavigation(ApiPostServerResponseModel value)
		{
			this.WikiPostIdNavigation = value;
		}
	}
}

/*<Codenesium>
    <Hash>6859b4838c6c4d5f05b7f0a049db7c3f</Hash>
</Codenesium>*/