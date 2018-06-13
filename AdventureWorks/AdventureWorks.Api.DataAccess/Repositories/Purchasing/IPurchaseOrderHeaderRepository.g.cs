using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IPurchaseOrderHeaderRepository
        {
                Task<PurchaseOrderHeader> Create(PurchaseOrderHeader item);

                Task Update(PurchaseOrderHeader item);

                Task Delete(int purchaseOrderID);

                Task<PurchaseOrderHeader> Get(int purchaseOrderID);

                Task<List<PurchaseOrderHeader>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<PurchaseOrderHeader>> GetEmployeeID(int employeeID);
                Task<List<PurchaseOrderHeader>> GetVendorID(int vendorID);

                Task<List<PurchaseOrderDetail>> PurchaseOrderDetails(int purchaseOrderID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>5348cfb3739fe3af3c9aba77499e010d</Hash>
</Codenesium>*/