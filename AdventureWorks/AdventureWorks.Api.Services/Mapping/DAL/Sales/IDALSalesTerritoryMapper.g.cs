using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>93c965bd260ce397cd6a43aeac3fd1d7</Hash>
</Codenesium>*/