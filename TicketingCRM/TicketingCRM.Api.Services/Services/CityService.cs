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
                        IDALCityMapper dalcityMapper
                        ,
                        IBOLEventMapper bolEventMapper,
                        IDALEventMapper dalEventMapper

                        )
                        : base(logger,
                               cityRepository,
                               cityModelValidator,
                               bolcityMapper,
                               dalcityMapper
                               ,
                               bolEventMapper,
                               dalEventMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>186753dc42a631685a527e07cd30c1a7</Hash>
</Codenesium>*/