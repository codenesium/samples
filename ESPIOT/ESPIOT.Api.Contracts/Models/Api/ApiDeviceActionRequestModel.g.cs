using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace ESPIOTNS.Api.Contracts
{
        public partial class ApiDeviceActionRequestModel : AbstractApiRequestModel
        {
                public ApiDeviceActionRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        int deviceId,
                        string name,
                        string @value)
                {
                        this.DeviceId = deviceId;
                        this.Name = name;
                        this.@Value = @value;
                }

                [JsonProperty]
                public int DeviceId { get; private set; }

                [JsonProperty]
                public string Name { get; private set; }

                [JsonProperty]
                public string @Value { get; private set; }
        }
}

/*<Codenesium>
    <Hash>7fab1731d0fb723ba34881dc561a84a6</Hash>
</Codenesium>*/