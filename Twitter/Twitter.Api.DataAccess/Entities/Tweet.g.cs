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
			string content,
			DateTime date,
			int locationId,
			TimeSpan time,
			int tweetId,
			int userUserId)
		{
			this.Content = content;
			this.Date = date;
			this.LocationId = locationId;
			this.Time = time;
			this.TweetId = tweetId;
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
		public virtual Location LocationNavigation { get; private set; }

		public void SetLocationNavigation(Location item)
		{
			this.LocationNavigation = item;
		}

		[ForeignKey("UserUserId")]
		public virtual User UserNavigation { get; private set; }

		public void SetUserNavigation(User item)
		{
			this.UserNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>0e4bfa254101638a8b4e77d2b9e0b50a</Hash>
</Codenesium>*/