using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesOrderHeaderSalesReasonRepository
	{
		int Create(SalesOrderHeaderSalesReasonModel model);

		void Update(int salesOrderID,
		            SalesOrderHeaderSalesReasonModel model);

		void Delete(int salesOrderID);

		ApiResponse GetById(int salesOrderID);

		POCOSalesOrderHeaderSalesReason GetByIdDirect(int salesOrderID);

		ApiResponse GetWhere(Expression<Func<EFSalesOrderHeaderSalesReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOSalesOrderHeaderSalesReason> GetWhereDirect(Expression<Func<EFSalesOrderHeaderSalesReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>a6d52bc16d80059ecb01d91faca3cd01</Hash>
</Codenesium>*/