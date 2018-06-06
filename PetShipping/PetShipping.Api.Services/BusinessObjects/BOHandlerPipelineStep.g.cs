using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Services
{
	public partial class BOHandlerPipelineStep: AbstractBusinessObject
	{
		public BOHandlerPipelineStep() : base()
		{}

		public void SetProperties(int id,
		                          int handlerId,
		                          int pipelineStepId)
		{
			this.HandlerId = handlerId.ToInt();
			this.Id = id.ToInt();
			this.PipelineStepId = pipelineStepId.ToInt();
		}

		public int HandlerId { get; private set; }
		public int Id { get; private set; }
		public int PipelineStepId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>f0373ad8dd872d5885c2525112f09725</Hash>
</Codenesium>*/