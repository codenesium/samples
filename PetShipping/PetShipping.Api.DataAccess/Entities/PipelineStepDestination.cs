using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace PetShippingNS.Api.DataAccess
{
        [Table("PipelineStepDestination", Schema="dbo")]
        public partial class PipelineStepDestination: AbstractEntity
        {
                public PipelineStepDestination()
                {
                }

                public void SetProperties(
                        int destinationId,
                        int id,
                        int pipelineStepId)
                {
                        this.DestinationId = destinationId;
                        this.Id = id;
                        this.PipelineStepId = pipelineStepId;
                }

                [Column("destinationId", TypeName="int")]
                public int DestinationId { get; private set; }

                [Key]
                [Column("id", TypeName="int")]
                public int Id { get; private set; }

                [Column("pipelineStepId", TypeName="int")]
                public int PipelineStepId { get; private set; }

                [ForeignKey("DestinationId")]
                public virtual Destination Destination { get; set; }

                [ForeignKey("PipelineStepId")]
                public virtual PipelineStep PipelineStep { get; set; }
        }
}

/*<Codenesium>
    <Hash>1e0ca76ebadfa62f9872871fc6ddc50f</Hash>
</Codenesium>*/