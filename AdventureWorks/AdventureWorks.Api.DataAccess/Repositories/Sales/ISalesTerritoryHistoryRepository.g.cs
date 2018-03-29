using System;
using System.Linq.Expressions;
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

		void GetById(int businessEntityID, Response response);

		void GetWhere(Expression<Func<EFSalesTerritoryHistory, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>c0c2ce4ff73886acf827af7d6b1737fb</Hash>
</Codenesium>*/