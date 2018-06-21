using Codenesium.DataConversionExtensions;
using System;

namespace PetShippingNS.Api.Services
{
        public abstract class AbstractBOPipelineStepDestination : AbstractBusinessObject
        {
                public AbstractBOPipelineStepDestination()
                        : base()
                {
                }

                public virtual void SetProperties(int id,
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
    <Hash>5ad10bbf1795c5596de5285281a9e8dc</Hash>
</Codenesium>*/