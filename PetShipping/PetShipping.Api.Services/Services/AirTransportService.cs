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
        public class AirTransportService: AbstractAirTransportService, IAirTransportService
        {
                public AirTransportService(
                        ILogger<AirTransportRepository> logger,
                        IAirTransportRepository airTransportRepository,
                        IApiAirTransportRequestModelValidator airTransportModelValidator,
                        IBOLAirTransportMapper bolairTransportMapper,
                        IDALAirTransportMapper dalairTransportMapper)
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
    <Hash>258f0bf946d9e8e1f398b914ef87f611</Hash>
</Codenesium>*/