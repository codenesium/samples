using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TwitterNS.Api.Contracts
{
	public partial class ApiLikeResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int likeId,
			int likerUserId,
			int tweetId)
		{
			this.LikeId = likeId;
			this.LikerUserId = likerUserId;
			this.TweetId = tweetId;

			this.LikerUserIdEntity = nameof(ApiResponse.Users);
			this.TweetIdEntity = nameof(ApiResponse.Tweets);
		}

		[JsonProperty]
		public int LikeId { get; private set; }

		[JsonProperty]
		public int LikerUserId { get; private set; }

		[JsonProperty]
		public string LikerUserIdEntity { get; set; }

		[JsonProperty]
		public int TweetId { get; private set; }

		[JsonProperty]
		public string TweetIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>2372cbd04fb582b061bce100e39bf8a6</Hash>
</Codenesium>*/