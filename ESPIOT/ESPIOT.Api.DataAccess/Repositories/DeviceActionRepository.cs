using Codenesium.DataConversionExtensions;
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
    <Hash>f59ed05d4be38f9a2841c1d422b12616</Hash>
</Codenesium>*/