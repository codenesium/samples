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
                        ILogger<ICountryRequirementRepository> logger,
                        ICountryRequirementRepository countryRequirementRepository,
                        IApiCountryRequirementRequestModelValidator countryRequirementModelValidator,
                        IBOLCountryRequirementMapper bolcountryRequirementMapper,
                        IDALCountryRequirementMapper dalcountryRequirementMapper

                        )
                        : base(logger,
                               countryRequirementRepository,
                               countryRequirementModelValidator,
                               bolcountryRequirementMapper,
                               dalcountryRequirementMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>d2541d2195e2b7a2e4f7612d8f3a0f6f</Hash>
</Codenesium>*/