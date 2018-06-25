using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace ESPIOTNS.Api.DataAccess
{
        public partial class DeviceRepository : AbstractDeviceRepository, IDeviceRepository
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
    <Hash>83c7147f9a18f5ac9011364c1aaa2dcf</Hash>
</Codenesium>*/