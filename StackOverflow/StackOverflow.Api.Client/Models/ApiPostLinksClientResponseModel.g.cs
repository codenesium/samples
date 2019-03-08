using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Client
{
	public partial class ApiPostLinksClientResponseModel : AbstractApiClientResponseModel
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

			this.LinkTypeIdEntity = nameof(ApiResponse.LinkTypes);

			this.PostIdEntity = nameof(ApiResponse.Posts);

			this.RelatedPostIdEntity = nameof(ApiResponse.Posts);
		}

		[JsonProperty]
		public ApiLinkTypesClientResponseModel LinkTypeIdNavigation { get; private set; }

		public void SetLinkTypeIdNavigation(ApiLinkTypesClientResponseModel value)
		{
			this.LinkTypeIdNavigation = value;
		}

		[JsonProperty]
		public ApiPostsClientResponseModel PostIdNavigation { get; private set; }

		public void SetPostIdNavigation(ApiPostsClientResponseModel value)
		{
			this.PostIdNavigation = value;
		}

		[JsonProperty]
		public ApiPostsClientResponseModel RelatedPostIdNavigation { get; private set; }

		public void SetRelatedPostIdNavigation(ApiPostsClientResponseModel value)
		{
			this.RelatedPostIdNavigation = value;
		}

		[JsonProperty]
		public DateTime CreationDate { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public int LinkTypeId { get; private set; }

		[JsonProperty]
		public string LinkTypeIdEntity { get; set; }

		[JsonProperty]
		public int PostId { get; private set; }

		[JsonProperty]
		public string PostIdEntity { get; set; }

		[JsonProperty]
		public int RelatedPostId { get; private set; }

		[JsonProperty]
		public string RelatedPostIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>a60e12959c7fa71efe5461001a0afab8</Hash>
</Codenesium>*/