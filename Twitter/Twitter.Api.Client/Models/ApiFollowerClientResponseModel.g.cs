using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TwitterNS.Api.Client
{
	public partial class ApiFollowerClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			string blocked,
			DateTime dateFollowed,
			int followedUserId,
			int followingUserId,
			string followRequestStatu,
			string muted)
		{
			this.Id = id;
			this.Blocked = blocked;
			this.DateFollowed = dateFollowed;
			this.FollowedUserId = followedUserId;
			this.FollowingUserId = followingUserId;
			this.FollowRequestStatu = followRequestStatu;
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
    <Hash>97c753f535c15cace10cf22104b46cb2</Hash>
</Codenesium>*/