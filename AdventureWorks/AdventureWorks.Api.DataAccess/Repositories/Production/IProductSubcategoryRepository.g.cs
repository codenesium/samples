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

		Task<List<ProductSubcategory>> All(int limit = int.MaxValue, int offset = 0);

		Task<ProductSubcategory> ByName(string name);

		Task<List<Product>> Products(int productSubcategoryID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>7f2ac0b38cbb7d9f72fdc5361880eef4</Hash>
</Codenesium>*/