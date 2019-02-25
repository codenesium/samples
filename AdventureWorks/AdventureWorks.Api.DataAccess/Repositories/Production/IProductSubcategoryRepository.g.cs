using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface IProductSubcategoryRepository
	{
		Task<ProductSubcategory> Create(ProductSubcategory item);

		Task Update(ProductSubcategory item);

		Task Delete(int productSubcategoryID);

		Task<ProductSubcategory> Get(int productSubcategoryID);

		Task<List<ProductSubcategory>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<ProductSubcategory> ByName(string name);

		Task<ProductSubcategory> ByRowguid(Guid rowguid);

		Task<List<Product>> ProductsByProductSubcategoryID(int productSubcategoryID, int limit = int.MaxValue, int offset = 0);

		Task<ProductCategory> ProductCategoryByProductCategoryID(int productCategoryID);
	}
}

/*<Codenesium>
    <Hash>e8e6eadd9b936c0018561c37812e3b04</Hash>
</Codenesium>*/