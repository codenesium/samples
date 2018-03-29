using System;
using System.Linq.Expressions;
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

		void GetById(int territoryID, Response response);

		void GetWhere(Expression<Func<EFSalesTerritory, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>ae85c2bbfcc862fafffae0c3e986ef7c</Hash>
</Codenesium>*/