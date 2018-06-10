using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public class CityService: AbstractCityService, ICityService
        {
                public CityService(
                        ILogger<CityRepository> logger,
                        ICityRepository cityRepository,
                        IApiCityRequestModelValidator cityModelValidator,
                        IBOLCityMapper bolcityMapper,
                        IDALCityMapper dalcityMapper)
                        : base(logger,
                               cityRepository,
                               cityModelValidator,
                               bolcityMapper,
                               dalcityMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>2f5e72cc97f0a22493ab72eca44e4607</Hash>
</Codenesium>*/