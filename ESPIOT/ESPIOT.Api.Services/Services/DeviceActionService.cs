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
        public class DeviceActionService: AbstractDeviceActionService, IDeviceActionService
        {
                public DeviceActionService(
                        ILogger<DeviceActionRepository> logger,
                        IDeviceActionRepository deviceActionRepository,
                        IApiDeviceActionRequestModelValidator deviceActionModelValidator,
                        IBOLDeviceActionMapper boldeviceActionMapper,
                        IDALDeviceActionMapper daldeviceActionMapper)
                        : base(logger,
                               deviceActionRepository,
                               deviceActionModelValidator,
                               boldeviceActionMapper,
                               daldeviceActionMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>9b863b17d3eab34b57137162ebd92a7a</Hash>
</Codenesium>*/