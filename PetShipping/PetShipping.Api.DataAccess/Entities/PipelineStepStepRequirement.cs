using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

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
		public virtual PipelineStep PipelineStepNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>f57ceb5a8065c3ef1b2e7d300731a6a7</Hash>
</Codenesium>*/