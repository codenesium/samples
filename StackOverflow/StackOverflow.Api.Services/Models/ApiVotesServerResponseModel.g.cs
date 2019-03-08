using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Services
{
	public partial class ApiVotesServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int id,
			int? bountyAmount,
			DateTime creationDate,
			int postId,
			int? userId,
			int voteTypeId)
		{
			this.Id = id;
			this.BountyAmount = bountyAmount;
			this.CreationDate = creationDate;
			this.PostId = postId;
			this.UserId = userId;
			this.VoteTypeId = voteTypeId;
		}

		[Required]
		[JsonProperty]
		public int? BountyAmount { get; private set; }

		[JsonProperty]
		public DateTime CreationDate { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

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

		[Required]
		[JsonProperty]
		public int? UserId { get; private set; }

		[JsonProperty]
		public string UserIdEntity { get; private set; } = RouteConstants.Users;

		[JsonProperty]
		public ApiUsersServerResponseModel UserIdNavigation { get; private set; }

		public void SetUserIdNavigation(ApiUsersServerResponseModel value)
		{
			this.UserIdNavigation = value;
		}

		[JsonProperty]
		public int VoteTypeId { get; private set; }

		[JsonProperty]
		public string VoteTypeIdEntity { get; private set; } = RouteConstants.VoteTypes;

		[JsonProperty]
		public ApiVoteTypesServerResponseModel VoteTypeIdNavigation { get; private set; }

		public void SetVoteTypeIdNavigation(ApiVoteTypesServerResponseModel value)
		{
			this.VoteTypeIdNavigation = value;
		}
	}
}

/*<Codenesium>
    <Hash>9ab6390d918140c39e43ccd4c6691b31</Hash>
</Codenesium>*/