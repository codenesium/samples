using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PetShippingNS.Api.DataAccess
{
        [Table("PipelineStepDestination", Schema="dbo")]
        public partial class PipelineStepDestination : AbstractEntity
        {
                public PipelineStepDestination()
                {
                }

                public virtual void SetProperties(
                        int destinationId,
                        int id,
                        int pipelineStepId)
                {
                        this.DestinationId = destinationId;
                        this.Id = id;
                        this.PipelineStepId = pipelineStepId;
                }

                [Column("destinationId")]
                public int DestinationId { get; private set; }

                [Key]
                [Column("id")]
                public int Id { get; private set; }

                [Column("pipelineStepId")]
                public int PipelineStepId { get; private set; }

                [ForeignKey("DestinationId")]
                public virtual Destination Destination { get; set; }

                [ForeignKey("PipelineStepId")]
                public virtual PipelineStep PipelineStep { get; set; }
        }
}

/*<Codenesium>
    <Hash>c73cf8a6d64d7a662595d99083af6d9a</Hash>
</Codenesium>*/