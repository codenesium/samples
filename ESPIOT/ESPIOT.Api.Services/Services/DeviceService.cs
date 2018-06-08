using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;

namespace ESPIOTNS.Api.Services
{
        public class DeviceService: AbstractDeviceService, IDeviceService
        {
                public DeviceService(
                        ILogger<DeviceRepository> logger,
                        IDeviceRepository deviceRepository,
                        IApiDeviceRequestModelValidator deviceModelValidator,
                        IBOLDeviceMapper boldeviceMapper,
                        IDALDeviceMapper daldeviceMapper)
                        : base(logger,
                               deviceRepository,
                               deviceModelValidator,
                               boldeviceMapper,
                               daldeviceMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>9390b973e0aa8ee04fba676e4494446d</Hash>
</Codenesium>*/