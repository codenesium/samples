using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IPurchaseOrderDetailRepository
        {
                Task<PurchaseOrderDetail> Create(PurchaseOrderDetail item);

                Task Update(PurchaseOrderDetail item);

                Task Delete(int purchaseOrderID);

                Task<PurchaseOrderDetail> Get(int purchaseOrderID);

                Task<List<PurchaseOrderDetail>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<PurchaseOrderDetail>> GetProductID(int productID);
        }
}

/*<Codenesium>
    <Hash>b40b1b286ef2396c574c4ce3c6d6992f</Hash>
</Codenesium>*/