using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>a571fbd472c5019f4dd921ae00a6390a</Hash>
</Codenesium>*/