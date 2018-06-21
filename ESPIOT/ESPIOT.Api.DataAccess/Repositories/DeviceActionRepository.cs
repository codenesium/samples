using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace ESPIOTNS.Api.DataAccess
{
        public class DeviceActionRepository : AbstractDeviceActionRepository, IDeviceActionRepository
        {
                public DeviceActionRepository(
                        ILogger<DeviceActionRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>a865e6f273a82a57bbfb20e151194387</Hash>
</Codenesium>*/