using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TwitterNS.Api.DataAccess
{
	[Table("Direct_Tweets", Schema="dbo")]
	public partial class DirectTweet : AbstractEntity
	{
		public DirectTweet()
		{
		}

		public virtual void SetProperties(
			string content,
			DateTime date,
			int taggedUserId,
			TimeSpan time,
			int tweetId)
		{
			this.Content = content;
			this.Date = date;
			this.TaggedUserId = taggedUserId;
			this.Time = time;
			this.TweetId = tweetId;
		}

		[MaxLength(140)]
		[Column("content")]
		public string Content { get; private set; }

		[Column("date")]
		public DateTime Date { get; private set; }

		[Column("tagged_user_id")]
		public int TaggedUserId { get; private set; }

		[Column("time")]
		public TimeSpan Time { get; private set; }

		[Key]
		[Column("tweet_id")]
		public int TweetId { get; private set; }

		[ForeignKey("TaggedUserId")]
		public virtual User UserNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>f2892f910bf69b8ad0fb852979c84cf9</Hash>
</Codenesium>*/