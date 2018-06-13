using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace PetShippingNS.Api.Contracts
{
        public abstract class AbstractApiPipelineStepResponseModel: AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        string name,
                        int pipelineStepStatusId,
                        int shipperId)
                {
                        this.Id = id;
                        this.Name = name;
                        this.PipelineStepStatusId = pipelineStepStatusId;
                        this.ShipperId = shipperId;

                        this.PipelineStepStatusIdEntity = nameof(ApiResponse.PipelineStepStatus);
                        this.ShipperIdEntity = nameof(ApiResponse.Employees);
                }

                public int Id { get; private set; }

                public string Name { get; private set; }

                public int PipelineStepStatusId { get; private set; }

                public string PipelineStepStatusIdEntity { get; set; }

                public int ShipperId { get; private set; }

                public string ShipperIdEntity { get; set; }

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeNameValue { get; set; } = true;

                public bool ShouldSerializeName()
                {
                        return this.ShouldSerializeNameValue;
                }

                [JsonIgnore]
                public bool ShouldSerializePipelineStepStatusIdValue { get; set; } = true;

                public bool ShouldSerializePipelineStepStatusId()
                {
                        return this.ShouldSerializePipelineStepStatusIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeShipperIdValue { get; set; } = true;

                public bool ShouldSerializeShipperId()
                {
                        return this.ShouldSerializeShipperIdValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeNameValue = false;
                        this.ShouldSerializePipelineStepStatusIdValue = false;
                        this.ShouldSerializeShipperIdValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>b37795d61481a5640ad5d4ed8e6f5d9a</Hash>
</Codenesium>*/