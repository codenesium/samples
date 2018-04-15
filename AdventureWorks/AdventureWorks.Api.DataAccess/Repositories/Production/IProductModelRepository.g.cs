using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductModelRepository
	{
		int Create(ProductModelModel model);

		void Update(int productModelID,
		            ProductModelModel model);

		void Delete(int productModelID);

		ApiResponse GetById(int productModelID);

		POCOProductModel GetByIdDirect(int productModelID);

		ApiResponse GetWhere(Expression<Func<EFProductModel, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOProductModel> GetWhereDirect(Expression<Func<EFProductModel, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>484f122a987ae134efe4b65700d32749</Hash>
</Codenesium>*/