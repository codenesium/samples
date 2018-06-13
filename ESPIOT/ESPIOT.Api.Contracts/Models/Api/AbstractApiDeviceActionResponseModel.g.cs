using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace ESPIOTNS.Api.Contracts
{
        public abstract class AbstractApiDeviceActionResponseModel: AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int deviceId,
                        int id,
                        string name,
                        string @value)
                {
                        this.DeviceId = deviceId;
                        this.Id = id;
                        this.Name = name;
                        this.@Value = @value;

                        this.DeviceIdEntity = nameof(ApiResponse.Devices);
                }

                public int DeviceId { get; private set; }

                public string DeviceIdEntity { get; set; }

                public int Id { get; private set; }

                public string Name { get; private set; }

                public string @Value { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeDeviceIdValue { get; set; } = true;

                public bool ShouldSerializeDeviceId()
                {
                        return this.ShouldSerializeDeviceIdValue;
                }

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
                public bool ShouldSerializeValueValue { get; set; } = true;

                public bool ShouldSerializeValue()
                {
                        return this.ShouldSerializeValueValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeDeviceIdValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeNameValue = false;
                        this.ShouldSerializeValueValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>8b82ff0415e390a9bf6e2ea9d9e0d527</Hash>
</Codenesium>*/