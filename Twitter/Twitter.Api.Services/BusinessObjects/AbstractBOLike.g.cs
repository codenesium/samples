using Codenesium.DataConversionExtensions;
using System;

namespace TwitterNS.Api.Services
{
	public abstract class AbstractBOLike : AbstractBusinessObject
	{
		public AbstractBOLike()
			: base()
		{
		}

		public virtual void SetProperties(int likeId,
		                                  int likerUserId,
		                                  int tweetId)
		{
			this.LikeId = likeId;
			this.LikerUserId = likerUserId;
			this.TweetId = tweetId;
		}

		public int LikeId { get; private set; }

		public int LikerUserId { get; private set; }

		public int TweetId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>b4d065673b08e000c7b32a1351c30e4b</Hash>
</Codenesium>*/