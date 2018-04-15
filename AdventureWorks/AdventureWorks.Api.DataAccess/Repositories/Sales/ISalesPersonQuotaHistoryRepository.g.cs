using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesPersonQuotaHistoryRepository
	{
		int Create(SalesPersonQuotaHistoryModel model);

		void Update(int businessEntityID,
		            SalesPersonQuotaHistoryModel model);

		void Delete(int businessEntityID);

		ApiResponse GetById(int businessEntityID);

		POCOSalesPersonQuotaHistory GetByIdDirect(int businessEntityID);

		ApiResponse GetWhere(Expression<Func<EFSalesPersonQuotaHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOSalesPersonQuotaHistory> GetWhereDirect(Expression<Func<EFSalesPersonQuotaHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>ec28e6f8668128c9b1979415beb37938</Hash>
</Codenesium>*/