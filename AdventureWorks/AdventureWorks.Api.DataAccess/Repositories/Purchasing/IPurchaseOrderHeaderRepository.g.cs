using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IPurchaseOrderHeaderRepository
	{
		Task<DTOPurchaseOrderHeader> Create(DTOPurchaseOrderHeader dto);

		Task Update(int purchaseOrderID,
		            DTOPurchaseOrderHeader dto);

		Task Delete(int purchaseOrderID);

		Task<DTOPurchaseOrderHeader> Get(int purchaseOrderID);

		Task<List<DTOPurchaseOrderHeader>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<DTOPurchaseOrderHeader>> GetEmployeeID(int employeeID);
		Task<List<DTOPurchaseOrderHeader>> GetVendorID(int vendorID);
	}
}

/*<Codenesium>
    <Hash>1c05a3c337ee299126655831fc9e6e5e</Hash>
</Codenesium>*/