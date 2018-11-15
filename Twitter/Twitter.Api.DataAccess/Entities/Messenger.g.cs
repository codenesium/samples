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
			DateTime? date,
			int? fromUserId,
			int id,
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
		public virtual Message MessageNavigation { get; private set; }

		public void SetMessageNavigation(Message item)
		{
			this.MessageNavigation = item;
		}

		[ForeignKey("ToUserId")]
		public virtual User UserNavigation { get; private set; }

		public void SetUserNavigation(User item)
		{
			this.UserNavigation = item;
		}

		[ForeignKey("UserId")]
		public virtual User User1Navigation { get; private set; }

		public void SetUser1Navigation(User item)
		{
			this.User1Navigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>9053f062fc8af7e60394d941c8563e56</Hash>
</Codenesium>*/