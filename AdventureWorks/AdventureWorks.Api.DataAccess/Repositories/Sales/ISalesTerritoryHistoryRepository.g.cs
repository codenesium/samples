using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesTerritoryHistoryRepository
	{
		int Create(int territoryID,
		           DateTime startDate,
		           Nullable<DateTime> endDate,
		           Guid rowguid,
		           DateTime modifiedDate);

		void Update(int businessEntityID, int territoryID,
		            DateTime startDate,
		            Nullable<DateTime> endDate,
		            Guid rowguid,
		            DateTime modifiedDate);

		void Delete(int businessEntityID);

		Response GetById(int businessEntityID);

		POCOSalesTerritoryHistory GetByIdDirect(int businessEntityID);

		Response GetWhere(Expression<Func<EFSalesTerritoryHistory, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOSalesTerritoryHistory> GetWhereDirect(Expression<Func<EFSalesTerritoryHistory, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>aaf40e85881f1fe8cf355f566a802b80</Hash>
</Codenesium>*/