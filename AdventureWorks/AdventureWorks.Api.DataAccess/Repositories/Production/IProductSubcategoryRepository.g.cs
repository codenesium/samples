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

		Task<List<Product>> ProductsByProductSubcategoryID(int productSubcategoryID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>487efd345b6e4e84ae6391914408e763</Hash>
</Codenesium>*/