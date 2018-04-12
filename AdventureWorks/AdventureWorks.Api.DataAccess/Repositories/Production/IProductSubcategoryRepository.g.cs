using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductSubcategoryRepository
	{
		int Create(
			int productCategoryID,
			string name,
			Guid rowguid,
			DateTime modifiedDate);

		void Update(int productSubcategoryID,
		            int productCategoryID,
		            string name,
		            Guid rowguid,
		            DateTime modifiedDate);

		void Delete(int productSubcategoryID);

		Response GetById(int productSubcategoryID);

		POCOProductSubcategory GetByIdDirect(int productSubcategoryID);

		Response GetWhere(Expression<Func<EFProductSubcategory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOProductSubcategory> GetWhereDirect(Expression<Func<EFProductSubcategory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>9aed02bdb5b4c4d5252fdf1cd9735941</Hash>
</Codenesium>*/