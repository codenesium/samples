using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductCategoryRepository
	{
		POCOProductCategory Create(ApiProductCategoryModel model);

		void Update(int productCategoryID,
		            ApiProductCategoryModel model);

		void Delete(int productCategoryID);

		POCOProductCategory Get(int productCategoryID);

		List<POCOProductCategory> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOProductCategory GetName(string name);
	}
}

/*<Codenesium>
    <Hash>ed0a3c3fec64c940f8d5484860b180db</Hash>
</Codenesium>*/