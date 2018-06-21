using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
        public partial class ApiPipelineStepRequestModel : AbstractApiRequestModel
        {
                public ApiPipelineStepRequestModel()
                        : base()
                {
                }

                public void SetProperties(
                        string name,
                        int pipelineStepStatusId,
                        int shipperId)
                {
                        this.Name = name;
                        this.PipelineStepStatusId = pipelineStepStatusId;
                        this.ShipperId = shipperId;
                }

                private string name;

                [Required]
                public string Name
                {
                        get
                        {
                                return this.name;
                        }

                        set
                        {
                                this.name = value;
                        }
                }

                private int pipelineStepStatusId;

                [Required]
                public int PipelineStepStatusId
                {
                        get
                        {
                                return this.pipelineStepStatusId;
                        }

                        set
                        {
                                this.pipelineStepStatusId = value;
                        }
                }

                private int shipperId;

                [Required]
                public int ShipperId
                {
                        get
                        {
                                return this.shipperId;
                        }

                        set
                        {
                                this.shipperId = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>bfc1e0d94f0df63c891c3858dd46695c</Hash>
</Codenesium>*/