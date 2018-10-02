using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TwitterNS.Api.Contracts
{
	public partial class ApiLikeRequestModel : AbstractApiRequestModel
	{
		public ApiLikeRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int likerUserId,
			int tweetId)
		{
			this.LikerUserId = likerUserId;
			this.TweetId = tweetId;
		}

		[Required]
		[JsonProperty]
		public int LikerUserId { get; private set; }

		[Required]
		[JsonProperty]
		public int TweetId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>e4024f2b86ec7b26fac2a9e4514b2448</Hash>
</Codenesium>*/