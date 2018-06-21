using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
        public partial class ApiPipelineStepDestinationRequestModel : AbstractApiRequestModel
        {
                public ApiPipelineStepDestinationRequestModel()
                        : base()
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
    <Hash>daf4bf99ef0a0bf758907b3874f4cea7</Hash>
</Codenesium>*/