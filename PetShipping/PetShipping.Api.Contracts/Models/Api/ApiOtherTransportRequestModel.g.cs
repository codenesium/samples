using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace PetShippingNS.Api.Contracts
{
        public partial class ApiOtherTransportRequestModel: AbstractApiRequestModel
        {
                public ApiOtherTransportRequestModel() : base()
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
    <Hash>e5b4d9e661e482d9963b47b60b0f7db1</Hash>
</Codenesium>*/