using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TwitterNS.Api.DataAccess
{
	[Table("Like", Schema="dbo")]
	public partial class Like : AbstractEntity
	{
		public Like()
		{
		}

		public virtual void SetProperties(
			int likerUserId,
			int tweetId)
		{
			this.LikerUserId = likerUserId;
			this.TweetId = tweetId;
		}

		[Key]
		[Column("liker_user_id")]
		public virtual int LikerUserId { get; private set; }

		[Key]
		[Column("tweet_id")]
		public virtual int TweetId { get; private set; }

		[ForeignKey("LikerUserId")]
		public virtual User LikerUserIdNavigation { get; private set; }

		public void SetLikerUserIdNavigation(User item)
		{
			this.LikerUserIdNavigation = item;
		}

		[ForeignKey("TweetId")]
		public virtual Tweet TweetIdNavigation { get; private set; }

		public void SetTweetIdNavigation(Tweet item)
		{
			this.TweetIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>c85a1459389a30701cd2368b327e54c4</Hash>
</Codenesium>*/