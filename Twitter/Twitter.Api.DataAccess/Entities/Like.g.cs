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
	}
}

/*<Codenesium>
    <Hash>b4d2092959551066630f88e1dddd1119</Hash>
</Codenesium>*/