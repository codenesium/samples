using Codenesium.DataConversionExtensions;
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

                public virtual void SetProperties(
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
    <Hash>3d0678bd96c214673f7d2b7b1e49d9a0</Hash>
</Codenesium>*/