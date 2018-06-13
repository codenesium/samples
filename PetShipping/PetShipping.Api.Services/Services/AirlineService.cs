using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public class AirlineService: AbstractAirlineService, IAirlineService
        {
                public AirlineService(
                        ILogger<AirlineRepository> logger,
                        IAirlineRepository airlineRepository,
                        IApiAirlineRequestModelValidator airlineModelValidator,
                        IBOLAirlineMapper bolairlineMapper,
                        IDALAirlineMapper dalairlineMapper

                        )
                        : base(logger,
                               airlineRepository,
                               airlineModelValidator,
                               bolairlineMapper,
                               dalairlineMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>9a0291fd595ce8a32ba0c77164001e27</Hash>
</Codenesium>*/