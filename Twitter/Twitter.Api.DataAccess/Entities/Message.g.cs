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
			string content,
			int messageId,
			int? senderUserId)
		{
			this.Content = content;
			this.MessageId = messageId;
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
		public virtual User UserNavigation { get; private set; }

		public void SetUserNavigation(User item)
		{
			this.UserNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>a321b41855df01c84d96bb1cc376f0f5</Hash>
</Codenesium>*/