using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
        public partial class ApiPipelineRequestModel : AbstractApiRequestModel
        {
                public ApiPipelineRequestModel()
                        : base()
                {
                }

                public void SetProperties(
                        int pipelineStatusId,
                        int saleId)
                {
                        this.PipelineStatusId = pipelineStatusId;
                        this.SaleId = saleId;
                }

                private int pipelineStatusId;

                [Required]
                public int PipelineStatusId
                {
                        get
                        {
                                return this.pipelineStatusId;
                        }

                        set
                        {
                                this.pipelineStatusId = value;
                        }
                }

                private int saleId;

                [Required]
                public int SaleId
                {
                        get
                        {
                                return this.saleId;
                        }

                        set
                        {
                                this.saleId = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>8e3c3ede99e99fabfa7e352537027523</Hash>
</Codenesium>*/