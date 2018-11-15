using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TwitterNS.Api.DataAccess
{
	[Table("QuoteTweet", Schema="dbo")]
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
		public virtual string Content { get; private set; }

		[Column("date")]
		public virtual DateTime Date { get; private set; }

		[Key]
		[Column("quote_tweet_id")]
		public virtual int QuoteTweetId { get; private set; }

		[Column("retweeter_user_id")]
		public virtual int RetweeterUserId { get; private set; }

		[Column("source_tweet_id")]
		public virtual int SourceTweetId { get; private set; }

		[Column("time")]
		public virtual TimeSpan Time { get; private set; }

		[ForeignKey("RetweeterUserId")]
		public virtual User UserNavigation { get; private set; }

		public void SetUserNavigation(User item)
		{
			this.UserNavigation = item;
		}

		[ForeignKey("SourceTweetId")]
		public virtual Tweet TweetNavigation { get; private set; }

		public void SetTweetNavigation(Tweet item)
		{
			this.TweetNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>a297edff1b720fb2a376cf047659fb81</Hash>
</Codenesium>*/