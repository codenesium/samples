using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Client
{
	public partial class ApiVoteClientResponseModel : AbstractApiClientResponseModel
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
		public ApiPostClientResponseModel PostIdNavigation { get; private set; }

		public void SetPostIdNavigation(ApiPostClientResponseModel value)
		{
			this.PostIdNavigation = value;
		}

		[JsonProperty]
		public ApiUserClientResponseModel UserIdNavigation { get; private set; }

		public void SetUserIdNavigation(ApiUserClientResponseModel value)
		{
			this.UserIdNavigation = value;
		}

		[JsonProperty]
		public ApiVoteTypeClientResponseModel VoteTypeIdNavigation { get; private set; }

		public void SetVoteTypeIdNavigation(ApiVoteTypeClientResponseModel value)
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
    <Hash>79da6a668d9b5b8cc2f2331b5918166a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/