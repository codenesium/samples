using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace ESPIOTNS.Api.DataAccess
{
        public partial class DeviceActionRepository : AbstractDeviceActionRepository, IDeviceActionRepository
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
    <Hash>5a6df60815f2bac0e6c25ed41971f665</Hash>
</Codenesium>*/