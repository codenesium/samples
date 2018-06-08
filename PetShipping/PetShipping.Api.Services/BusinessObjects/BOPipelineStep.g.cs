using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Services
{
        public partial class BOPipelineStep: AbstractBusinessObject
        {
                public BOPipelineStep() : base()
                {
                }

                public void SetProperties(int id,
                                          string name,
                                          int pipelineStepStatusId,
                                          int shipperId)
                {
                        this.Id = id;
                        this.Name = name;
                        this.PipelineStepStatusId = pipelineStepStatusId;
                        this.ShipperId = shipperId;
                }

                public int Id { get; private set; }

                public string Name { get; private set; }

                public int PipelineStepStatusId { get; private set; }

                public int ShipperId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>78fc0b0065bfa95ad2e9128168ba08be</Hash>
</Codenesium>*/