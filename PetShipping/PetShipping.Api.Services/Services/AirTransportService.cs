using Codenesium.DataConversionExtensions;
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
        public partial class AirTransportService : AbstractAirTransportService, IAirTransportService
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
    <Hash>fa7005c0f32a65c27125cc4d8302dc16</Hash>
</Codenesium>*/