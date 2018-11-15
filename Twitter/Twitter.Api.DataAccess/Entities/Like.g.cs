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
		public virtual User UserNavigation { get; private set; }

		public void SetUserNavigation(User item)
		{
			this.UserNavigation = item;
		}

		[ForeignKey("TweetId")]
		public virtual Tweet TweetNavigation { get; private set; }

		public void SetTweetNavigation(Tweet item)
		{
			this.TweetNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>436f030a51266a9be3b6915a5e6739ec</Hash>
</Codenesium>*/