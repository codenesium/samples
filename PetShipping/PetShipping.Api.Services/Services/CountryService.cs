using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Services
{
        public class CountryService : AbstractCountryService, ICountryService
        {
                public CountryService(
                        ILogger<ICountryRepository> logger,
                        ICountryRepository countryRepository,
                        IApiCountryRequestModelValidator countryModelValidator,
                        IBOLCountryMapper bolcountryMapper,
                        IDALCountryMapper dalcountryMapper,
                        IBOLCountryRequirementMapper bolCountryRequirementMapper,
                        IDALCountryRequirementMapper dalCountryRequirementMapper,
                        IBOLDestinationMapper bolDestinationMapper,
                        IDALDestinationMapper dalDestinationMapper
                        )
                        : base(logger,
                               countryRepository,
                               countryModelValidator,
                               bolcountryMapper,
                               dalcountryMapper,
                               bolCountryRequirementMapper,
                               dalCountryRequirementMapper,
                               bolDestinationMapper,
                               dalDestinationMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>d6fab18dfebb41600c308e1e07b0efc9</Hash>
</Codenesium>*/