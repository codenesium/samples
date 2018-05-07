using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductSubcategoryRepository
	{
		int Create(ProductSubcategoryModel model);

		void Update(int productSubcategoryID,
		            ProductSubcategoryModel model);

		void Delete(int productSubcategoryID);

		POCOProductSubcategory Get(int productSubcategoryID);

		List<POCOProductSubcategory> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>80c4df71385830bc6391795891134707</Hash>
</Codenesium>*/