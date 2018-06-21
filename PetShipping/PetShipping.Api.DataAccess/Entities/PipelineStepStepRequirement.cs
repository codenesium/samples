using Codenesium.DataConversionExtensions.AspNetCore;
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

                public void SetProperties(
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
    <Hash>d69179a5ce5bc568cd8853b0a5fe6ebf</Hash>
</Codenesium>*/