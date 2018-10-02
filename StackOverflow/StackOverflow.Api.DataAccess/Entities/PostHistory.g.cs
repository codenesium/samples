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
		public string Comment { get; private set; }

		[Column("CreationDate")]
		public DateTime CreationDate { get; private set; }

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("Id")]
		public int Id { get; private set; }

		[Column("PostHistoryTypeId")]
		public int PostHistoryTypeId { get; private set; }

		[Column("PostId")]
		public int PostId { get; private set; }

		[MaxLength(36)]
		[Column("RevisionGUID")]
		public string RevisionGUID { get; private set; }

		[MaxLength(1073741823)]
		[Column("Text")]
		public string Text { get; private set; }

		[MaxLength(40)]
		[Column("UserDisplayName")]
		public string UserDisplayName { get; private set; }

		[Column("UserId")]
		public int? UserId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>ab24bbed49f2fb3fcba56fcde58ed380</Hash>
</Codenesium>*/