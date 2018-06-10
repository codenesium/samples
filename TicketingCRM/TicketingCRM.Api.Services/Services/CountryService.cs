using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public class CountryService: AbstractCountryService, ICountryService
        {
                public CountryService(
                        ILogger<CountryRepository> logger,
                        ICountryRepository countryRepository,
                        IApiCountryRequestModelValidator countryModelValidator,
                        IBOLCountryMapper bolcountryMapper,
                        IDALCountryMapper dalcountryMapper)
                        : base(logger,
                               countryRepository,
                               countryModelValidator,
                               bolcountryMapper,
                               dalcountryMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>5609f9b04b3073df910703db5cc509d3</Hash>
</Codenesium>*/