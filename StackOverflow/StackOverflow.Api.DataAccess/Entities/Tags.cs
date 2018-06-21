using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StackOverflowNS.Api.DataAccess
{
        [Table("Tags", Schema="dbo")]
        public partial class Tags : AbstractEntity
        {
                public Tags()
                {
                }

                public void SetProperties(
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
                [Column("Id")]
                public int Id { get; private set; }

                [Column("TagName")]
                public string TagName { get; private set; }

                [Column("WikiPostId")]
                public int WikiPostId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>e6e49e9e5cc7c332544b82063e10886f</Hash>
</Codenesium>*/