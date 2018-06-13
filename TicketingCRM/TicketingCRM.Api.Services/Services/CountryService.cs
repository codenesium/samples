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
                        IDALCountryMapper dalcountryMapper
                        ,
                        IBOLProvinceMapper bolProvinceMapper,
                        IDALProvinceMapper dalProvinceMapper

                        )
                        : base(logger,
                               countryRepository,
                               countryModelValidator,
                               bolcountryMapper,
                               dalcountryMapper
                               ,
                               bolProvinceMapper,
                               dalProvinceMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>9907e67be997f54cd92abeda60439272</Hash>
</Codenesium>*/