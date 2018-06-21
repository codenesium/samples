using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
        public abstract class AbstractApiPipelineStepResponseModel : AbstractApiResponseModel
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
    <Hash>1f896b21aaa231161e02160eecebe92c</Hash>
</Codenesium>*/