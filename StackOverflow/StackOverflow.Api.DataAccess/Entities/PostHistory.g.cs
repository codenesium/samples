using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StackOverflowNS.Api.DataAccess
{
	[Table("PostHistory", Schema="dbo")]
	public partial class PostHistory : AbstractEntity
	{
		public PostHistory()
		{
		}

		public virtual void SetProperties(
			int id,
			string comment,
			DateTime creationDate,
			int postHistoryTypeId,
			int postId,
			string revisionGUID,
			string text,
			string userDisplayName,
			int? userId)
		{
			this.Id = id;
			this.Comment = comment;
			this.CreationDate = creationDate;
			this.PostHistoryTypeId = postHistoryTypeId;
			this.PostId = postId;
			this.RevisionGUID = revisionGUID;
			this.Text = text;
			this.UserDisplayName = userDisplayName;
			this.UserId = userId;
		}

		[MaxLength(1073741823)]
		[Column("Comment")]
		public virtual string Comment { get; private set; }

		[Column("CreationDate")]
		public virtual DateTime CreationDate { get; private set; }

		[Key]
		[Column("Id")]
		public virtual int Id { get; private set; }

		[Column("PostHistoryTypeId")]
		public virtual int PostHistoryTypeId { get; private set; }

		[Column("PostId")]
		public virtual int PostId { get; private set; }

		[MaxLength(36)]
		[Column("RevisionGUID")]
		public virtual string RevisionGUID { get; private set; }

		[MaxLength(1073741823)]
		[Column("Text")]
		public virtual string Text { get; private set; }

		[MaxLength(40)]
		[Column("UserDisplayName")]
		public virtual string UserDisplayName { get; private set; }

		[Column("UserId")]
		public virtual int? UserId { get; private set; }

		[ForeignKey("PostHistoryTypeId")]
		public virtual PostHistoryTypes PostHistoryTypeIdNavigation { get; private set; }

		public void SetPostHistoryTypeIdNavigation(PostHistoryTypes item)
		{
			this.PostHistoryTypeIdNavigation = item;
		}

		[ForeignKey("PostId")]
		public virtual Posts PostIdNavigation { get; private set; }

		public void SetPostIdNavigation(Posts item)
		{
			this.PostIdNavigation = item;
		}

		[ForeignKey("UserId")]
		public virtual Users UserIdNavigation { get; private set; }

		public void SetUserIdNavigation(Users item)
		{
			this.UserIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>7a6534aeb82c0a5e2c5a169dc28b313b</Hash>
</Codenesium>*/