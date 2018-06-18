using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Services
{
        public abstract class AbstractBOHandlerPipelineStep: AbstractBusinessObject
        {
                public AbstractBOHandlerPipelineStep() : base()
                {
                }

                public virtual void SetProperties(int id,
                                                  int handlerId,
                                                  int pipelineStepId)
                {
                        this.HandlerId = handlerId;
                        this.Id = id;
                        this.PipelineStepId = pipelineStepId;
                }

                public int HandlerId { get; private set; }

                public int Id { get; private set; }

                public int PipelineStepId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>6436a0f3a6e359ba36aab58f41b0b6f2</Hash>
</Codenesium>*/