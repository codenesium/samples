using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TwitterNS.Api.Client
{
	public partial class ApiFollowingClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int userId,
			DateTime? dateFollowed,
			string muted)
		{
			this.UserId = userId;
			this.DateFollowed = dateFollowed;
			this.Muted = muted;
		}

		[JsonProperty]
		public DateTime? DateFollowed { get; private set; }

		[JsonProperty]
		public string Muted { get; private set; }

		[JsonProperty]
		public int UserId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>a3427f6ce6b5420c4df384dd2cd8fb15</Hash>
</Codenesium>*/