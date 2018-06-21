using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NebulaNS.Api.DataAccess
{
        [Table("Clasp", Schema="dbo")]
        public partial class Clasp : AbstractEntity
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
                [Column("id")]
                public int Id { get; private set; }

                [Column("nextChainId")]
                public int NextChainId { get; private set; }

                [Column("previousChainId")]
                public int PreviousChainId { get; private set; }

                [ForeignKey("NextChainId")]
                public virtual Chain Chain { get; set; }

                [ForeignKey("PreviousChainId")]
                public virtual Chain Chain1 { get; set; }
        }
}

/*<Codenesium>
    <Hash>8de8279c6dbb9255b88a51650ef79e02</Hash>
</Codenesium>*/