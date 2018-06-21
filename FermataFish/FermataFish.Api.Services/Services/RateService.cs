using Codenesium.DataConversionExtensions.AspNetCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Services
{
        public class RateService : AbstractRateService, IRateService
        {
                public RateService(
                        ILogger<IRateRepository> logger,
                        IRateRepository rateRepository,
                        IApiRateRequestModelValidator rateModelValidator,
                        IBOLRateMapper bolrateMapper,
                        IDALRateMapper dalrateMapper
                        )
                        : base(logger,
                               rateRepository,
                               rateModelValidator,
                               bolrateMapper,
                               dalrateMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>9c65b2cf69476fd92c76d024502e419f</Hash>
</Codenesium>*/