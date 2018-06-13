using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public class CountryService: AbstractCountryService, ICountryService
        {
                public CountryService(
                        ILogger<CountryRepository> logger,
                        ICountryRepository countryRepository,
                        IApiCountryRequestModelValidator countryModelValidator,
                        IBOLCountryMapper bolcountryMapper,
                        IDALCountryMapper dalcountryMapper
                        ,
                        IBOLCountryRequirementMapper bolCountryRequirementMapper,
                        IDALCountryRequirementMapper dalCountryRequirementMapper
                        ,
                        IBOLDestinationMapper bolDestinationMapper,
                        IDALDestinationMapper dalDestinationMapper

                        )
                        : base(logger,
                               countryRepository,
                               countryModelValidator,
                               bolcountryMapper,
                               dalcountryMapper
                               ,
                               bolCountryRequirementMapper,
                               dalCountryRequirementMapper
                               ,
                               bolDestinationMapper,
                               dalDestinationMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>230d3cdb6d969372c0a965ea671638f3</Hash>
</Codenesium>*/