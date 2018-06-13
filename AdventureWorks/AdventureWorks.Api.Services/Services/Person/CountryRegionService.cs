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
    <Hash>d846205044938fc04b3117c2feba4002</Hash>
</Codenesium>*/