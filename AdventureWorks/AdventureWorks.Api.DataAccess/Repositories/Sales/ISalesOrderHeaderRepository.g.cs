using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface ISalesOrderHeaderRepository
        {
                Task<SalesOrderHeader> Create(SalesOrderHeader item);

                Task Update(SalesOrderHeader item);

                Task Delete(int salesOrderID);

                Task<SalesOrderHeader> Get(int salesOrderID);

                Task<List<SalesOrderHeader>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<SalesOrderHeader> GetSalesOrderNumber(string salesOrderNumber);
                Task<List<SalesOrderHeader>> GetCustomerID(int customerID);
                Task<List<SalesOrderHeader>> GetSalesPersonID(Nullable<int> salesPersonID);
        }
}

/*<Codenesium>
    <Hash>ceb35fa46d6cb905266cddcaefe0f063</Hash>
</Codenesium>*/