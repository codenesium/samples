using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductCategoryRepository
	{
		Task<ProductCategory> Create(ProductCategory item);

		Task Update(ProductCategory item);

		Task Delete(int productCategoryID);

		Task<ProductCategory> Get(int productCategoryID);

		Task<List<ProductCategory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<ProductCategory> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>6895bb2f947e66ee74924852c6bffa4a</Hash>
</Codenesium>*/