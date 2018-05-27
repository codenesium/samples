using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Contracts
{
	public partial class DTOOtherTransport: AbstractDTO
	{
		public DTOOtherTransport() : base()
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
    <Hash>3e5537b124c8f99b2b47100c452d783d</Hash>
</Codenesium>*/