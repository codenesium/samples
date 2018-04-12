using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesTerritoryRepository
	{
		int Create(
			string name,
			string countryRegionCode,
			string @group,
			decimal salesYTD,
			decimal salesLastYear,
			decimal costYTD,
			decimal costLastYear,
			Guid rowguid,
			DateTime modifiedDate);

		void Update(int territoryID,
		            string name,
		            string countryRegionCode,
		            string @group,
		            decimal salesYTD,
		            decimal salesLastYear,
		            decimal costYTD,
		            decimal costLastYear,
		            Guid rowguid,
		            DateTime modifiedDate);

		void Delete(int territoryID);

		Response GetById(int territoryID);

		POCOSalesTerritory GetByIdDirect(int territoryID);

		Response GetWhere(Expression<Func<EFSalesTerritory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOSalesTerritory> GetWhereDirect(Expression<Func<EFSalesTerritory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>13fc08a137e684e6f4838097bd5f7c28</Hash>
</Codenesium>*/