using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesTerritoryHistoryRepository
	{
		int Create(SalesTerritoryHistoryModel model);

		void Update(int businessEntityID,
		            SalesTerritoryHistoryModel model);

		void Delete(int businessEntityID);

		ApiResponse GetById(int businessEntityID);

		POCOSalesTerritoryHistory GetByIdDirect(int businessEntityID);

		ApiResponse GetWhere(Expression<Func<EFSalesTerritoryHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOSalesTerritoryHistory> GetWhereDirect(Expression<Func<EFSalesTerritoryHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>8da747abdf5c4a082f8fb94c43256e46</Hash>
</Codenesium>*/