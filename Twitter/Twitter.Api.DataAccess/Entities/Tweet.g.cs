using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TwitterNS.Api.DataAccess
{
	[Table("Tweet", Schema="dbo")]
	public partial class Tweet : AbstractEntity
	{
		public Tweet()
		{
		}

		public virtual void SetProperties(
			int tweetId,
			string content,
			DateTime date,
			int locationId,
			TimeSpan time,
			int userUserId)
		{
			this.TweetId = tweetId;
			this.Content = content;
			this.Date = date;
			this.LocationId = locationId;
			this.Time = time;
			this.UserUserId = userUserId;
		}

		[MaxLength(140)]
		[Column("content")]
		public virtual string Content { get; private set; }

		[Column("date")]
		public virtual DateTime Date { get; private set; }

		[Column("location_id")]
		public virtual int LocationId { get; private set; }

		[Column("time")]
		public virtual TimeSpan Time { get; private set; }

		[Key]
		[Column("tweet_id")]
		public virtual int TweetId { get; private set; }

		[Column("user_user_id")]
		public virtual int UserUserId { get; private set; }

		[ForeignKey("LocationId")]
		public virtual Location LocationIdNavigation { get; private set; }

		public void SetLocationIdNavigation(Location item)
		{
			this.LocationIdNavigation = item;
		}

		[ForeignKey("UserUserId")]
		public virtual User UserUserIdNavigation { get; private set; }

		public void SetUserUserIdNavigation(User item)
		{
			this.UserUserIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>f66a9612509d5f5558402b782079f6be</Hash>
</Codenesium>*/