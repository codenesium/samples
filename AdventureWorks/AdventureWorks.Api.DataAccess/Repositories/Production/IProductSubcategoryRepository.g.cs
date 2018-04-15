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

		ApiResponse GetById(int productSubcategoryID);

		POCOProductSubcategory GetByIdDirect(int productSubcategoryID);

		ApiResponse GetWhere(Expression<Func<EFProductSubcategory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOProductSubcategory> GetWhereDirect(Expression<Func<EFProductSubcategory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>3d07e71ca5ae09e79aa98dbe09c0cac5</Hash>
</Codenesium>*/