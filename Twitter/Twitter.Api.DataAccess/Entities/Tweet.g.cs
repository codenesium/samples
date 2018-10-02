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
		public string Content { get; private set; }

		[Column("date")]
		public DateTime Date { get; private set; }

		[Column("location_id")]
		public int LocationId { get; private set; }

		[Column("time")]
		public TimeSpan Time { get; private set; }

		[Key]
		[Column("tweet_id")]
		public int TweetId { get; private set; }

		[Column("user_user_id")]
		public int UserUserId { get; private set; }

		[ForeignKey("LocationId")]
		public virtual Location LocationNavigation { get; private set; }

		[ForeignKey("UserUserId")]
		public virtual User UserNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>9b3c01c9f0fab7e828de989f2a69db8d</Hash>
</Codenesium>*/