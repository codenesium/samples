using Codenesium.DataConversionExtensions;
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
    <Hash>56ddf42dee473ddf4b45e12058e7fe44</Hash>
</Codenesium>*/