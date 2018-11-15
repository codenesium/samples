using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StackOverflowNS.Api.DataAccess
{
	[Table("Comments", Schema="dbo")]
	public partial class Comment : AbstractEntity
	{
		public Comment()
		{
		}

		public virtual void SetProperties(
			DateTime creationDate,
			int id,
			int postId,
			int? score,
			string text,
			int? userId)
		{
			this.CreationDate = creationDate;
			this.Id = id;
			this.PostId = postId;
			this.Score = score;
			this.Text = text;
			this.UserId = userId;
		}

		[Column("CreationDate")]
		public virtual DateTime CreationDate { get; private set; }

		[Key]
		[Column("Id")]
		public virtual int Id { get; private set; }

		[Column("PostId")]
		public virtual int PostId { get; private set; }

		[Column("Score")]
		public virtual int? Score { get; private set; }

		[MaxLength(700)]
		[Column("Text")]
		public virtual string Text { get; private set; }

		[Column("UserId")]
		public virtual int? UserId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>883f366c091201ac1ddb2b4947a96dd3</Hash>
</Codenesium>*/