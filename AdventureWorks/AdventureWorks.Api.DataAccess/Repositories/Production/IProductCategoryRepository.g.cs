using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductCategoryRepository
	{
		int Create(string name,
		           Guid rowguid,
		           DateTime modifiedDate);

		void Update(int productCategoryID, string name,
		            Guid rowguid,
		            DateTime modifiedDate);

		void Delete(int productCategoryID);

		Response GetById(int productCategoryID);

		POCOProductCategory GetByIdDirect(int productCategoryID);

		Response GetWhere(Expression<Func<EFProductCategory, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOProductCategory> GetWhereDirect(Expression<Func<EFProductCategory, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>07c8688476d82d456f87ebcd841d146c</Hash>
</Codenesium>*/