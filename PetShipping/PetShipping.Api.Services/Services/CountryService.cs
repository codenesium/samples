using Codenesium.DataConversionExtensions;
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
        public partial class CountryService : AbstractCountryService, ICountryService
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
    <Hash>dcd2ebfe55b68a63ca4c652444746b64</Hash>
</Codenesium>*/