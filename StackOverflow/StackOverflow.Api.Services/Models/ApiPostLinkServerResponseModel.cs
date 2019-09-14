using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Services
{
	public partial class ApiPostLinkServerResponseModel : AbstractApiServerResponseModel
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
		public ApiLinkTypeServerResponseModel LinkTypeIdNavigation { get; private set; }

		public void SetLinkTypeIdNavigation(ApiLinkTypeServerResponseModel value)
		{
			this.LinkTypeIdNavigation = value;
		}

		[JsonProperty]
		public int PostId { get; private set; }

		[JsonProperty]
		public string PostIdEntity { get; private set; } = RouteConstants.Posts;

		[JsonProperty]
		public ApiPostServerResponseModel PostIdNavigation { get; private set; }

		public void SetPostIdNavigation(ApiPostServerResponseModel value)
		{
			this.PostIdNavigation = value;
		}

		[JsonProperty]
		public int RelatedPostId { get; private set; }

		[JsonProperty]
		public string RelatedPostIdEntity { get; private set; } = RouteConstants.Posts;

		[JsonProperty]
		public ApiPostServerResponseModel RelatedPostIdNavigation { get; private set; }

		public void SetRelatedPostIdNavigation(ApiPostServerResponseModel value)
		{
			this.RelatedPostIdNavigation = value;
		}
	}
}

/*<Codenesium>
    <Hash>3c6cb278a6ff12406685cdd30d9395cd</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/