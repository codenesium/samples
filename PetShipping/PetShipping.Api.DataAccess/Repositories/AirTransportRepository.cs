using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
        public partial class AirTransportRepository : AbstractAirTransportRepository, IAirTransportRepository
        {
                public AirTransportRepository(
                        ILogger<AirTransportRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>8870e31054c21b8b0e527f50dc867665</Hash>
</Codenesium>*/