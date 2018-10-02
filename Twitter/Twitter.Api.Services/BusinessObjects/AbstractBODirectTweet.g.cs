using Codenesium.DataConversionExtensions;
using System;

namespace TwitterNS.Api.Services
{
	public abstract class AbstractBODirectTweet : AbstractBusinessObject
	{
		public AbstractBODirectTweet()
			: base()
		{
		}

		public virtual void SetProperties(int tweetId,
		                                  string content,
		                                  DateTime date,
		                                  int taggedUserId,
		                                  TimeSpan time)
		{
			this.Content = content;
			this.Date = date;
			this.TaggedUserId = taggedUserId;
			this.Time = time;
			this.TweetId = tweetId;
		}

		public string Content { get; private set; }

		public DateTime Date { get; private set; }

		public int TaggedUserId { get; private set; }

		public TimeSpan Time { get; private set; }

		public int TweetId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>5f5ce6d3f93eb0e140e2739beeab04c3</Hash>
</Codenesium>*/