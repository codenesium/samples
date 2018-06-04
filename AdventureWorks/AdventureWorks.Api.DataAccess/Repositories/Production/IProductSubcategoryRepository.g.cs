using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductSubcategoryRepository
	{
		Task<ProductSubcategory> Create(ProductSubcategory item);

		Task Update(ProductSubcategory item);

		Task Delete(int productSubcategoryID);

		Task<ProductSubcategory> Get(int productSubcategoryID);

		Task<List<ProductSubcategory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<ProductSubcategory> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>78d69a2a789d058c8be56df261745571</Hash>
</Codenesium>*/