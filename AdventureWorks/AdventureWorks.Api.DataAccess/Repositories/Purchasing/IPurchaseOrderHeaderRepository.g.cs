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

                Task<List<PurchaseOrderHeader>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<List<PurchaseOrderHeader>> GetEmployeeID(int employeeID);
                Task<List<PurchaseOrderHeader>> GetVendorID(int vendorID);
        }
}

/*<Codenesium>
    <Hash>b1bc56f77c3c6b38a68407190c10db03</Hash>
</Codenesium>*/