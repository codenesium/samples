using Codenesium.DataConversionExtensions;
using System;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractBOPipelineStepStepRequirement : AbstractBusinessObject
	{
		public AbstractBOPipelineStepStepRequirement()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  string details,
		                                  int pipelineStepId,
		                                  bool requirementMet)
		{
			this.Details = details;
			this.Id = id;
			this.PipelineStepId = pipelineStepId;
			this.RequirementMet = requirementMet;
		}

		public string Details { get; private set; }

		public int Id { get; private set; }

		public int PipelineStepId { get; private set; }

		public bool RequirementMet { get; private set; }
	}
}

/*<Codenesium>
    <Hash>f23e56c06e526a95966d9023c9afd5e3</Hash>
</Codenesium>*/