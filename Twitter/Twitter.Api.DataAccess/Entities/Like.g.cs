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
			int likeId,
			int likerUserId,
			int tweetId)
		{
			this.LikeId = likeId;
			this.LikerUserId = likerUserId;
			this.TweetId = tweetId;
		}

		[Key]
		[Column("like_id")]
		public int LikeId { get; private set; }

		[Column("liker_user_id")]
		public int LikerUserId { get; private set; }

		[Column("tweet_id")]
		public int TweetId { get; private set; }

		[ForeignKey("LikerUserId")]
		public virtual User UserNavigation { get; private set; }

		[ForeignKey("TweetId")]
		public virtual Tweet TweetNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>745ebfc2f96fef6ef345cfefa625c8e9</Hash>
</Codenesium>*/