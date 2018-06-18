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

                Task<List<PurchaseOrderDetail>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<PurchaseOrderDetail>> ByProductID(int productID);
        }
}

/*<Codenesium>
    <Hash>71d0362e2878fd1bea75c83f6aab94bd</Hash>
</Codenesium>*/