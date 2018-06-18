using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface ISalesTerritoryHistoryRepository
        {
                Task<SalesTerritoryHistory> Create(SalesTerritoryHistory item);

                Task Update(SalesTerritoryHistory item);

                Task Delete(int businessEntityID);

                Task<SalesTerritoryHistory> Get(int businessEntityID);

                Task<List<SalesTerritoryHistory>> All(int limit = int.MaxValue, int offset = 0);

                Task<SalesPerson> GetSalesPerson(int businessEntityID);
                Task<SalesTerritory> GetSalesTerritory(int territoryID);
        }
}

/*<Codenesium>
    <Hash>6fd7d1cda3fbdd896c019b6068fa61b9</Hash>
</Codenesium>*/