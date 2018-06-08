using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>4f3c42ee971224c7e8759ccad94b1e35</Hash>
</Codenesium>*/