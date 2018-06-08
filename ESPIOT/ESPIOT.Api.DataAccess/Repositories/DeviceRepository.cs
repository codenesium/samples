using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace ESPIOTNS.Api.DataAccess
{
        public class DeviceRepository: AbstractDeviceRepository, IDeviceRepository
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
    <Hash>c90805e95440d5f67d79dc58c366ef7e</Hash>
</Codenesium>*/