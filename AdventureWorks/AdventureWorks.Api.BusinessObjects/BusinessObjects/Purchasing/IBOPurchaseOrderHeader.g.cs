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

		Task<POCOPurchaseOrderHeader> Get(int purchaseOrderID);

		Task<List<POCOPurchaseOrderHeader>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<POCOPurchaseOrderHeader>> GetEmployeeID(int employeeID);
		Task<List<POCOPurchaseOrderHeader>> GetVendorID(int vendorID);
	}
}

/*<Codenesium>
    <Hash>263803cc14f954fa6b815fb67e49b913</Hash>
</Codenesium>*/