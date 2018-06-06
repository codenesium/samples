using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Services
{
	public partial class BOPipelineStepStepRequirement: AbstractBusinessObject
	{
		public BOPipelineStepStepRequirement() : base()
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

		public string Details { get; private set; }
		public int Id { get; private set; }
		public int PipelineStepId { get; private set; }
		public bool RequirementMet { get; private set; }
	}
}

/*<Codenesium>
    <Hash>285ca709436943cb84d17d76bbebe36e</Hash>
</Codenesium>*/