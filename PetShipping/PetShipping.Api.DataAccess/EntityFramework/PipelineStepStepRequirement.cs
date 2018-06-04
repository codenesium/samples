using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace PetShippingNS.Api.DataAccess
{
	[Table("PipelineStepStepRequirement", Schema="dbo")]
	public partial class PipelineStepStepRequirement: AbstractEntity
	{
		public PipelineStepStepRequirement()
		{}

		public void SetProperties(
			string details,
			int id,
			int pipelineStepId,
			bool requirementMet)
		{
			this.Details = details;
			this.Id = id.ToInt();
			this.PipelineStepId = pipelineStepId.ToInt();
			this.RequirementMet = requirementMet.ToBoolean();
		}

		[Column("details", TypeName="text(2147483647)")]
		public string Details { get; private set; }

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; private set; }

		[Column("pipelineStepId", TypeName="int")]
		public int PipelineStepId { get; private set; }

		[Column("requirementMet", TypeName="bit")]
		public bool RequirementMet { get; private set; }

		[ForeignKey("PipelineStepId")]
		public virtual PipelineStep PipelineStep { get; set; }
	}
}

/*<Codenesium>
    <Hash>1cbd813099c567c753307f911485a36e</Hash>
</Codenesium>*/