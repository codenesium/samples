using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShippingNS.Api.DataAccess
{
        [Table("PipelineStepStepRequirement", Schema="dbo")]
        public partial class PipelineStepStepRequirement : AbstractEntity
        {
                public PipelineStepStepRequirement()
                {
                }

                public virtual void SetProperties(
                        string details,
                        int id,
                        int pipelineStepId,
                        bool requirementMet)
                {
                        this.Details = details;
                        this.Id = id;
                        this.PipelineStepId = pipelineStepId;
                        this.RequirementMet = requirementMet;
                }

                [Column("details")]
                public string Details { get; private set; }

                [Key]
                [Column("id")]
                public int Id { get; private set; }

                [Column("pipelineStepId")]
                public int PipelineStepId { get; private set; }

                [Column("requirementMet")]
                public bool RequirementMet { get; private set; }

                [ForeignKey("PipelineStepId")]
                public virtual PipelineStep PipelineStep { get; set; }
        }
}

/*<Codenesium>
    <Hash>a260ba6136a929fa4d7678b00b77b2ff</Hash>
</Codenesium>*/