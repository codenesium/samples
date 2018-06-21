using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>2bf2cbe2273a1662fa129a74fd5095fb</Hash>
</Codenesium>*/