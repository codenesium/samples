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

                public int Id { get; private set; }

                public int PipelineStatusId { get; private set; }

                public string PipelineStatusIdEntity { get; set; }

                public int SaleId { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializePipelineStatusIdValue { get; set; } = true;

                public bool ShouldSerializePipelineStatusId()
                {
                        return this.ShouldSerializePipelineStatusIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeSaleIdValue { get; set; } = true;

                public bool ShouldSerializeSaleId()
                {
                        return this.ShouldSerializeSaleIdValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializePipelineStatusIdValue = false;
                        this.ShouldSerializeSaleIdValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>ef107d79de5e2a9d1c572340706dfe88</Hash>
</Codenesium>*/