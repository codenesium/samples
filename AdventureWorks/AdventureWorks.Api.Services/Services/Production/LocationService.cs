using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
        public class LocationService : AbstractLocationService, ILocationService
        {
                public LocationService(
                        ILogger<ILocationRepository> logger,
                        ILocationRepository locationRepository,
                        IApiLocationRequestModelValidator locationModelValidator,
                        IBOLLocationMapper bollocationMapper,
                        IDALLocationMapper dallocationMapper,
                        IBOLProductInventoryMapper bolProductInventoryMapper,
                        IDALProductInventoryMapper dalProductInventoryMapper,
                        IBOLWorkOrderRoutingMapper bolWorkOrderRoutingMapper,
                        IDALWorkOrderRoutingMapper dalWorkOrderRoutingMapper
                        )
                        : base(logger,
                               locationRepository,
                               locationModelValidator,
                               bollocationMapper,
                               dallocationMapper,
                               bolProductInventoryMapper,
                               dalProductInventoryMapper,
                               bolWorkOrderRoutingMapper,
                               dalWorkOrderRoutingMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>89f89a4fb44c4b0dcad2533cf22dcf26</Hash>
</Codenesium>*/