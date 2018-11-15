using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TwitterNS.Api.Services
{
	public partial class ApiFollowerServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiFollowerServerRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string blocked,
			DateTime dateFollowed,
			int followedUserId,
			int followingUserId,
			string followRequestStatu,
			string muted)
		{
			this.Blocked = blocked;
			this.DateFollowed = dateFollowed;
			this.FollowedUserId = followedUserId;
			this.FollowingUserId = followingUserId;
			this.FollowRequestStatu = followRequestStatu;
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
    <Hash>8f1a48c938d5b20b1e9f54b9df9da3f7</Hash>
</Codenesium>*/