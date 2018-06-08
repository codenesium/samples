using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
        public class AirlineRepository: AbstractAirlineRepository, IAirlineRepository
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
    <Hash>fe5d37cb04391f48a679f44f251a0f68</Hash>
</Codenesium>*/