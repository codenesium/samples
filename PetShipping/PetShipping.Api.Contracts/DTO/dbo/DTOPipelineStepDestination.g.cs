using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Contracts
{
	public partial class DTOPipelineStepDestination: AbstractDTO
	{
		public DTOPipelineStepDestination() : base()
		{}

		public void SetProperties(int id,
		                          int destinationId,
		                          int pipelineStepId)
		{
			this.DestinationId = destinationId.ToInt();
			this.Id = id.ToInt();
			this.PipelineStepId = pipelineStepId.ToInt();
		}

		public int DestinationId { get; set; }
		public int Id { get; set; }
		public int PipelineStepId { get; set; }
	}
}

/*<Codenesium>
    <Hash>baf9b36a45c13ffc5ca4931e331c3bf8</Hash>
</Codenesium>*/