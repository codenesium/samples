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
        public class CountryRequirementService : AbstractCountryRequirementService, ICountryRequirementService
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
                               dalcountryRequirementMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>23472787051cba28bf99b6e34bf9fc32</Hash>
</Codenesium>*/