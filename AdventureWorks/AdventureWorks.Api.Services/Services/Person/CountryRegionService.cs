using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
        public class CountryRegionService : AbstractCountryRegionService, ICountryRegionService
        {
                public CountryRegionService(
                        ILogger<ICountryRegionRepository> logger,
                        ICountryRegionRepository countryRegionRepository,
                        IApiCountryRegionRequestModelValidator countryRegionModelValidator,
                        IBOLCountryRegionMapper bolcountryRegionMapper,
                        IDALCountryRegionMapper dalcountryRegionMapper,
                        IBOLStateProvinceMapper bolStateProvinceMapper,
                        IDALStateProvinceMapper dalStateProvinceMapper
                        )
                        : base(logger,
                               countryRegionRepository,
                               countryRegionModelValidator,
                               bolcountryRegionMapper,
                               dalcountryRegionMapper,
                               bolStateProvinceMapper,
                               dalStateProvinceMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>fd1eb8d3edf82af8f4831e29708de0b9</Hash>
</Codenesium>*/