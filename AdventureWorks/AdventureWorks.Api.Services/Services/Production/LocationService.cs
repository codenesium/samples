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
                        IDALLocationMapper dallocationMapper)
                        : base(logger,
                               locationRepository,
                               locationModelValidator,
                               bollocationMapper,
                               dallocationMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>8f88b7f3b2b4aa1ba8836f012e81966b</Hash>
</Codenesium>*/