using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>25845064a757b91f8f8e273105621af2</Hash>
</Codenesium>*/