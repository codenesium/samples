using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOSalesTerritory
	{
		Task<CreateResponse<int>> Create(
			SalesTerritoryModel model);

		Task<ActionResponse> Update(int territoryID,
		                            SalesTerritoryModel model);

		Task<ActionResponse> Delete(int territoryID);

		ApiResponse GetById(int territoryID);

		POCOSalesTerritory GetByIdDirect(int territoryID);

		ApiResponse GetWhere(Expression<Func<EFSalesTerritory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOSalesTerritory> GetWhereDirect(Expression<Func<EFSalesTerritory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>ef312a927f54e1046496b391fbc227d7</Hash>
</Codenesium>*/