using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface IProductVendorRepository
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
    <Hash>bababe8d01e353501cd7714679e2eb66</Hash>
</Codenesium>*/