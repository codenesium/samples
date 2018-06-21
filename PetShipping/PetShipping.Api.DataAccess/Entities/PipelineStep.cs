using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShippingNS.Api.DataAccess
{
        [Table("PipelineStep", Schema="dbo")]
        public partial class PipelineStep : AbstractEntity
        {
                public PipelineStep()
                {
                }

                public void SetProperties(
                        int id,
                        string name,
                        int pipelineStepStatusId,
                        int shipperId)
                {
                        this.Id = id;
                        this.Name = name;
                        this.PipelineStepStatusId = pipelineStepStatusId;
                        this.ShipperId = shipperId;
                }

                [Key]
                [Column("id")]
                public int Id { get; private set; }

                [Column("name")]
                public string Name { get; private set; }

                [Column("pipelineStepStatusId")]
                public int PipelineStepStatusId { get; private set; }

                [Column("shipperId")]
                public int ShipperId { get; private set; }

                [ForeignKey("PipelineStepStatusId")]
                public virtual PipelineStepStatus PipelineStepStatus { get; set; }

                [ForeignKey("ShipperId")]
                public virtual Employee Employee { get; set; }
        }
}

/*<Codenesium>
    <Hash>5c24a81ff7983c9a875950c8fec23dff</Hash>
</Codenesium>*/