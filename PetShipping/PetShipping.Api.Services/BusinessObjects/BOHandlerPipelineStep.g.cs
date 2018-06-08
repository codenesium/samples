using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Services
{
        public partial class BOHandlerPipelineStep: AbstractBusinessObject
        {
                public BOHandlerPipelineStep() : base()
                {
                }

                public void SetProperties(int id,
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
    <Hash>5163d08053a6909043af696bc9a1f33e</Hash>
</Codenesium>*/