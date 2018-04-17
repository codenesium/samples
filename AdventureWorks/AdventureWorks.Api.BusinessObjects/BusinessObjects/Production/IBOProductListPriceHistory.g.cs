using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOProductListPriceHistory
	{
		Task<CreateResponse<int>> Create(
			ProductListPriceHistoryModel model);

		Task<ActionResponse> Update(int productID,
		                            ProductListPriceHistoryModel model);

		Task<ActionResponse> Delete(int productID);

		ApiResponse GetById(int productID);

		POCOProductListPriceHistory GetByIdDirect(int productID);

		ApiResponse GetWhere(Expression<Func<EFProductListPriceHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOProductListPriceHistory> GetWhereDirect(Expression<Func<EFProductListPriceHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>d38a58ac2de995e5c19cb6c016424107</Hash>
</Codenesium>*/