using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>b96f1c163c8215bcb2bed3028a243f7d</Hash>
</Codenesium>*/