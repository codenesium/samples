using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IPurchaseOrderHeaderRepository
	{
		Task<POCOPurchaseOrderHeader> Create(ApiPurchaseOrderHeaderModel model);

		Task Update(int purchaseOrderID,
		            ApiPurchaseOrderHeaderModel model);

		Task Delete(int purchaseOrderID);

		Task<POCOPurchaseOrderHeader> Get(int purchaseOrderID);

		Task<List<POCOPurchaseOrderHeader>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<POCOPurchaseOrderHeader>> GetEmployeeID(int employeeID);
		Task<List<POCOPurchaseOrderHeader>> GetVendorID(int vendorID);
	}
}

/*<Codenesium>
    <Hash>d4fce1e86558ce20f7b09836f39545b8</Hash>
</Codenesium>*/