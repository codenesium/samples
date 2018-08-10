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

		Task<List<ProductCategory>> All(int limit = int.MaxValue, int offset = 0);

		Task<ProductCategory> ByName(string name);

		Task<List<ProductSubcategory>> ProductSubcategories(int productCategoryID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>452df72bb5c1b8cfd5dd59fa147ee69f</Hash>
</Codenesium>*/