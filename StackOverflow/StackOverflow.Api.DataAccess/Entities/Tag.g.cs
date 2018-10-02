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
		public int Count { get; private set; }

		[Column("ExcerptPostId")]
		public int ExcerptPostId { get; private set; }

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("Id")]
		public int Id { get; private set; }

		[MaxLength(150)]
		[Column("TagName")]
		public string TagName { get; private set; }

		[Column("WikiPostId")]
		public int WikiPostId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>40bf8a6f1cf62ee2cb65b819921d7135</Hash>
</Codenesium>*/