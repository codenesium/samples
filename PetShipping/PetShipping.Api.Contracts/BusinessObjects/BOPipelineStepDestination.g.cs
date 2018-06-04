using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Contracts
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
    <Hash>582433a9b8cd70255656748b293f1c8a</Hash>
</Codenesium>*/