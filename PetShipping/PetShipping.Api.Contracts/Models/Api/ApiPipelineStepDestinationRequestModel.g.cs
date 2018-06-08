using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace PetShippingNS.Api.Contracts
{
        public partial class ApiPipelineStepDestinationRequestModel: AbstractApiRequestModel
        {
                public ApiPipelineStepDestinationRequestModel() : base()
                {
                }

                public void SetProperties(
                        int destinationId,
                        int pipelineStepId)
                {
                        this.DestinationId = destinationId;
                        this.PipelineStepId = pipelineStepId;
                }

                private int destinationId;

                [Required]
                public int DestinationId
                {
                        get
                        {
                                return this.destinationId;
                        }

                        set
                        {
                                this.destinationId = value;
                        }
                }

                private int pipelineStepId;

                [Required]
                public int PipelineStepId
                {
                        get
                        {
                                return this.pipelineStepId;
                        }

                        set
                        {
                                this.pipelineStepId = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>a370fbfd001b7bd865618d9976a7538c</Hash>
</Codenesium>*/