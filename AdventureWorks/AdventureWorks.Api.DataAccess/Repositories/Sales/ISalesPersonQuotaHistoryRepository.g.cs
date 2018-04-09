using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesPersonQuotaHistoryRepository
	{
		int Create(DateTime quotaDate,
		           decimal salesQuota,
		           Guid rowguid,
		           DateTime modifiedDate);

		void Update(int businessEntityID, DateTime quotaDate,
		            decimal salesQuota,
		            Guid rowguid,
		            DateTime modifiedDate);

		void Delete(int businessEntityID);

		Response GetById(int businessEntityID);

		POCOSalesPersonQuotaHistory GetByIdDirect(int businessEntityID);

		Response GetWhere(Expression<Func<EFSalesPersonQuotaHistory, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOSalesPersonQuotaHistory> GetWhereDirect(Expression<Func<EFSalesPersonQuotaHistory, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>3db2dabf85bed3dddd30e3084e14ca55</Hash>
</Codenesium>*/