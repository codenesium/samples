using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOSalesTerritoryHistory
	{
		Task<CreateResponse<int>> Create(
			SalesTerritoryHistoryModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            SalesTerritoryHistoryModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		ApiResponse GetById(int businessEntityID);

		POCOSalesTerritoryHistory GetByIdDirect(int businessEntityID);

		ApiResponse GetWhere(Expression<Func<EFSalesTerritoryHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOSalesTerritoryHistory> GetWhereDirect(Expression<Func<EFSalesTerritoryHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>3d844f4ed78562befb855c86cf0d91d6</Hash>
</Codenesium>*/