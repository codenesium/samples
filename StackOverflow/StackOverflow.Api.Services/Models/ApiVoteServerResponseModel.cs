using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Services
{
	public partial class ApiVoteServerResponseModel : AbstractApiServerResponseModel
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
		public ApiPostServerResponseModel PostIdNavigation { get; private set; }

		public void SetPostIdNavigation(ApiPostServerResponseModel value)
		{
			this.PostIdNavigation = value;
		}

		[Required]
		[JsonProperty]
		public int? UserId { get; private set; }

		[JsonProperty]
		public string UserIdEntity { get; private set; } = RouteConstants.Users;

		[JsonProperty]
		public ApiUserServerResponseModel UserIdNavigation { get; private set; }

		public void SetUserIdNavigation(ApiUserServerResponseModel value)
		{
			this.UserIdNavigation = value;
		}

		[JsonProperty]
		public int VoteTypeId { get; private set; }

		[JsonProperty]
		public string VoteTypeIdEntity { get; private set; } = RouteConstants.VoteTypes;

		[JsonProperty]
		public ApiVoteTypeServerResponseModel VoteTypeIdNavigation { get; private set; }

		public void SetVoteTypeIdNavigation(ApiVoteTypeServerResponseModel value)
		{
			this.VoteTypeIdNavigation = value;
		}
	}
}

/*<Codenesium>
    <Hash>ec3484bc992cc2232fb78f1e359617af</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/