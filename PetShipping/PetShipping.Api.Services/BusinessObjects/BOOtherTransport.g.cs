using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Services
{
	public partial class BOOtherTransport: AbstractBusinessObject
	{
		public BOOtherTransport() : base()
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
    <Hash>752843dbddf5c5782e8bd643e1962a7c</Hash>
</Codenesium>*/