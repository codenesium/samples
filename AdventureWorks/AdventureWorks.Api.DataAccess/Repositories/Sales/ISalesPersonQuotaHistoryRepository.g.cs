using System;
using System.Linq.Expressions;
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

		void GetById(int businessEntityID, Response response);

		void GetWhere(Expression<Func<EFSalesPersonQuotaHistory, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>e87f84850a2fa512a144026d93f00dc7</Hash>
</Codenesium>*/