using System;
using System.Linq.Expressions;
using System.Collections.Generic;
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

		Response GetById(int businessEntityID);

		POCOSalesPerson GetByIdDirect(int businessEntityID);

		Response GetWhere(Expression<Func<EFSalesPerson, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOSalesPerson> GetWhereDirect(Expression<Func<EFSalesPerson, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>8c90aff694f3743a0af1eb26ef3fe84e</Hash>
</Codenesium>*/