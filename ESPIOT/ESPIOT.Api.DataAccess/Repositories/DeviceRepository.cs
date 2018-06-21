using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace ESPIOTNS.Api.DataAccess
{
        public class DeviceRepository : AbstractDeviceRepository, IDeviceRepository
        {
                public DeviceRepository(
                        ILogger<DeviceRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>8458679cc552740b2623de7666209969</Hash>
</Codenesium>*/