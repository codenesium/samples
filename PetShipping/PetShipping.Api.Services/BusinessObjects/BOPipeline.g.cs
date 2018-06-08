using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Services
{
        public partial class BOPipeline: AbstractBusinessObject
        {
                public BOPipeline() : base()
                {
                }

                public void SetProperties(int id,
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
    <Hash>a4cd43d79f4b247754b95f894116485d</Hash>
</Codenesium>*/