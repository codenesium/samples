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

		[MaxLength(2147483647)]
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
    <Hash>a1e1de3021eedc9a8cc8f39045c00cd4</Hash>
</Codenesium>*/