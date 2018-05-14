using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOPurchaseOrderHeader
	{
		Task<CreateResponse<POCOPurchaseOrderHeader>> Create(
			ApiPurchaseOrderHeaderModel model);

		Task<ActionResponse> Update(int purchaseOrderID,
		                            ApiPurchaseOrderHeaderModel model);

		Task<ActionResponse> Delete(int purchaseOrderID);

		POCOPurchaseOrderHeader Get(int purchaseOrderID);

		List<POCOPurchaseOrderHeader> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOPurchaseOrderHeader> GetEmployeeID(int employeeID);
		List<POCOPurchaseOrderHeader> GetVendorID(int vendorID);
	}
}

/*<Codenesium>
    <Hash>a65fcc2a3e003db25088002e648c0dcd</Hash>
</Codenesium>*/