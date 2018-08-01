using Codenesium.DataConversionExtensions;
using System;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractBOOtherTransport : AbstractBusinessObject
	{
		public AbstractBOOtherTransport()
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
    <Hash>c7fbb8a8ea0c874000e8b55d07cf0450</Hash>
</Codenesium>*/