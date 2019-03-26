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
		public virtual PostHistoryType PostHistoryTypeIdNavigation { get; private set; }

		public void SetPostHistoryTypeIdNavigation(PostHistoryType item)
		{
			this.PostHistoryTypeIdNavigation = item;
		}

		[ForeignKey("PostId")]
		public virtual Post PostIdNavigation { get; private set; }

		public void SetPostIdNavigation(Post item)
		{
			this.PostIdNavigation = item;
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
    <Hash>ddfa02f6411c4c01cbca930e73ab4b4e</Hash>
</Codenesium>*/