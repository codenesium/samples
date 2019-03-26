using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface IProductCategoryRepository
	{
		Task<ProductCategory> Create(ProductCategory item);

		Task Update(ProductCategory item);

		Task Delete(int productCategoryID);

		Task<ProductCategory> Get(int productCategoryID);

		Task<List<ProductCategory>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<ProductCategory> ByName(string name);

		Task<ProductCategory> ByRowguid(Guid rowguid);

		Task<List<ProductSubcategory>> ProductSubcategoriesByProductCategoryID(int productCategoryID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>1a7393af59f2cb3c2cb8d21e73f72274</Hash>
</Codenesium>*/