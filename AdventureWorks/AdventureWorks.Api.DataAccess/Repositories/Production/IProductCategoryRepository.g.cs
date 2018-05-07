using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductCategoryRepository
	{
		int Create(ProductCategoryModel model);

		void Update(int productCategoryID,
		            ProductCategoryModel model);

		void Delete(int productCategoryID);

		POCOProductCategory Get(int productCategoryID);

		List<POCOProductCategory> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>170882ee40d79955d6932f0815c1ed6f</Hash>
</Codenesium>*/