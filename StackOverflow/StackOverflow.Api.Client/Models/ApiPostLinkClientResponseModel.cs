using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Client
{
	public partial class ApiPostLinkClientResponseModel : AbstractApiClientResponseModel
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
		public ApiLinkTypeClientResponseModel LinkTypeIdNavigation { get; private set; }

		public void SetLinkTypeIdNavigation(ApiLinkTypeClientResponseModel value)
		{
			this.LinkTypeIdNavigation = value;
		}

		[JsonProperty]
		public ApiPostClientResponseModel PostIdNavigation { get; private set; }

		public void SetPostIdNavigation(ApiPostClientResponseModel value)
		{
			this.PostIdNavigation = value;
		}

		[JsonProperty]
		public ApiPostClientResponseModel RelatedPostIdNavigation { get; private set; }

		public void SetRelatedPostIdNavigation(ApiPostClientResponseModel value)
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
    <Hash>7be8b466adcc53e5efe996d0f07b5536</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/