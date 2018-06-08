using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace PetShippingNS.Api.Contracts
{
        public partial class ApiHandlerPipelineStepRequestModel: AbstractApiRequestModel
        {
                public ApiHandlerPipelineStepRequestModel() : base()
                {
                }

                public void SetProperties(
                        int handlerId,
                        int pipelineStepId)
                {
                        this.HandlerId = handlerId;
                        this.PipelineStepId = pipelineStepId;
                }

                private int handlerId;

                [Required]
                public int HandlerId
                {
                        get
                        {
                                return this.handlerId;
                        }

                        set
                        {
                                this.handlerId = value;
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
    <Hash>fd3519c48d6c7e2fa4f44162d3b31cfa</Hash>
</Codenesium>*/