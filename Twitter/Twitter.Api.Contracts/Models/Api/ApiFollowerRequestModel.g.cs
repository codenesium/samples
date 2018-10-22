using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TwitterNS.Api.Contracts
{
	public partial class ApiFollowerRequestModel : AbstractApiRequestModel
	{
		public ApiFollowerRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string blocked,
			DateTime dateFollowed,
			string followRequestStatu,
			int followedUserId,
			int followingUserId,
			string muted)
		{
			this.Blocked = blocked;
			this.DateFollowed = dateFollowed;
			this.FollowRequestStatu = followRequestStatu;
			this.FollowedUserId = followedUserId;
			this.FollowingUserId = followingUserId;
			this.Muted = muted;
		}

		[Required]
		[JsonProperty]
		public string Blocked { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public DateTime DateFollowed { get; private set; } = SqlDateTime.MinValue.Value;

		[Required]
		[JsonProperty]
		public string FollowRequestStatu { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public int FollowedUserId { get; private set; }

		[Required]
		[JsonProperty]
		public int FollowingUserId { get; private set; }

		[Required]
		[JsonProperty]
		public string Muted { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>dc3d438eb4362b723cc08834ef226f75</Hash>
</Codenesium>*/