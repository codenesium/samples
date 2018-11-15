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
			DateTime? date,
			int id,
			int? retwitterUserId,
			TimeSpan? time,
			int tweetTweetId)
		{
			this.Date = date;
			this.Id = id;
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
		public virtual User UserNavigation { get; private set; }

		public void SetUserNavigation(User item)
		{
			this.UserNavigation = item;
		}

		[ForeignKey("TweetTweetId")]
		public virtual Tweet TweetNavigation { get; private set; }

		public void SetTweetNavigation(Tweet item)
		{
			this.TweetNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>d82e17a85327636966d3daf0f99e5984</Hash>
</Codenesium>*/