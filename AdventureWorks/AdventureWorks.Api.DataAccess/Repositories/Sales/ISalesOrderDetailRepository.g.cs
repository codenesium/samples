using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface ISalesOrderDetailRepository
        {
                Task<SalesOrderDetail> Create(SalesOrderDetail item);

                Task Update(SalesOrderDetail item);

                Task Delete(int salesOrderID);

                Task<SalesOrderDetail> Get(int salesOrderID);

                Task<List<SalesOrderDetail>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<SalesOrderDetail>> GetProductID(int productID);
        }
}

/*<Codenesium>
    <Hash>549a677780a75f8e03bc0fa65728a665</Hash>
</Codenesium>*/