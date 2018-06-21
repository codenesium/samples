using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Services
{
        public abstract class AbstractBOPipelineStep : AbstractBusinessObject
        {
                public AbstractBOPipelineStep()
                        : base()
                {
                }

                public virtual void SetProperties(int id,
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
    <Hash>b0f277fb5712fff81d12c56e0da958e1</Hash>
</Codenesium>*/