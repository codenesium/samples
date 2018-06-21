using Codenesium.DataConversionExtensions.AspNetCore;
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

                public void SetProperties(
                        int deviceId,
                        string name,
                        string @value)
                {
                        this.DeviceId = deviceId;
                        this.Name = name;
                        this.@Value = @value;
                }

                private int deviceId;

                [Required]
                public int DeviceId
                {
                        get
                        {
                                return this.deviceId;
                        }

                        set
                        {
                                this.deviceId = value;
                        }
                }

                private string name;

                [Required]
                public string Name
                {
                        get
                        {
                                return this.name;
                        }

                        set
                        {
                                this.name = value;
                        }
                }

                private string @value;

                [Required]
                public string @Value
                {
                        get
                        {
                                return this.@value;
                        }

                        set
                        {
                                this.@value = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>3077c0471e3de10aa0c78f5154278bb5</Hash>
</Codenesium>*/