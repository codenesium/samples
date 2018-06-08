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

                Task<List<PurchaseOrderDetail>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<List<PurchaseOrderDetail>> GetProductID(int productID);
        }
}

/*<Codenesium>
    <Hash>6cb2c73b24df9f5c13e556070bb4f585</Hash>
</Codenesium>*/