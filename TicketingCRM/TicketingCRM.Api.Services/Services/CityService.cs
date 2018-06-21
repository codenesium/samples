using Codenesium.DataConversionExtensions;
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
        public class CityService : AbstractCityService, ICityService
        {
                public CityService(
                        ILogger<ICityRepository> logger,
                        ICityRepository cityRepository,
                        IApiCityRequestModelValidator cityModelValidator,
                        IBOLCityMapper bolcityMapper,
                        IDALCityMapper dalcityMapper,
                        IBOLEventMapper bolEventMapper,
                        IDALEventMapper dalEventMapper
                        )
                        : base(logger,
                               cityRepository,
                               cityModelValidator,
                               bolcityMapper,
                               dalcityMapper,
                               bolEventMapper,
                               dalEventMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>4de453720c8c40a080490098b50e291b</Hash>
</Codenesium>*/