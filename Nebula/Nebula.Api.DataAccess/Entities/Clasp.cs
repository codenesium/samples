using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace NebulaNS.Api.DataAccess
{
        [Table("Clasp", Schema="dbo")]
        public partial class Clasp:AbstractEntity
        {
                public Clasp()
                {
                }

                public void SetProperties(
                        int id,
                        int nextChainId,
                        int previousChainId)
                {
                        this.Id = id;
                        this.NextChainId = nextChainId;
                        this.PreviousChainId = previousChainId;
                }

                [Key]
                [Column("id", TypeName="int")]
                public int Id { get; private set; }

                [Column("nextChainId", TypeName="int")]
                public int NextChainId { get; private set; }

                [Column("previousChainId", TypeName="int")]
                public int PreviousChainId { get; private set; }

                [ForeignKey("NextChainId")]
                public virtual Chain Chain { get; set; }

                [ForeignKey("PreviousChainId")]
                public virtual Chain Chain1 { get; set; }
        }
}

/*<Codenesium>
    <Hash>3fc58a9cbe3ad205ac770a6d390e6a03</Hash>
</Codenesium>*/