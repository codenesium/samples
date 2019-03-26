using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StackOverflowNS.Api.DataAccess
{
	[Table("Tags", Schema="dbo")]
	public partial class Tag : AbstractEntity
	{
		public Tag()
		{
		}

		public virtual void SetProperties(
			int id,
			int count,
			int excerptPostId,
			string tagName,
			int wikiPostId)
		{
			this.Id = id;
			this.Count = count;
			this.ExcerptPostId = excerptPostId;
			this.TagName = tagName;
			this.WikiPostId = wikiPostId;
		}

		[Column("Count")]
		public virtual int Count { get; private set; }

		[Column("ExcerptPostId")]
		public virtual int ExcerptPostId { get; private set; }

		[Key]
		[Column("Id")]
		public virtual int Id { get; private set; }

		[MaxLength(150)]
		[Column("TagName")]
		public virtual string TagName { get; private set; }

		[Column("WikiPostId")]
		public virtual int WikiPostId { get; private set; }

		[ForeignKey("ExcerptPostId")]
		public virtual Post ExcerptPostIdNavigation { get; private set; }

		public void SetExcerptPostIdNavigation(Post item)
		{
			this.ExcerptPostIdNavigation = item;
		}

		[ForeignKey("WikiPostId")]
		public virtual Post WikiPostIdNavigation { get; private set; }

		public void SetWikiPostIdNavigation(Post item)
		{
			this.WikiPostIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>d397a68667a9d2d0860384d3355f7543</Hash>
</Codenesium>*/