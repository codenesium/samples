using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Services
{
        public class AirlineService : AbstractAirlineService, IAirlineService
        {
                public AirlineService(
                        ILogger<IAirlineRepository> logger,
                        IAirlineRepository airlineRepository,
                        IApiAirlineRequestModelValidator airlineModelValidator,
                        IBOLAirlineMapper bolairlineMapper,
                        IDALAirlineMapper dalairlineMapper
                        )
                        : base(logger,
                               airlineRepository,
                               airlineModelValidator,
                               bolairlineMapper,
                               dalairlineMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>aa3caf03500c828ef42f11bc62993941</Hash>
</Codenesium>*/