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
                public virtual Destination DestinationNavigation { get; private set; }

                [ForeignKey("PipelineStepId")]
                public virtual PipelineStep PipelineStepNavigation { get; private set; }
        }
}

/*<Codenesium>
    <Hash>475dc79dfe70f82729f2ab87f6da3898</Hash>
</Codenesium>*/