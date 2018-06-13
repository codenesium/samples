using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class LocationService: AbstractLocationService, ILocationService
        {
                public LocationService(
                        ILogger<LocationRepository> logger,
                        ILocationRepository locationRepository,
                        IApiLocationRequestModelValidator locationModelValidator,
                        IBOLLocationMapper bollocationMapper,
                        IDALLocationMapper dallocationMapper
                        ,
                        IBOLProductInventoryMapper bolProductInventoryMapper,
                        IDALProductInventoryMapper dalProductInventoryMapper
                        ,
                        IBOLWorkOrderRoutingMapper bolWorkOrderRoutingMapper,
                        IDALWorkOrderRoutingMapper dalWorkOrderRoutingMapper

                        )
                        : base(logger,
                               locationRepository,
                               locationModelValidator,
                               bollocationMapper,
                               dallocationMapper
                               ,
                               bolProductInventoryMapper,
                               dalProductInventoryMapper
                               ,
                               bolWorkOrderRoutingMapper,
                               dalWorkOrderRoutingMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>f4ac4b0eb63ddce5aad508d0482af862</Hash>
</Codenesium>*/