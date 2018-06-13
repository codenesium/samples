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
                        IDALDeviceMapper daldeviceMapper
                        ,
                        IBOLDeviceActionMapper bolDeviceActionMapper,
                        IDALDeviceActionMapper dalDeviceActionMapper

                        )
                        : base(logger,
                               deviceRepository,
                               deviceModelValidator,
                               boldeviceMapper,
                               daldeviceMapper
                               ,
                               bolDeviceActionMapper,
                               dalDeviceActionMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>962eabbdf1eaf43d1f38b88b39977929</Hash>
</Codenesium>*/