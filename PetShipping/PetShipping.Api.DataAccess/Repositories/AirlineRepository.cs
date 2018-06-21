using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>69d6525b64102313f5eb779d9cf8583e</Hash>
</Codenesium>*/