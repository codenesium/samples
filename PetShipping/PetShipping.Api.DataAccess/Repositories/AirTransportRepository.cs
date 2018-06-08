using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
        public class AirTransportRepository: AbstractAirTransportRepository, IAirTransportRepository
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
    <Hash>f8a9321c3969d4024d0831f8217d7e26</Hash>
</Codenesium>*/