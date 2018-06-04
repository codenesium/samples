using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Contracts
{
	public partial class BOPipeline: AbstractBusinessObject
	{
		public BOPipeline() : base()
		{}

		public void SetProperties(int id,
		                          int pipelineStatusId,
		                          int saleId)
		{
			this.Id = id.ToInt();
			this.PipelineStatusId = pipelineStatusId.ToInt();
			this.SaleId = saleId.ToInt();
		}

		public int Id { get; private set; }
		public int PipelineStatusId { get; private set; }
		public int SaleId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>91b8f1e2cf99d87e7680f0a8fac8f78c</Hash>
</Codenesium>*/