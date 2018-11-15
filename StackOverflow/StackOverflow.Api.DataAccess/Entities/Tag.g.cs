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
			int count,
			int excerptPostId,
			int id,
			string tagName,
			int wikiPostId)
		{
			this.Count = count;
			this.ExcerptPostId = excerptPostId;
			this.Id = id;
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
	}
}

/*<Codenesium>
    <Hash>0cc19e3d40aaa7e660752bad3ce2582d</Hash>
</Codenesium>*/