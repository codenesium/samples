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
        }
}

/*<Codenesium>
    <Hash>fe2e5a2265e1446773b2fcf0fc59c656</Hash>
</Codenesium>*/