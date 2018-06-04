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
    <Hash>8bdd1051bf99157e3a1dedac8d5fe380</Hash>
</Codenesium>*/