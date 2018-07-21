using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
        public partial class ApiPipelineResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        int pipelineStatusId,
                        int saleId)
                {
                        this.Id = id;
                        this.PipelineStatusId = pipelineStatusId;
                        this.SaleId = saleId;

                        this.PipelineStatusIdEntity = nameof(ApiResponse.PipelineStatus);
                }

                [Required]
                [JsonProperty]
                public int Id { get; private set; }

                [Required]
                [JsonProperty]
                public int PipelineStatusId { get; private set; }

                [JsonProperty]
                public string PipelineStatusIdEntity { get; set; }

                [Required]
                [JsonProperty]
                public int SaleId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>98588c77899b3dc1707cd85c85060c4d</Hash>
</Codenesium>*/