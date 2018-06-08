using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace ESPIOTNS.Api.Services
{
        public partial class BODeviceAction: AbstractBusinessObject
        {
                public BODeviceAction() : base()
                {
                }

                public void SetProperties(int id,
                                          int deviceId,
                                          string name,
                                          string @value)
                {
                        this.DeviceId = deviceId;
                        this.Id = id;
                        this.Name = name;
                        this.@Value = @value;
                }

                public int DeviceId { get; private set; }

                public int Id { get; private set; }

                public string Name { get; private set; }

                public string @Value { get; private set; }
        }
}

/*<Codenesium>
    <Hash>e91c1d7f0a5ad501b2285e7cb4aa35ab</Hash>
</Codenesium>*/