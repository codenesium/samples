using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALSalesTerritoryMapper
        {
                SalesTerritory MapBOToEF(
                        BOSalesTerritory bo);

                BOSalesTerritory MapEFToBO(
                        SalesTerritory efSalesTerritory);

                List<BOSalesTerritory> MapEFToBO(
                        List<SalesTerritory> records);
        }
}

/*<Codenesium>
    <Hash>ab1554792f3d5b0b58ca889ecaadbd31</Hash>
</Codenesium>*/