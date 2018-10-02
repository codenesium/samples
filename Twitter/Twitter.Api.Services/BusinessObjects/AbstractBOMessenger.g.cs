using Codenesium.DataConversionExtensions;
using System;

namespace TwitterNS.Api.Services
{
	public abstract class AbstractBOMessenger : AbstractBusinessObject
	{
		public AbstractBOMessenger()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  DateTime? date,
		                                  int? fromUserId,
		                                  int? messageId,
		                                  TimeSpan? time,
		                                  int toUserId,
		                                  int? userId)
		{
			this.Date = date;
			this.FromUserId = fromUserId;
			this.Id = id;
			this.MessageId = messageId;
			this.Time = time;
			this.ToUserId = toUserId;
			this.UserId = userId;
		}

		public DateTime? Date { get; private set; }

		public int? FromUserId { get; private set; }

		public int Id { get; private set; }

		public int? MessageId { get; private set; }

		public TimeSpan? Time { get; private set; }

		public int ToUserId { get; private set; }

		public int? UserId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>af959377450011b0befe91173eb79a45</Hash>
</Codenesium>*/