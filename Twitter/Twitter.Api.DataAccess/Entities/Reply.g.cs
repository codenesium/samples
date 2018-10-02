using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TwitterNS.Api.DataAccess
{
	[Table("Reply", Schema="dbo")]
	public partial class Reply : AbstractEntity
	{
		public Reply()
		{
		}

		public virtual void SetProperties(
			string content,
			DateTime date,
			int replierUserId,
			int replyId,
			TimeSpan time)
		{
			this.Content = content;
			this.Date = date;
			this.ReplierUserId = replierUserId;
			this.ReplyId = replyId;
			this.Time = time;
		}

		[MaxLength(140)]
		[Column("content")]
		public string Content { get; private set; }

		[Column("date")]
		public DateTime Date { get; private set; }

		[Column("replier_user_id")]
		public int ReplierUserId { get; private set; }

		[Key]
		[Column("reply_id")]
		public int ReplyId { get; private set; }

		[Column("time")]
		public TimeSpan Time { get; private set; }

		[ForeignKey("ReplierUserId")]
		public virtual User UserNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>a7e60e78b8531fd708a4892f882424d7</Hash>
</Codenesium>*/