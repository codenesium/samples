using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Client
{
	public partial class ApiVotesClientResponseModel : AbstractApiClientResponseModel
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

			this.PostIdEntity = nameof(ApiResponse.Posts);

			this.UserIdEntity = nameof(ApiResponse.Users);

			this.VoteTypeIdEntity = nameof(ApiResponse.VoteTypes);
		}

		[JsonProperty]
		public ApiPostsClientResponseModel PostIdNavigation { get; private set; }

		public void SetPostIdNavigation(ApiPostsClientResponseModel value)
		{
			this.PostIdNavigation = value;
		}

		[JsonProperty]
		public ApiUsersClientResponseModel UserIdNavigation { get; private set; }

		public void SetUserIdNavigation(ApiUsersClientResponseModel value)
		{
			this.UserIdNavigation = value;
		}

		[JsonProperty]
		public ApiVoteTypesClientResponseModel VoteTypeIdNavigation { get; private set; }

		public void SetVoteTypeIdNavigation(ApiVoteTypesClientResponseModel value)
		{
			this.VoteTypeIdNavigation = value;
		}

		[JsonProperty]
		public int? BountyAmount { get; private set; }

		[JsonProperty]
		public DateTime CreationDate { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public int PostId { get; private set; }

		[JsonProperty]
		public string PostIdEntity { get; set; }

		[JsonProperty]
		public int? UserId { get; private set; }

		[JsonProperty]
		public string UserIdEntity { get; set; }

		[JsonProperty]
		public int VoteTypeId { get; private set; }

		[JsonProperty]
		public string VoteTypeIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>9094566e870805bbe5c41c4c0e0cf0d0</Hash>
</Codenesium>*/