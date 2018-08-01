using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductVendorRepository
	{
		Task<ProductVendor> Create(ProductVendor item);

		Task Update(ProductVendor item);

		Task Delete(int productID);

		Task<ProductVendor> Get(int productID);

		Task<List<ProductVendor>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ProductVendor>> ByBusinessEntityID(int businessEntityID);

		Task<List<ProductVendor>> ByUnitMeasureCode(string unitMeasureCode);
	}
}

/*<Codenesium>
    <Hash>e7f3c9681e95e37a6b1c995d49d2ff7f</Hash>
</Codenesium>*/