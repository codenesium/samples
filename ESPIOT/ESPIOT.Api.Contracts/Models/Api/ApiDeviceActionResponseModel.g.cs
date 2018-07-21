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

                [Required]
                [JsonProperty]
                public int DeviceId { get; private set; }

                [JsonProperty]
                public string DeviceIdEntity { get; set; }

                [Required]
                [JsonProperty]
                public int Id { get; private set; }

                [Required]
                [JsonProperty]
                public string Name { get; private set; }

                [Required]
                [JsonProperty]
                public string @Value { get; private set; }
        }
}

/*<Codenesium>
    <Hash>a22d4b98860d566718f2c38e0b9c2522</Hash>
</Codenesium>*/