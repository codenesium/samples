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
        public class CountryRequirementService: AbstractCountryRequirementService, ICountryRequirementService
        {
                public CountryRequirementService(
                        ILogger<CountryRequirementRepository> logger,
                        ICountryRequirementRepository countryRequirementRepository,
                        IApiCountryRequirementRequestModelValidator countryRequirementModelValidator,
                        IBOLCountryRequirementMapper bolcountryRequirementMapper,
                        IDALCountryRequirementMapper dalcountryRequirementMapper)
                        : base(logger,
                               countryRequirementRepository,
                               countryRequirementModelValidator,
                               bolcountryRequirementMapper,
                               dalcountryRequirementMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>0cd2e23e2d001f0156ad7404ded0ed25</Hash>
</Codenesium>*/