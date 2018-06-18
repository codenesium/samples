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
                               dalairTransportMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>fbcc20184727ab362260e17e7926aa9c</Hash>
</Codenesium>*/