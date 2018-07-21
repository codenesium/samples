using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

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
    <Hash>86a47c18e74b33caec585d06c8b4bb2c</Hash>
</Codenesium>*/