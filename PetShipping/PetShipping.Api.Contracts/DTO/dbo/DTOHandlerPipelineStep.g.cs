using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Contracts
{
	public partial class DTOHandlerPipelineStep: AbstractDTO
	{
		public DTOHandlerPipelineStep() : base()
		{}

		public void SetProperties(int id,
		                          int handlerId,
		                          int pipelineStepId)
		{
			this.HandlerId = handlerId.ToInt();
			this.Id = id.ToInt();
			this.PipelineStepId = pipelineStepId.ToInt();
		}

		public int HandlerId { get; set; }
		public int Id { get; set; }
		public int PipelineStepId { get; set; }
	}
}

/*<Codenesium>
    <Hash>5b17ec5cdd7c10359ce7b2c966b3599c</Hash>
</Codenesium>*/