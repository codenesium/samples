using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Services
{
	public partial class ApiPostLinksServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int id,
			DateTime creationDate,
			int linkTypeId,
			int postId,
			int relatedPostId)
		{
			this.Id = id;
			this.CreationDate = creationDate;
			this.LinkTypeId = linkTypeId;
			this.PostId = postId;
			this.RelatedPostId = relatedPostId;
		}

		[JsonProperty]
		public DateTime CreationDate { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public int LinkTypeId { get; private set; }

		[JsonProperty]
		public string LinkTypeIdEntity { get; private set; } = RouteConstants.LinkTypes;

		[JsonProperty]
		public ApiLinkTypesServerResponseModel LinkTypeIdNavigation { get; private set; }

		public void SetLinkTypeIdNavigation(ApiLinkTypesServerResponseModel value)
		{
			this.LinkTypeIdNavigation = value;
		}

		[JsonProperty]
		public int PostId { get; private set; }

		[JsonProperty]
		public string PostIdEntity { get; private set; } = RouteConstants.Posts;

		[JsonProperty]
		public ApiPostsServerResponseModel PostIdNavigation { get; private set; }

		public void SetPostIdNavigation(ApiPostsServerResponseModel value)
		{
			this.PostIdNavigation = value;
		}

		[JsonProperty]
		public int RelatedPostId { get; private set; }

		[JsonProperty]
		public string RelatedPostIdEntity { get; private set; } = RouteConstants.Posts;

		[JsonProperty]
		public ApiPostsServerResponseModel RelatedPostIdNavigation { get; private set; }

		public void SetRelatedPostIdNavigation(ApiPostsServerResponseModel value)
		{
			this.RelatedPostIdNavigation = value;
		}
	}
}

/*<Codenesium>
    <Hash>12b172a91b2765cd38b542697440ef88</Hash>
</Codenesium>*/