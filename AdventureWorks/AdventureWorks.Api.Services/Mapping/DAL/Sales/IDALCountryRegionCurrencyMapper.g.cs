using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALCountryRegionCurrencyMapper
        {
                CountryRegionCurrency MapBOToEF(
                        BOCountryRegionCurrency bo);

                BOCountryRegionCurrency MapEFToBO(
                        CountryRegionCurrency efCountryRegionCurrency);

                List<BOCountryRegionCurrency> MapEFToBO(
                        List<CountryRegionCurrency> records);
        }
}

/*<Codenesium>
    <Hash>7287ca5411d0c2c73f66030605e3a002</Hash>
</Codenesium>*/