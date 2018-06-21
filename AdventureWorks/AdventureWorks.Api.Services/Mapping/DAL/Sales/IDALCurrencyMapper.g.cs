using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALCurrencyMapper
        {
                Currency MapBOToEF(
                        BOCurrency bo);

                BOCurrency MapEFToBO(
                        Currency efCurrency);

                List<BOCurrency> MapEFToBO(
                        List<Currency> records);
        }
}

/*<Codenesium>
    <Hash>37271df702cfd1a31e6d8187fb2552df</Hash>
</Codenesium>*/