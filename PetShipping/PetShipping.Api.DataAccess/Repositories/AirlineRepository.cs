using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
        public class AirlineRepository : AbstractAirlineRepository, IAirlineRepository
        {
                public AirlineRepository(
                        ILogger<AirlineRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>ced8c89ad528aebb1e36c24d915356ed</Hash>
</Codenesium>*/