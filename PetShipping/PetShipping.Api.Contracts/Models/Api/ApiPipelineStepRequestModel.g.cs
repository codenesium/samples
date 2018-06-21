using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>5a883a6c5a60f757d88037bc749ffbfd</Hash>
</Codenesium>*/