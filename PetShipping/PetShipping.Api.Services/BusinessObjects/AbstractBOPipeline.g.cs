using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>7b9707bb9eb8b4958eb968c00fa79c95</Hash>
</Codenesium>*/