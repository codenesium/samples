using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class CountryRegionService: AbstractCountryRegionService, ICountryRegionService
        {
                public CountryRegionService(
                        ILogger<CountryRegionRepository> logger,
                        ICountryRegionRepository countryRegionRepository,
                        IApiCountryRegionRequestModelValidator countryRegionModelValidator,
                        IBOLCountryRegionMapper bolcountryRegionMapper,
                        IDALCountryRegionMapper dalcountryRegionMapper)
                        : base(logger,
                               countryRegionRepository,
                               countryRegionModelValidator,
                               bolcountryRegionMapper,
                               dalcountryRegionMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>f8d92cbae3f984d23263a5afc853d44c</Hash>
</Codenesium>*/