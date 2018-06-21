using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALSalesTerritoryHistoryMapper
        {
                SalesTerritoryHistory MapBOToEF(
                        BOSalesTerritoryHistory bo);

                BOSalesTerritoryHistory MapEFToBO(
                        SalesTerritoryHistory efSalesTerritoryHistory);

                List<BOSalesTerritoryHistory> MapEFToBO(
                        List<SalesTerritoryHistory> records);
        }
}

/*<Codenesium>
    <Hash>628eb620bcb5a6b034dee112367135f3</Hash>
</Codenesium>*/