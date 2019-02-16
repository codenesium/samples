using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TwitterNS.Api.DataAccess
{
	[Table("Message", Schema="dbo")]
	public partial class Message : AbstractEntity
	{
		public Message()
		{
		}

		public virtual void SetProperties(
			int messageId,
			string content,
			int? senderUserId)
		{
			this.MessageId = messageId;
			this.Content = content;
			this.SenderUserId = senderUserId;
		}

		[MaxLength(128)]
		[Column("content")]
		public virtual string Content { get; private set; }

		[Key]
		[Column("message_id")]
		public virtual int MessageId { get; private set; }

		[Column("sender_user_id")]
		public virtual int? SenderUserId { get; private set; }

		[ForeignKey("SenderUserId")]
		public virtual User SenderUserIdNavigation { get; private set; }

		public void SetSenderUserIdNavigation(User item)
		{
			this.SenderUserIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>cf075507f023b4ff9fcbe00fbdd7695e</Hash>
</Codenesium>*/