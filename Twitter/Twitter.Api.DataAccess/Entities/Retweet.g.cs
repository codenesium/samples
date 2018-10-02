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
		public DateTime? Date { get; private set; }

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public int Id { get; private set; }

		[Column("retwitter_user_id")]
		public int? RetwitterUserId { get; private set; }

		[Column("time")]
		public TimeSpan? Time { get; private set; }

		[Column("tweet_tweet_id")]
		public int TweetTweetId { get; private set; }

		[ForeignKey("RetwitterUserId")]
		public virtual User UserNavigation { get; private set; }

		[ForeignKey("TweetTweetId")]
		public virtual Tweet TweetNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>5bb6a3f4685f96092d01b75cd942f09b</Hash>
</Codenesium>*/