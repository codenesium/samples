using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TwitterNS.Api.DataAccess
{
	[Table("Messenger", Schema="dbo")]
	public partial class Messenger : AbstractEntity
	{
		public Messenger()
		{
		}

		public virtual void SetProperties(
			int id,
			DateTime? date,
			int? fromUserId,
			int? messageId,
			TimeSpan? time,
			int toUserId,
			int? userId)
		{
			this.Id = id;
			this.Date = date;
			this.FromUserId = fromUserId;
			this.MessageId = messageId;
			this.Time = time;
			this.ToUserId = toUserId;
			this.UserId = userId;
		}

		[Column("date")]
		public virtual DateTime? Date { get; private set; }

		[Column("from_user_id")]
		public virtual int? FromUserId { get; private set; }

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[Column("message_id")]
		public virtual int? MessageId { get; private set; }

		[Column("time")]
		public virtual TimeSpan? Time { get; private set; }

		[Column("to_user_id")]
		public virtual int ToUserId { get; private set; }

		[Column("user_id")]
		public virtual int? UserId { get; private set; }

		[ForeignKey("MessageId")]
		public virtual Message MessageIdNavigation { get; private set; }

		public void SetMessageIdNavigation(Message item)
		{
			this.MessageIdNavigation = item;
		}

		[ForeignKey("ToUserId")]
		public virtual User ToUserIdNavigation { get; private set; }

		public void SetToUserIdNavigation(User item)
		{
			this.ToUserIdNavigation = item;
		}

		[ForeignKey("UserId")]
		public virtual User UserIdNavigation { get; private set; }

		public void SetUserIdNavigation(User item)
		{
			this.UserIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>44a37a936a03600f68722b3c3ae969ba</Hash>
</Codenesium>*/