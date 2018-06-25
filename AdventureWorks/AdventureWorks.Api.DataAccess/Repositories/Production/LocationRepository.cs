using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class LocationRepository : AbstractLocationRepository, ILocationRepository
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
    <Hash>7e60ae2ffaec8ae4b90850954f7ce73b</Hash>
</Codenesium>*/