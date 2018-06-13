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

                Task<List<SalesOrderHeader>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<SalesOrderHeader> GetSalesOrderNumber(string salesOrderNumber);
                Task<List<SalesOrderHeader>> GetCustomerID(int customerID);
                Task<List<SalesOrderHeader>> GetSalesPersonID(Nullable<int> salesPersonID);

                Task<List<SalesOrderDetail>> SalesOrderDetails(int salesOrderID, int limit = int.MaxValue, int offset = 0);
                Task<List<SalesOrderHeaderSalesReason>> SalesOrderHeaderSalesReasons(int salesOrderID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>917dbd987b89d9142941144b7227593b</Hash>
</Codenesium>*/