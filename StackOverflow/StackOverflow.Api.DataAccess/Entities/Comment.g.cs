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
		public DateTime CreationDate { get; private set; }

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("Id")]
		public int Id { get; private set; }

		[Column("PostId")]
		public int PostId { get; private set; }

		[Column("Score")]
		public int? Score { get; private set; }

		[MaxLength(700)]
		[Column("Text")]
		public string Text { get; private set; }

		[Column("UserId")]
		public int? UserId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>af8885e1ac411562acfc53c0c9f85769</Hash>
</Codenesium>*/