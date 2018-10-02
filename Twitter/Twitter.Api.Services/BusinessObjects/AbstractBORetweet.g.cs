using Codenesium.DataConversionExtensions;
using System;

namespace TwitterNS.Api.Services
{
	public abstract class AbstractBORetweet : AbstractBusinessObject
	{
		public AbstractBORetweet()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  DateTime? date,
		                                  int? retwitterUserId,
		                                  TimeSpan? time,
		                                  int tweetTweetId)
		{
			this.Date = date;
			this.Id = id;
			this.RetwitterUserId = retwitterUserId;
			this.Time = time;
			this.TweetTweetId = tweetTweetId;
		}

		public DateTime? Date { get; private set; }

		public int Id { get; private set; }

		public int? RetwitterUserId { get; private set; }

		public TimeSpan? Time { get; private set; }

		public int TweetTweetId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>f738cb4d082e369111c8d6d2c886b13e</Hash>
</Codenesium>*/