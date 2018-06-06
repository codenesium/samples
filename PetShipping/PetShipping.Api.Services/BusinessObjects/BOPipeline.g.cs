using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Services
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
    <Hash>613014a95125339c0f226e5c35e3af15</Hash>
</Codenesium>*/