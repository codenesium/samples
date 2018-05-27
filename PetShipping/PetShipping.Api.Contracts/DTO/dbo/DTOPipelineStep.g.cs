using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Contracts
{
	public partial class DTOPipelineStep: AbstractDTO
	{
		public DTOPipelineStep() : base()
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

		public int Id { get; set; }
		public string Name { get; set; }
		public int PipelineStepStatusId { get; set; }
		public int ShipperId { get; set; }
	}
}

/*<Codenesium>
    <Hash>13fe8cd31eb89029fe2df527f99da8d4</Hash>
</Codenesium>*/