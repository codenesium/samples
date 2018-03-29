using System;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesPersonRepository
	{
		int Create(Nullable<int> territoryID,
		           Nullable<decimal> salesQuota,
		           decimal bonus,
		           decimal commissionPct,
		           decimal salesYTD,
		           decimal salesLastYear,
		           Guid rowguid,
		           DateTime modifiedDate);

		void Update(int businessEntityID, Nullable<int> territoryID,
		            Nullable<decimal> salesQuota,
		            decimal bonus,
		            decimal commissionPct,
		            decimal salesYTD,
		            decimal salesLastYear,
		            Guid rowguid,
		            DateTime modifiedDate);

		void Delete(int businessEntityID);

		void GetById(int businessEntityID, Response response);

		void GetWhere(Expression<Func<EFSalesPerson, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>bc13ca256a435f78fb9a53b44ed3b862</Hash>
</Codenesium>*/