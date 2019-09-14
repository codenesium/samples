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
			int id,
			DateTime creationDate,
			int linkTypeId,
			int postId,
			int relatedPostId)
		{
			this.Id = id;
			this.CreationDate = creationDate;
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

		[ForeignKey("LinkTypeId")]
		public virtual LinkType LinkTypeIdNavigation { get; private set; }

		public void SetLinkTypeIdNavigation(LinkType item)
		{
			this.LinkTypeIdNavigation = item;
		}

		[ForeignKey("PostId")]
		public virtual Post PostIdNavigation { get; private set; }

		public void SetPostIdNavigation(Post item)
		{
			this.PostIdNavigation = item;
		}

		[ForeignKey("RelatedPostId")]
		public virtual Post RelatedPostIdNavigation { get; private set; }

		public void SetRelatedPostIdNavigation(Post item)
		{
			this.RelatedPostIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>c7cd692a7cdb73711ab2900d4abb4197</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/