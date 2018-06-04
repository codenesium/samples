using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Contracts
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
    <Hash>ac5c913ddd73f2bfd9dcdb2db1bffb74</Hash>
</Codenesium>*/