using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
        public partial class ApiOtherTransportRequestModel : AbstractApiRequestModel
        {
                public ApiOtherTransportRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
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
    <Hash>5d880210d5bc18fe9e75b2d3badde216</Hash>
</Codenesium>*/