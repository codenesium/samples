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
    <Hash>6ce9cbc3e5ce3894ffcba2d2fd121aa7</Hash>
</Codenesium>*/