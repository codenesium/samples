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
			int replyId,
			string content,
			DateTime date,
			int replierUserId,
			TimeSpan time)
		{
			this.ReplyId = replyId;
			this.Content = content;
			this.Date = date;
			this.ReplierUserId = replierUserId;
			this.Time = time;
		}

		[MaxLength(140)]
		[Column("content")]
		public virtual string Content { get; private set; }

		[Column("date")]
		public virtual DateTime Date { get; private set; }

		[Column("replier_user_id")]
		public virtual int ReplierUserId { get; private set; }

		[Key]
		[Column("reply_id")]
		public virtual int ReplyId { get; private set; }

		[Column("time")]
		public virtual TimeSpan Time { get; private set; }

		[ForeignKey("ReplierUserId")]
		public virtual User ReplierUserIdNavigation { get; private set; }

		public void SetReplierUserIdNavigation(User item)
		{
			this.ReplierUserIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>c7e24fe6a99dabcb947e72fffa7fe64a</Hash>
</Codenesium>*/