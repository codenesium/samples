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
			int tweetId,
			string content,
			DateTime date,
			int taggedUserId,
			TimeSpan time)
		{
			this.TweetId = tweetId;
			this.Content = content;
			this.Date = date;
			this.TaggedUserId = taggedUserId;
			this.Time = time;
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
		public virtual User TaggedUserIdNavigation { get; private set; }

		public void SetTaggedUserIdNavigation(User item)
		{
			this.TaggedUserIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>f506bb88248fe7d0d1fe7ce8657eefea</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/