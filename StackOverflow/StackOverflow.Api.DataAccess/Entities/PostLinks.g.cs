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
		public virtual LinkTypes LinkTypeIdNavigation { get; private set; }

		public void SetLinkTypeIdNavigation(LinkTypes item)
		{
			this.LinkTypeIdNavigation = item;
		}

		[ForeignKey("PostId")]
		public virtual Posts PostIdNavigation { get; private set; }

		public void SetPostIdNavigation(Posts item)
		{
			this.PostIdNavigation = item;
		}

		[ForeignKey("RelatedPostId")]
		public virtual Posts RelatedPostIdNavigation { get; private set; }

		public void SetRelatedPostIdNavigation(Posts item)
		{
			this.RelatedPostIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>b63a94bab862cffc5fbdc66e7a48e089</Hash>
</Codenesium>*/