using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TwitterNS.Api.DataAccess
{
	[Table("Retweet", Schema="dbo")]
	public partial class Retweet : AbstractEntity
	{
		public Retweet()
		{
		}

		public virtual void SetProperties(
			int id,
			DateTime? date,
			int? retwitterUserId,
			TimeSpan? time,
			int tweetTweetId)
		{
			this.Id = id;
			this.Date = date;
			this.RetwitterUserId = retwitterUserId;
			this.Time = time;
			this.TweetTweetId = tweetTweetId;
		}

		[Column("date")]
		public virtual DateTime? Date { get; private set; }

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[Column("retwitter_user_id")]
		public virtual int? RetwitterUserId { get; private set; }

		[Column("time")]
		public virtual TimeSpan? Time { get; private set; }

		[Column("tweet_tweet_id")]
		public virtual int TweetTweetId { get; private set; }

		[ForeignKey("RetwitterUserId")]
		public virtual User RetwitterUserIdNavigation { get; private set; }

		public void SetRetwitterUserIdNavigation(User item)
		{
			this.RetwitterUserIdNavigation = item;
		}

		[ForeignKey("TweetTweetId")]
		public virtual Tweet TweetTweetIdNavigation { get; private set; }

		public void SetTweetTweetIdNavigation(Tweet item)
		{
			this.TweetTweetIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>3686bd7f3ba00ab00a6f1d112adf7df1</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/