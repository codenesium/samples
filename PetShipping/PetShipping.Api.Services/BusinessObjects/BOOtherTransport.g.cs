using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Services
{
        public partial class BOOtherTransport: AbstractBusinessObject
        {
                public BOOtherTransport() : base()
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
    <Hash>f66f27504e87d0f6ec86de7240f9d65e</Hash>
</Codenesium>*/