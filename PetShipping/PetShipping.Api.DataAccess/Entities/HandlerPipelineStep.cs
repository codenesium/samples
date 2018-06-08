using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace PetShippingNS.Api.DataAccess
{
        [Table("HandlerPipelineStep", Schema="dbo")]
        public partial class HandlerPipelineStep: AbstractEntity
        {
                public HandlerPipelineStep()
                {
                }

                public void SetProperties(
                        int handlerId,
                        int id,
                        int pipelineStepId)
                {
                        this.HandlerId = handlerId;
                        this.Id = id;
                        this.PipelineStepId = pipelineStepId;
                }

                [Column("handlerId", TypeName="int")]
                public int HandlerId { get; private set; }

                [Key]
                [Column("id", TypeName="int")]
                public int Id { get; private set; }

                [Column("pipelineStepId", TypeName="int")]
                public int PipelineStepId { get; private set; }

                [ForeignKey("HandlerId")]
                public virtual Handler Handler { get; set; }

                [ForeignKey("PipelineStepId")]
                public virtual PipelineStep PipelineStep { get; set; }
        }
}

/*<Codenesium>
    <Hash>1cfe65b0cb2c852854e275b2af7f1fa8</Hash>
</Codenesium>*/