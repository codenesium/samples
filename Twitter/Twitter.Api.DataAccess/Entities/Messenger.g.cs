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
		public DateTime? Date { get; private set; }

		[Column("from_user_id")]
		public int? FromUserId { get; private set; }

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public int Id { get; private set; }

		[Column("message_id")]
		public int? MessageId { get; private set; }

		[Column("time")]
		public TimeSpan? Time { get; private set; }

		[Column("to_user_id")]
		public int ToUserId { get; private set; }

		[Column("user_id")]
		public int? UserId { get; private set; }

		[ForeignKey("MessageId")]
		public virtual Message MessageNavigation { get; private set; }

		[ForeignKey("ToUserId")]
		public virtual User UserNavigation { get; private set; }

		[ForeignKey("UserId")]
		public virtual User User1Navigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>831feff2ea99795a0c505a2b4356a52e</Hash>
</Codenesium>*/