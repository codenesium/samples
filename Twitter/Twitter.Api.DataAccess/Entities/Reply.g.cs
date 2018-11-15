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
		public virtual User UserNavigation { get; private set; }

		public void SetUserNavigation(User item)
		{
			this.UserNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>6476546834212f79ad1628233dcfb8dc</Hash>
</Codenesium>*/