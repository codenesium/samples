using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface ISalesPersonRepository
        {
                Task<SalesPerson> Create(SalesPerson item);

                Task Update(SalesPerson item);

                Task Delete(int businessEntityID);

                Task<SalesPerson> Get(int businessEntityID);

                Task<List<SalesPerson>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<SalesOrderHeader>> SalesOrderHeaders(int salesPersonID, int limit = int.MaxValue, int offset = 0);
                Task<List<SalesPersonQuotaHistory>> SalesPersonQuotaHistories(int businessEntityID, int limit = int.MaxValue, int offset = 0);
                Task<List<SalesTerritoryHistory>> SalesTerritoryHistories(int businessEntityID, int limit = int.MaxValue, int offset = 0);
                Task<List<Store>> Stores(int salesPersonID, int limit = int.MaxValue, int offset = 0);

                Task<SalesTerritory> GetSalesTerritory(int territoryID);
        }
}

/*<Codenesium>
    <Hash>ef6a7690cb7e74f2b4e332c7069da265</Hash>
</Codenesium>*/