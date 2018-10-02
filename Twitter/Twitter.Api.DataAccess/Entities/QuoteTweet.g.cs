using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TwitterNS.Api.DataAccess
{
	[Table("Quote_Tweet", Schema="dbo")]
	public partial class QuoteTweet : AbstractEntity
	{
		public QuoteTweet()
		{
		}

		public virtual void SetProperties(
			string content,
			DateTime date,
			int quoteTweetId,
			int retweeterUserId,
			int sourceTweetId,
			TimeSpan time)
		{
			this.Content = content;
			this.Date = date;
			this.QuoteTweetId = quoteTweetId;
			this.RetweeterUserId = retweeterUserId;
			this.SourceTweetId = sourceTweetId;
			this.Time = time;
		}

		[MaxLength(140)]
		[Column("content")]
		public string Content { get; private set; }

		[Column("date")]
		public DateTime Date { get; private set; }

		[Key]
		[Column("quote_tweet_id")]
		public int QuoteTweetId { get; private set; }

		[Column("retweeter_user_id")]
		public int RetweeterUserId { get; private set; }

		[Column("source_tweet_id")]
		public int SourceTweetId { get; private set; }

		[Column("time")]
		public TimeSpan Time { get; private set; }

		[ForeignKey("RetweeterUserId")]
		public virtual User UserNavigation { get; private set; }

		[ForeignKey("SourceTweetId")]
		public virtual Tweet TweetNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>208ca989f5c89562aa43bc1aa477921a</Hash>
</Codenesium>*/