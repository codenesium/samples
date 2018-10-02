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
		public string Content { get; private set; }

		[Key]
		[Column("message_id")]
		public int MessageId { get; private set; }

		[Column("sender_user_id")]
		public int? SenderUserId { get; private set; }

		[ForeignKey("SenderUserId")]
		public virtual User UserNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>b6360d856766b14c2c02343e59d08be1</Hash>
</Codenesium>*/