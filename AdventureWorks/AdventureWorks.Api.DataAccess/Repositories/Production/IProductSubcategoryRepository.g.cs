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

		Task<ProductSubcategory> ByRowguid(Guid rowguid);

		Task<List<Product>> ProductsByProductSubcategoryID(int productSubcategoryID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>536d5ea185a5fc29fe0136051ae4dd91</Hash>
</Codenesium>*/