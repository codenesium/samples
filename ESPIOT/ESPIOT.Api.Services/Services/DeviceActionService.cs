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
                        ILogger<IDeviceActionRepository> logger,
                        IDeviceActionRepository deviceActionRepository,
                        IApiDeviceActionRequestModelValidator deviceActionModelValidator,
                        IBOLDeviceActionMapper boldeviceActionMapper,
                        IDALDeviceActionMapper daldeviceActionMapper

                        )
                        : base(logger,
                               deviceActionRepository,
                               deviceActionModelValidator,
                               boldeviceActionMapper,
                               daldeviceActionMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>3613aaf950b1aa8fc6b291d4e25c8fb4</Hash>
</Codenesium>*/