using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShippingNS.Api.DataAccess
{
        [Table("Pipeline", Schema="dbo")]
        public partial class Pipeline : AbstractEntity
        {
                public Pipeline()
                {
                }

                public void SetProperties(
                        int id,
                        int pipelineStatusId,
                        int saleId)
                {
                        this.Id = id;
                        this.PipelineStatusId = pipelineStatusId;
                        this.SaleId = saleId;
                }

                [Key]
                [Column("id")]
                public int Id { get; private set; }

                [Column("pipelineStatusId")]
                public int PipelineStatusId { get; private set; }

                [Column("saleId")]
                public int SaleId { get; private set; }

                [ForeignKey("PipelineStatusId")]
                public virtual PipelineStatus PipelineStatus { get; set; }
        }
}

/*<Codenesium>
    <Hash>4ca7034e7ba71bbf53f1ed56b7d91745</Hash>
</Codenesium>*/