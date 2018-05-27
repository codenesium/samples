using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Contracts
{
	public partial class DTOPipeline: AbstractDTO
	{
		public DTOPipeline() : base()
		{}

		public void SetProperties(int id,
		                          int pipelineStatusId,
		                          int saleId)
		{
			this.Id = id.ToInt();
			this.PipelineStatusId = pipelineStatusId.ToInt();
			this.SaleId = saleId.ToInt();
		}

		public int Id { get; set; }
		public int PipelineStatusId { get; set; }
		public int SaleId { get; set; }
	}
}

/*<Codenesium>
    <Hash>ddd6a8aed135140c8f22bd6c74c0b164</Hash>
</Codenesium>*/