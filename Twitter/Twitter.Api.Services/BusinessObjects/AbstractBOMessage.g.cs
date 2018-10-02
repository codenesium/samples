using Codenesium.DataConversionExtensions;
using System;

namespace TwitterNS.Api.Services
{
	public abstract class AbstractBOMessage : AbstractBusinessObject
	{
		public AbstractBOMessage()
			: base()
		{
		}

		public virtual void SetProperties(int messageId,
		                                  string content,
		                                  int? senderUserId)
		{
			this.Content = content;
			this.MessageId = messageId;
			this.SenderUserId = senderUserId;
		}

		public string Content { get; private set; }

		public int MessageId { get; private set; }

		public int? SenderUserId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>9f1536ab0c3ad14ab2d4d2bc9513005b</Hash>
</Codenesium>*/