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

                Task<List<SalesPerson>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<SalesOrderHeader>> SalesOrderHeaders(int salesPersonID, int limit = int.MaxValue, int offset = 0);
                Task<List<SalesPersonQuotaHistory>> SalesPersonQuotaHistories(int businessEntityID, int limit = int.MaxValue, int offset = 0);
                Task<List<SalesTerritoryHistory>> SalesTerritoryHistories(int businessEntityID, int limit = int.MaxValue, int offset = 0);
                Task<List<Store>> Stores(int salesPersonID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>1828f16c70c3158bc780593b8dcf2e9b</Hash>
</Codenesium>*/