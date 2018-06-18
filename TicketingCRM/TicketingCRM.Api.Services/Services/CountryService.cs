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
                        ILogger<ICountryRepository> logger,
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
    <Hash>5c221baba48b7b6b28ce1e36363012aa</Hash>
</Codenesium>*/