using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TwitterNS.Api.Services
{
	public partial class ApiFollowerServerResponseModel : AbstractApiServerResponseModel
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
		public string FollowedUserIdEntity { get; private set; } = RouteConstants.Users;

		[JsonProperty]
		public ApiUserServerResponseModel FollowedUserIdNavigation { get; private set; }

		public void SetFollowedUserIdNavigation(ApiUserServerResponseModel value)
		{
			this.FollowedUserIdNavigation = value;
		}

		[JsonProperty]
		public int FollowingUserId { get; private set; }

		[JsonProperty]
		public string FollowingUserIdEntity { get; private set; } = RouteConstants.Users;

		[JsonProperty]
		public ApiUserServerResponseModel FollowingUserIdNavigation { get; private set; }

		public void SetFollowingUserIdNavigation(ApiUserServerResponseModel value)
		{
			this.FollowingUserIdNavigation = value;
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string Muted { get; private set; }
	}
}

/*<Codenesium>
    <Hash>35b92d7e8fbd7f75e931997a5a969c78</Hash>
</Codenesium>*/