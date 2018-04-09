using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesOrderHeaderSalesReasonRepository
	{
		int Create(int salesReasonID,
		           DateTime modifiedDate);

		void Update(int salesOrderID, int salesReasonID,
		            DateTime modifiedDate);

		void Delete(int salesOrderID);

		Response GetById(int salesOrderID);

		POCOSalesOrderHeaderSalesReason GetByIdDirect(int salesOrderID);

		Response GetWhere(Expression<Func<EFSalesOrderHeaderSalesReason, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOSalesOrderHeaderSalesReason> GetWhereDirect(Expression<Func<EFSalesOrderHeaderSalesReason, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>8d0a5b4459662931c611e7ef23ca071e</Hash>
</Codenesium>*/