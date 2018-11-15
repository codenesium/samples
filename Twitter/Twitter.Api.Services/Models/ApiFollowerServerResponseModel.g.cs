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
    <Hash>0ec38e42993117cba4d1cdfa9dfcded3</Hash>
</Codenesium>*/