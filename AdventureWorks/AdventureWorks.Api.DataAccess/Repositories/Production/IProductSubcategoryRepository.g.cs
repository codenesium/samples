using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductSubcategoryRepository
	{
		POCOProductSubcategory Create(ApiProductSubcategoryModel model);

		void Update(int productSubcategoryID,
		            ApiProductSubcategoryModel model);

		void Delete(int productSubcategoryID);

		POCOProductSubcategory Get(int productSubcategoryID);

		List<POCOProductSubcategory> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOProductSubcategory GetName(string name);
	}
}

/*<Codenesium>
    <Hash>fe9e9d8144f252c7fe914b80085bdcb0</Hash>
</Codenesium>*/