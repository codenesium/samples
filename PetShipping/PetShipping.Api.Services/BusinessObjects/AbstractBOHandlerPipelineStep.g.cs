using Codenesium.DataConversionExtensions;
using System;

namespace PetShippingNS.Api.Services
{
        public abstract class AbstractBOHandlerPipelineStep : AbstractBusinessObject
        {
                public AbstractBOHandlerPipelineStep()
                        : base()
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
    <Hash>7fb3aa6438e574614228bb0444a7cd8f</Hash>
</Codenesium>*/