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

                Task<List<SalesOrderDetail>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<List<SalesOrderDetail>> GetProductID(int productID);
        }
}

/*<Codenesium>
    <Hash>3c8df402d22133ab75ddfd49be6d1fe3</Hash>
</Codenesium>*/