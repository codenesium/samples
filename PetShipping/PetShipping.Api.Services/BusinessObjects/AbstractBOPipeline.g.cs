using Codenesium.DataConversionExtensions;
using System;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractBOPipeline : AbstractBusinessObject
	{
		public AbstractBOPipeline()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  int pipelineStatusId,
		                                  int saleId)
		{
			this.Id = id;
			this.PipelineStatusId = pipelineStatusId;
			this.SaleId = saleId;
		}

		public int Id { get; private set; }

		public int PipelineStatusId { get; private set; }

		public int SaleId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>cac9846fd869aea8fcf7a6c31206c0bd</Hash>
</Codenesium>*/