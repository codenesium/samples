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
                public virtual PipelineStatus PipelineStatusNavigation { get; private set; }
        }
}

/*<Codenesium>
    <Hash>a6a05e7df56606c6694cf8c8dc1896ea</Hash>
</Codenesium>*/