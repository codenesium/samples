using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IPurchaseOrderHeaderRepository
	{
		POCOPurchaseOrderHeader Create(ApiPurchaseOrderHeaderModel model);

		void Update(int purchaseOrderID,
		            ApiPurchaseOrderHeaderModel model);

		void Delete(int purchaseOrderID);

		POCOPurchaseOrderHeader Get(int purchaseOrderID);

		List<POCOPurchaseOrderHeader> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOPurchaseOrderHeader> GetEmployeeID(int employeeID);
		List<POCOPurchaseOrderHeader> GetVendorID(int vendorID);
	}
}

/*<Codenesium>
    <Hash>f5bfcc695efc10be0965d64955a50543</Hash>
</Codenesium>*/