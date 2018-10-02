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
		                                  string detail,
		                                  int pipelineStepId,
		                                  bool requirementMet)
		{
			this.Detail = detail;
			this.Id = id;
			this.PipelineStepId = pipelineStepId;
			this.RequirementMet = requirementMet;
		}

		public string Detail { get; private set; }

		public int Id { get; private set; }

		public int PipelineStepId { get; private set; }

		public bool RequirementMet { get; private set; }
	}
}

/*<Codenesium>
    <Hash>973988060e21669ad97b8009b07cdccc</Hash>
</Codenesium>*/