using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface IPurchaseOrderHeaderRepository
	{
		Task<PurchaseOrderHeader> Create(PurchaseOrderHeader item);

		Task Update(PurchaseOrderHeader item);

		Task Delete(int purchaseOrderID);

		Task<PurchaseOrderHeader> Get(int purchaseOrderID);

		Task<List<PurchaseOrderHeader>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<PurchaseOrderHeader>> ByEmployeeID(int employeeID, int limit = int.MaxValue, int offset = 0);

		Task<List<PurchaseOrderHeader>> ByVendorID(int vendorID, int limit = int.MaxValue, int offset = 0);

		Task<List<PurchaseOrderDetail>> PurchaseOrderDetails(int purchaseOrderID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>8e989d0be170d54f8855135ddf2b19bd</Hash>
</Codenesium>*/