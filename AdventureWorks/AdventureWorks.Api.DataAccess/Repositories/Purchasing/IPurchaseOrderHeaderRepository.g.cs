using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IPurchaseOrderHeaderRepository
        {
                Task<PurchaseOrderHeader> Create(PurchaseOrderHeader item);

                Task Update(PurchaseOrderHeader item);

                Task Delete(int purchaseOrderID);

                Task<PurchaseOrderHeader> Get(int purchaseOrderID);

                Task<List<PurchaseOrderHeader>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<PurchaseOrderHeader>> ByEmployeeID(int employeeID);

                Task<List<PurchaseOrderHeader>> ByVendorID(int vendorID);

                Task<List<PurchaseOrderDetail>> PurchaseOrderDetails(int purchaseOrderID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>62d368233ba3cf75b6a315ca0112bb8a</Hash>
</Codenesium>*/