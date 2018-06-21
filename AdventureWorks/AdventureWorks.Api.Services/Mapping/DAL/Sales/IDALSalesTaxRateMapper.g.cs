using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALSalesTaxRateMapper
        {
                SalesTaxRate MapBOToEF(
                        BOSalesTaxRate bo);

                BOSalesTaxRate MapEFToBO(
                        SalesTaxRate efSalesTaxRate);

                List<BOSalesTaxRate> MapEFToBO(
                        List<SalesTaxRate> records);
        }
}

/*<Codenesium>
    <Hash>83ca1cff6ae9ff6ada107f522e25ab9a</Hash>
</Codenesium>*/