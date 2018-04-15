using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesReasonRepository
	{
		int Create(SalesReasonModel model);

		void Update(int salesReasonID,
		            SalesReasonModel model);

		void Delete(int salesReasonID);

		ApiResponse GetById(int salesReasonID);

		POCOSalesReason GetByIdDirect(int salesReasonID);

		ApiResponse GetWhere(Expression<Func<EFSalesReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOSalesReason> GetWhereDirect(Expression<Func<EFSalesReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>8a7bab6acc2e0cffe9ddd2efeed8d988</Hash>
</Codenesium>*/