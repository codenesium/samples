using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class LocationRepository : AbstractLocationRepository, ILocationRepository
        {
                public LocationRepository(
                        ILogger<LocationRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>7aa4e8fbe7ccd90d8211d7f2953c5078</Hash>
</Codenesium>*/