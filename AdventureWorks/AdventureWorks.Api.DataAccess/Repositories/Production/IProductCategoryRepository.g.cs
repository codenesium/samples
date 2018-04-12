using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductCategoryRepository
	{
		int Create(
			string name,
			Guid rowguid,
			DateTime modifiedDate);

		void Update(int productCategoryID,
		            string name,
		            Guid rowguid,
		            DateTime modifiedDate);

		void Delete(int productCategoryID);

		Response GetById(int productCategoryID);

		POCOProductCategory GetByIdDirect(int productCategoryID);

		Response GetWhere(Expression<Func<EFProductCategory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOProductCategory> GetWhereDirect(Expression<Func<EFProductCategory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>354d1fb548951889649ec409f22fdfd2</Hash>
</Codenesium>*/