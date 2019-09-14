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
			int id,
			DateTime creationDate,
			int postId,
			int? score,
			string text,
			int? userId)
		{
			this.Id = id;
			this.CreationDate = creationDate;
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
    <Hash>cb70dcee9daa07dbe2689b79a97e1a77</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/