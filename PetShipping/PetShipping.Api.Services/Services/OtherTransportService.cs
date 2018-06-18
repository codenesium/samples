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
        public class OtherTransportService: AbstractOtherTransportService, IOtherTransportService
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
                               dalotherTransportMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>2ae85392c857b171a2f2b63d1ab0ac17</Hash>
</Codenesium>*/