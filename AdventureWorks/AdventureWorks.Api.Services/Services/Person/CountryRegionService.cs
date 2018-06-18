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
                        ILogger<ICountryRegionRepository> logger,
                        ICountryRegionRepository countryRegionRepository,
                        IApiCountryRegionRequestModelValidator countryRegionModelValidator,
                        IBOLCountryRegionMapper bolcountryRegionMapper,
                        IDALCountryRegionMapper dalcountryRegionMapper
                        ,
                        IBOLStateProvinceMapper bolStateProvinceMapper,
                        IDALStateProvinceMapper dalStateProvinceMapper

                        )
                        : base(logger,
                               countryRegionRepository,
                               countryRegionModelValidator,
                               bolcountryRegionMapper,
                               dalcountryRegionMapper
                               ,
                               bolStateProvinceMapper,
                               dalStateProvinceMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>221bc6e9f5a5e4121cc6faf0e224f4d4</Hash>
</Codenesium>*/