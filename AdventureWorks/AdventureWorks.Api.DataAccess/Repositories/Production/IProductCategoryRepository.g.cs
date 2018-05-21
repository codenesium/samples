using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductCategoryRepository
	{
		Task<POCOProductCategory> Create(ApiProductCategoryModel model);

		Task Update(int productCategoryID,
		            ApiProductCategoryModel model);

		Task Delete(int productCategoryID);

		Task<POCOProductCategory> Get(int productCategoryID);

		Task<List<POCOProductCategory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOProductCategory> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>80fc793e34667f78135ab290c68e4194</Hash>
</Codenesium>*/