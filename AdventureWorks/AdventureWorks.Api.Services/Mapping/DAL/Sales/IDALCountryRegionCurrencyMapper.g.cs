using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>87c4b0ef0b95f290dcd9bad6924af780</Hash>
</Codenesium>*/