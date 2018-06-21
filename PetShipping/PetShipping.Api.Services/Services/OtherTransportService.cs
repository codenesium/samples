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
        public class OtherTransportService : AbstractOtherTransportService, IOtherTransportService
        {
                public OtherTransportService(
                        ILogger<IOtherTransportRepository> logger,
                        IOtherTransportRepository otherTransportRepository,
                        IApiOtherTransportRequestModelValidator otherTransportModelValidator,
                        IBOLOtherTransportMapper bolotherTransportMapper,
                        IDALOtherTransportMapper dalotherTransportMapper
                        )
                        : base(logger,
                               otherTransportRepository,
                               otherTransportModelValidator,
                               bolotherTransportMapper,
                               dalotherTransportMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>e732284ba81ca0ae39a1ddd1b5328b43</Hash>
</Codenesium>*/