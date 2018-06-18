using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Services
{
        public abstract class AbstractBOPipeline: AbstractBusinessObject
        {
                public AbstractBOPipeline() : base()
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
    <Hash>77d5e6b220b819afa7b0d9015bd20298</Hash>
</Codenesium>*/