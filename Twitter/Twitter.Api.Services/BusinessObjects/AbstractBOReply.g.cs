using Codenesium.DataConversionExtensions;
using System;

namespace TwitterNS.Api.Services
{
	public abstract class AbstractBOReply : AbstractBusinessObject
	{
		public AbstractBOReply()
			: base()
		{
		}

		public virtual void SetProperties(int replyId,
		                                  string content,
		                                  DateTime date,
		                                  int replierUserId,
		                                  TimeSpan time)
		{
			this.Content = content;
			this.Date = date;
			this.ReplierUserId = replierUserId;
			this.ReplyId = replyId;
			this.Time = time;
		}

		public string Content { get; private set; }

		public DateTime Date { get; private set; }

		public int ReplierUserId { get; private set; }

		public int ReplyId { get; private set; }

		public TimeSpan Time { get; private set; }
	}
}

/*<Codenesium>
    <Hash>eb5b7609a8686924be82d0db452f9fcc</Hash>
</Codenesium>*/