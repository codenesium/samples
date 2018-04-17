using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOProductCostHistory
	{
		Task<CreateResponse<int>> Create(
			ProductCostHistoryModel model);

		Task<ActionResponse> Update(int productID,
		                            ProductCostHistoryModel model);

		Task<ActionResponse> Delete(int productID);

		ApiResponse GetById(int productID);

		POCOProductCostHistory GetByIdDirect(int productID);

		ApiResponse GetWhere(Expression<Func<EFProductCostHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOProductCostHistory> GetWhereDirect(Expression<Func<EFProductCostHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>d4ff46bad691ff827e881c384d6d3dc9</Hash>
</Codenesium>*/