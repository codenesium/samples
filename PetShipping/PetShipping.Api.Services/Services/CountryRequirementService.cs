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
    <Hash>f9d2dbd1345ce2192743fc63ec1cd3a9</Hash>
</Codenesium>*/