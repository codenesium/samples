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
		public int LikerUserId { get; private set; }

		[Key]
		[Column("tweet_id")]
		public int TweetId { get; private set; }

		[ForeignKey("LikerUserId")]
		public virtual User UserNavigation { get; private set; }

		[ForeignKey("TweetId")]
		public virtual Tweet TweetNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>ef8c5ea4e35bb3bbeaa87a52c7b72ad5</Hash>
</Codenesium>*/