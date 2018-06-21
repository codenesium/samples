using Codenesium.DataConversionExtensions.AspNetCore;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace ESPIOTNS.Api.Services
{
        public class DeviceService : AbstractDeviceService, IDeviceService
        {
                public DeviceService(
                        ILogger<IDeviceRepository> logger,
                        IDeviceRepository deviceRepository,
                        IApiDeviceRequestModelValidator deviceModelValidator,
                        IBOLDeviceMapper boldeviceMapper,
                        IDALDeviceMapper daldeviceMapper,
                        IBOLDeviceActionMapper bolDeviceActionMapper,
                        IDALDeviceActionMapper dalDeviceActionMapper
                        )
                        : base(logger,
                               deviceRepository,
                               deviceModelValidator,
                               boldeviceMapper,
                               daldeviceMapper,
                               bolDeviceActionMapper,
                               dalDeviceActionMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>0b572b2ae365cda231bb567072ad23b4</Hash>
</Codenesium>*/