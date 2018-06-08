using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace PetShippingNS.Api.Contracts
{
        public partial class ApiPipelineRequestModel: AbstractApiRequestModel
        {
                public ApiPipelineRequestModel() : base()
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
    <Hash>2d3894f6acd3c006ffcb2905a9fcc446</Hash>
</Codenesium>*/