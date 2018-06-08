using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALCurrencyRateMapper
        {
                CurrencyRate MapBOToEF(
                        BOCurrencyRate bo);

                BOCurrencyRate MapEFToBO(
                        CurrencyRate efCurrencyRate);

                List<BOCurrencyRate> MapEFToBO(
                        List<CurrencyRate> records);
        }
}

/*<Codenesium>
    <Hash>13c968fb4cc984b4216e099c9ed0cecc</Hash>
</Codenesium>*/