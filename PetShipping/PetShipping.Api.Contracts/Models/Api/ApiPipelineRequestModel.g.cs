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

                [JsonProperty]
                public int PipelineStatusId { get; private set; }

                [JsonProperty]
                public int SaleId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>926ad61687daa49435fc67920df027d1</Hash>
</Codenesium>*/