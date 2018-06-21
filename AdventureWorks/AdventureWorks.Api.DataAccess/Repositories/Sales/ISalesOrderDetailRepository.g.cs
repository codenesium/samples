using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface ISalesOrderDetailRepository
        {
                Task<SalesOrderDetail> Create(SalesOrderDetail item);

                Task Update(SalesOrderDetail item);

                Task Delete(int salesOrderID);

                Task<SalesOrderDetail> Get(int salesOrderID);

                Task<List<SalesOrderDetail>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<SalesOrderDetail>> ByProductID(int productID);

                Task<SpecialOfferProduct> GetSpecialOfferProduct(int productID);

                Task<SalesOrderHeader> GetSalesOrderHeader(int salesOrderID);
        }
}

/*<Codenesium>
    <Hash>74b7e35468dd8e85918739f0a2ee35f7</Hash>
</Codenesium>*/