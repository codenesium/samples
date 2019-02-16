using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface IVendorRepository
	{
		Task<Vendor> Create(Vendor item);

		Task Update(Vendor item);

		Task Delete(int businessEntityID);

		Task<Vendor> Get(int businessEntityID);

		Task<List<Vendor>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<Vendor> ByAccountNumber(string accountNumber);

		Task<List<PurchaseOrderHeader>> PurchaseOrderHeadersByVendorID(int vendorID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>28bd805cc1613c978efb449cbd50b116</Hash>
</Codenesium>*/