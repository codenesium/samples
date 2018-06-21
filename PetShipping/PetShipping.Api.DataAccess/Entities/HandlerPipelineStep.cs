using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShippingNS.Api.DataAccess
{
        [Table("HandlerPipelineStep", Schema="dbo")]
        public partial class HandlerPipelineStep : AbstractEntity
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

                [Column("handlerId")]
                public int HandlerId { get; private set; }

                [Key]
                [Column("id")]
                public int Id { get; private set; }

                [Column("pipelineStepId")]
                public int PipelineStepId { get; private set; }

                [ForeignKey("HandlerId")]
                public virtual Handler Handler { get; set; }

                [ForeignKey("PipelineStepId")]
                public virtual PipelineStep PipelineStep { get; set; }
        }
}

/*<Codenesium>
    <Hash>d23e5a1332bfd5e6894a53465e73ec82</Hash>
</Codenesium>*/