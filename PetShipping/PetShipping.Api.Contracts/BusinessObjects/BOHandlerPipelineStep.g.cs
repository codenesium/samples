using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Contracts
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
    <Hash>7e58177111d1a6111232d6e26e9fb89d</Hash>
</Codenesium>*/