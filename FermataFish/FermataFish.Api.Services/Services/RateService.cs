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
                               dalrateMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>6ae8b8b1124c92f6ed47a93674d620e7</Hash>
</Codenesium>*/