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

		Task<List<PurchaseOrderHeader>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<PurchaseOrderHeader>> ByEmployeeID(int employeeID, int limit = int.MaxValue, int offset = 0);

		Task<List<PurchaseOrderHeader>> ByVendorID(int vendorID, int limit = int.MaxValue, int offset = 0);

		Task<ShipMethod> ShipMethodByShipMethodID(int shipMethodID);

		Task<Vendor> VendorByVendorID(int vendorID);
	}
}

/*<Codenesium>
    <Hash>7fa9cf2d123d9e67ee3c58f2c8943dd9</Hash>
</Codenesium>*/