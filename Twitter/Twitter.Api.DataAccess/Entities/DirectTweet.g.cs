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
		public virtual string Content { get; private set; }

		[Column("date")]
		public virtual DateTime Date { get; private set; }

		[Column("tagged_user_id")]
		public virtual int TaggedUserId { get; private set; }

		[Column("time")]
		public virtual TimeSpan Time { get; private set; }

		[Key]
		[Column("tweet_id")]
		public virtual int TweetId { get; private set; }

		[ForeignKey("TaggedUserId")]
		public virtual User UserNavigation { get; private set; }

		public void SetUserNavigation(User item)
		{
			this.UserNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>74c87bcc17616355d889ea4585b0c0ee</Hash>
</Codenesium>*/