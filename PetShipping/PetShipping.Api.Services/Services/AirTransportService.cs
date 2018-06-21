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
        public class AirTransportService : AbstractAirTransportService, IAirTransportService
        {
                public AirTransportService(
                        ILogger<IAirTransportRepository> logger,
                        IAirTransportRepository airTransportRepository,
                        IApiAirTransportRequestModelValidator airTransportModelValidator,
                        IBOLAirTransportMapper bolairTransportMapper,
                        IDALAirTransportMapper dalairTransportMapper
                        )
                        : base(logger,
                               airTransportRepository,
                               airTransportModelValidator,
                               bolairTransportMapper,
                               dalairTransportMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>8fc74da0aec71b001dc6fac0bee2613e</Hash>
</Codenesium>*/