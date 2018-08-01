using Codenesium.DataConversionExtensions;
using System;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractBOHandlerPipelineStep : AbstractBusinessObject
	{
		public AbstractBOHandlerPipelineStep()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  int handlerId,
		                                  int pipelineStepId)
		{
			this.HandlerId = handlerId;
			this.Id = id;
			this.PipelineStepId = pipelineStepId;
		}

		public int HandlerId { get; private set; }

		public int Id { get; private set; }

		public int PipelineStepId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>1849b0ce70af7c1d5151c83dd8ef33c4</Hash>
</Codenesium>*/