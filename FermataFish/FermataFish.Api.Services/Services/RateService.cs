using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public class RateService: AbstractRateService, IRateService
        {
                public RateService(
                        ILogger<RateRepository> logger,
                        IRateRepository rateRepository,
                        IApiRateRequestModelValidator rateModelValidator,
                        IBOLRateMapper bolrateMapper,
                        IDALRateMapper dalrateMapper)
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
    <Hash>1aa232da36130352ddd4fece615fec99</Hash>
</Codenesium>*/