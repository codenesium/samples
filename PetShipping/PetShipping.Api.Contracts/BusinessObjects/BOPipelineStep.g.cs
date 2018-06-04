using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Contracts
{
	public partial class BOPipelineStep: AbstractBusinessObject
	{
		public BOPipelineStep() : base()
		{}

		public void SetProperties(int id,
		                          string name,
		                          int pipelineStepStatusId,
		                          int shipperId)
		{
			this.Id = id.ToInt();
			this.Name = name;
			this.PipelineStepStatusId = pipelineStepStatusId.ToInt();
			this.ShipperId = shipperId.ToInt();
		}

		public int Id { get; private set; }
		public string Name { get; private set; }
		public int PipelineStepStatusId { get; private set; }
		public int ShipperId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>2f104140d30fc79b08e8f913fdb29ffd</Hash>
</Codenesium>*/