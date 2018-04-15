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

		ApiResponse GetById(int productCategoryID);

		POCOProductCategory GetByIdDirect(int productCategoryID);

		ApiResponse GetWhere(Expression<Func<EFProductCategory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOProductCategory> GetWhereDirect(Expression<Func<EFProductCategory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>0f3bdde057f65d4f94c5404b1f13ceba</Hash>
</Codenesium>*/