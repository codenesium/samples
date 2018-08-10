using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StackOverflowNS.Api.DataAccess
{
	[Table("PostLinks", Schema="dbo")]
	public partial class PostLinks : AbstractEntity
	{
		public PostLinks()
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
    <Hash>e9391e4ab040ceb1500ccdd2e47b9b4c</Hash>
</Codenesium>*/