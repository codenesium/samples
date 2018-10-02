using Codenesium.DataConversionExtensions;
using System;

namespace TwitterNS.Api.Services
{
	public abstract class AbstractBOQuoteTweet : AbstractBusinessObject
	{
		public AbstractBOQuoteTweet()
			: base()
		{
		}

		public virtual void SetProperties(int quoteTweetId,
		                                  string content,
		                                  DateTime date,
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

		public string Content { get; private set; }

		public DateTime Date { get; private set; }

		public int QuoteTweetId { get; private set; }

		public int RetweeterUserId { get; private set; }

		public int SourceTweetId { get; private set; }

		public TimeSpan Time { get; private set; }
	}
}

/*<Codenesium>
    <Hash>211490fbaa877cd63e824363f70a7873</Hash>
</Codenesium>*/