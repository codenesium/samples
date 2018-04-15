using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductListPriceHistoryRepository
	{
		int Create(ProductListPriceHistoryModel model);

		void Update(int productID,
		            ProductListPriceHistoryModel model);

		void Delete(int productID);

		ApiResponse GetById(int productID);

		POCOProductListPriceHistory GetByIdDirect(int productID);

		ApiResponse GetWhere(Expression<Func<EFProductListPriceHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOProductListPriceHistory> GetWhereDirect(Expression<Func<EFProductListPriceHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>f299676eec437b8f1e473e96b582996a</Hash>
</Codenesium>*/