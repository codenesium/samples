using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Services
{
        public partial class BOPipelineStepDestination: AbstractBusinessObject
        {
                public BOPipelineStepDestination() : base()
                {
                }

                public void SetProperties(int id,
                                          int destinationId,
                                          int pipelineStepId)
                {
                        this.DestinationId = destinationId;
                        this.Id = id;
                        this.PipelineStepId = pipelineStepId;
                }

                public int DestinationId { get; private set; }

                public int Id { get; private set; }

                public int PipelineStepId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>dfc9bbfae5fa0b5335db2d3d0dbbaa7b</Hash>
</Codenesium>*/