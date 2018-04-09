using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesTerritoryRepository
	{
		int Create(string name,
		           string countryRegionCode,
		           string @group,
		           decimal salesYTD,
		           decimal salesLastYear,
		           decimal costYTD,
		           decimal costLastYear,
		           Guid rowguid,
		           DateTime modifiedDate);

		void Update(int territoryID, string name,
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

		Response GetWhere(Expression<Func<EFSalesTerritory, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOSalesTerritory> GetWhereDirect(Expression<Func<EFSalesTerritory, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>5c61687c58db21d1aef30e5074d751ac</Hash>
</Codenesium>*/