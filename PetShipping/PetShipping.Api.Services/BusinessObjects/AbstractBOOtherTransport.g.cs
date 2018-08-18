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
    <Hash>d3115849520f66c0ed36d94107f3943c</Hash>
</Codenesium>*/