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
		public virtual DateTime CreationDate { get; private set; }

		[Key]
		[Column("Id")]
		public virtual int Id { get; private set; }

		[Column("LinkTypeId")]
		public virtual int LinkTypeId { get; private set; }

		[Column("PostId")]
		public virtual int PostId { get; private set; }

		[Column("RelatedPostId")]
		public virtual int RelatedPostId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>c2a7b3c8c20d503d583851938e782296</Hash>
</Codenesium>*/