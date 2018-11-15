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
			string comment,
			DateTime creationDate,
			int id,
			int postHistoryTypeId,
			int postId,
			string revisionGUID,
			string text,
			string userDisplayName,
			int? userId)
		{
			this.Comment = comment;
			this.CreationDate = creationDate;
			this.Id = id;
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
	}
}

/*<Codenesium>
    <Hash>f7f9ce744bbf030a3dbecd4edf16f3d6</Hash>
</Codenesium>*/