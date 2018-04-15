using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesOrderHeaderRepository
	{
		int Create(SalesOrderHeaderModel model);

		void Update(int salesOrderID,
		            SalesOrderHeaderModel model);

		void Delete(int salesOrderID);

		ApiResponse GetById(int salesOrderID);

		POCOSalesOrderHeader GetByIdDirect(int salesOrderID);

		ApiResponse GetWhere(Expression<Func<EFSalesOrderHeader, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOSalesOrderHeader> GetWhereDirect(Expression<Func<EFSalesOrderHeader, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>e6f9013e1b2f900d9a361bc7247474fb</Hash>
</Codenesium>*/