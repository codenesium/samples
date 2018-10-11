using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TwitterNS.Api.Contracts
{
	public partial class ApiFollowerResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int id,
			string blocked,
			DateTime dateFollowed,
			string followRequestStatu,
			int followedUserId,
			int followingUserId,
			string muted)
		{
			this.Id = id;
			this.Blocked = blocked;
			this.DateFollowed = dateFollowed;
			this.FollowRequestStatu = followRequestStatu;
			this.FollowedUserId = followedUserId;
			this.FollowingUserId = followingUserId;
			this.Muted = muted;

			this.FollowedUserIdEntity = nameof(ApiResponse.Users);
			this.FollowingUserIdEntity = nameof(ApiResponse.Users);
		}

		[JsonProperty]
		public string Blocked { get; private set; }

		[JsonProperty]
		public DateTime DateFollowed { get; private set; }

		[JsonProperty]
		public string FollowRequestStatu { get; private set; }

		[JsonProperty]
		public int FollowedUserId { get; private set; }

		[JsonProperty]
		public string FollowedUserIdEntity { get; set; }

		[JsonProperty]
		public int FollowingUserId { get; private set; }

		[JsonProperty]
		public string FollowingUserIdEntity { get; set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string Muted { get; private set; }
	}
}

/*<Codenesium>
    <Hash>8bb4410c3b9fd835ba67449a07267b69</Hash>
</Codenesium>*/