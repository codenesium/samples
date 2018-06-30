using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace ESPIOTNS.Api.Contracts
{
        public partial class ApiDeviceActionResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        int deviceId,
                        string name,
                        string @value)
                {
                        this.Id = id;
                        this.DeviceId = deviceId;
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
    <Hash>d05772d14e471f69277e1ea65f215e06</Hash>
</Codenesium>*/