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
			int quoteTweetId,
			string content,
			DateTime date,
			int retweeterUserId,
			int sourceTweetId,
			TimeSpan time)
		{
			this.QuoteTweetId = quoteTweetId;
			this.Content = content;
			this.Date = date;
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
		public virtual User RetweeterUserIdNavigation { get; private set; }

		public void SetRetweeterUserIdNavigation(User item)
		{
			this.RetweeterUserIdNavigation = item;
		}

		[ForeignKey("SourceTweetId")]
		public virtual Tweet SourceTweetIdNavigation { get; private set; }

		public void SetSourceTweetIdNavigation(Tweet item)
		{
			this.SourceTweetIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>b60c2893486415a056e439b0bfabe91d</Hash>
</Codenesium>*/