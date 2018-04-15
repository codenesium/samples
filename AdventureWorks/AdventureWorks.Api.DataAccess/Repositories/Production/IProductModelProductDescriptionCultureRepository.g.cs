using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductModelProductDescriptionCultureRepository
	{
		int Create(ProductModelProductDescriptionCultureModel model);

		void Update(int productModelID,
		            ProductModelProductDescriptionCultureModel model);

		void Delete(int productModelID);

		ApiResponse GetById(int productModelID);

		POCOProductModelProductDescriptionCulture GetByIdDirect(int productModelID);

		ApiResponse GetWhere(Expression<Func<EFProductModelProductDescriptionCulture, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOProductModelProductDescriptionCulture> GetWhereDirect(Expression<Func<EFProductModelProductDescriptionCulture, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>8d435234ff17829b8f04a72110770057</Hash>
</Codenesium>*/