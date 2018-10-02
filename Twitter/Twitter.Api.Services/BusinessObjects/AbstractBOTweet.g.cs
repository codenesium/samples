using Codenesium.DataConversionExtensions;
using System;

namespace TwitterNS.Api.Services
{
	public abstract class AbstractBOTweet : AbstractBusinessObject
	{
		public AbstractBOTweet()
			: base()
		{
		}

		public virtual void SetProperties(int tweetId,
		                                  string content,
		                                  DateTime date,
		                                  int locationId,
		                                  TimeSpan time,
		                                  int userUserId)
		{
			this.Content = content;
			this.Date = date;
			this.LocationId = locationId;
			this.Time = time;
			this.TweetId = tweetId;
			this.UserUserId = userUserId;
		}

		public string Content { get; private set; }

		public DateTime Date { get; private set; }

		public int LocationId { get; private set; }

		public TimeSpan Time { get; private set; }

		public int TweetId { get; private set; }

		public int UserUserId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>529b1bbc2a92a449226d028e9040501a</Hash>
</Codenesium>*/