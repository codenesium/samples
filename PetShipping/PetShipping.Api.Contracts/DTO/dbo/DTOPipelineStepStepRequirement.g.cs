using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Contracts
{
	public partial class DTOPipelineStepStepRequirement: AbstractDTO
	{
		public DTOPipelineStepStepRequirement() : base()
		{}

		public void SetProperties(int id,
		                          string details,
		                          int pipelineStepId,
		                          bool requirementMet)
		{
			this.Details = details;
			this.Id = id.ToInt();
			this.PipelineStepId = pipelineStepId.ToInt();
			this.RequirementMet = requirementMet.ToBoolean();
		}

		public string Details { get; set; }
		public int Id { get; set; }
		public int PipelineStepId { get; set; }
		public bool RequirementMet { get; set; }
	}
}

/*<Codenesium>
    <Hash>a807986c626c1614fd9cab8094b214e2</Hash>
</Codenesium>*/