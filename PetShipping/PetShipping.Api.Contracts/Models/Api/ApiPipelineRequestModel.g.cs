using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
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

                public virtual void SetProperties(
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
    <Hash>f5c73bd7241f86b7dd79f790e827941b</Hash>
</Codenesium>*/