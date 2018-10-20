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

		Task<List<Vendor>> All(int limit = int.MaxValue, int offset = 0);

		Task<Vendor> ByAccountNumber(string accountNumber);

		Task<List<ProductVendor>> ProductVendorsByBusinessEntityID(int businessEntityID, int limit = int.MaxValue, int offset = 0);

		Task<List<PurchaseOrderHeader>> PurchaseOrderHeadersByVendorID(int vendorID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>cf65f7c9bdd4d0f6005536b63c6f8f21</Hash>
</Codenesium>*/