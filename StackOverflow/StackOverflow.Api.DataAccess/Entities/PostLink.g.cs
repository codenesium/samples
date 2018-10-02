using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StackOverflowNS.Api.DataAccess
{
	[Table("PostLinks", Schema="dbo")]
	public partial class PostLink : AbstractEntity
	{
		public PostLink()
		{
		}

		public virtual void SetProperties(
			DateTime creationDate,
			int id,
			int linkTypeId,
			int postId,
			int relatedPostId)
		{
			this.CreationDate = creationDate;
			this.Id = id;
			this.LinkTypeId = linkTypeId;
			this.PostId = postId;
			this.RelatedPostId = relatedPostId;
		}

		[Column("CreationDate")]
		public DateTime CreationDate { get; private set; }

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("Id")]
		public int Id { get; private set; }

		[Column("LinkTypeId")]
		public int LinkTypeId { get; private set; }

		[Column("PostId")]
		public int PostId { get; private set; }

		[Column("RelatedPostId")]
		public int RelatedPostId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>422e5f6e64303a8244a5b4af89e85668</Hash>
</Codenesium>*/