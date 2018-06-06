using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Services
{
	public partial class BOPipelineStepDestination: AbstractBusinessObject
	{
		public BOPipelineStepDestination() : base()
		{}

		public void SetProperties(int id,
		                          int destinationId,
		                          int pipelineStepId)
		{
			this.DestinationId = destinationId.ToInt();
			this.Id = id.ToInt();
			this.PipelineStepId = pipelineStepId.ToInt();
		}

		public int DestinationId { get; private set; }
		public int Id { get; private set; }
		public int PipelineStepId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>7f14d78596c482e412592be0bf188e90</Hash>
</Codenesium>*/