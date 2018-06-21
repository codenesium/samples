using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Services
{
        public abstract class AbstractBOOtherTransport : AbstractBusinessObject
        {
                public AbstractBOOtherTransport()
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
    <Hash>3aad67ad972c3a205d22f189263e1449</Hash>
</Codenesium>*/