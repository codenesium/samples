using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace PetShippingNS.Api.DataAccess
{
	[Table("PipelineStepStepRequirement", Schema="dbo")]
	public partial class PipelineStepStepRequirement: AbstractEntityFrameworkPOCO
	{
		public PipelineStepStepRequirement()
		{}

		public void SetProperties(
			int id,
			string details,
			int pipelineStepId,
			bool requirementMet)
		{
			this.Details = details;
			this.Id = id.ToInt();
			this.PipelineStepId = pipelineStepId.ToInt();
			this.RequirementMet = requirementMet.ToBoolean();
		}

		[Column("details", TypeName="text(2147483647)")]
		public string Details { get; set; }

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("pipelineStepId", TypeName="int")]
		public int PipelineStepId { get; set; }

		[Column("requirementMet", TypeName="bit")]
		public bool RequirementMet { get; set; }

		[ForeignKey("PipelineStepId")]
		public virtual PipelineStep PipelineStep { get; set; }
	}
}

/*<Codenesium>
    <Hash>19508fa0bd175a89149467f065bab6a8</Hash>
</Codenesium>*/