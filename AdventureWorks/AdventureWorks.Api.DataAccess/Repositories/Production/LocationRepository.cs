using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class LocationRepository: AbstractLocationRepository, ILocationRepository
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
    <Hash>e48a568da38f05f3a17ae6671feb5561</Hash>
</Codenesium>*/