using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TwitterNS.Api.Client
{
	public partial class ApiFollowerClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiFollowerClientRequestModel()
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

		[JsonProperty]
		public string Blocked { get; private set; } = default(string);

		[JsonProperty]
		public DateTime DateFollowed { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public string FollowRequestStatu { get; private set; } = default(string);

		[JsonProperty]
		public int FollowedUserId { get; private set; }

		[JsonProperty]
		public int FollowingUserId { get; private set; }

		[JsonProperty]
		public string Muted { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>a8f6890a6d5f3a5dc51a48d8353e6f59</Hash>
</Codenesium>*/